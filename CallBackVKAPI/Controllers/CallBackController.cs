using CallBackVKAPI.Controllers.CallbackReactions;
using CallBackVKAPI.Logger;
using CallBackVKAPI.Logger.ControllersLoggers;
using CallBackVKAPI.Logger.ManagersLoggers;
using CallBackVKAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Nodes;
using VkNet;
using VkNet.Abstractions;
using VkNet.Model;

namespace CallBackVKAPI.Controllers
{
    [ApiController]
    [Route("")]
    public class CallBackController : Controller
    {
        public CallBackController(IConfiguration configuration, IVkApi vkApi, IFileLogger fileLogger)
        {
            Configuration = configuration;
            VkApi = vkApi;
            Logger = new (fileLogger);
            Logger.LogObjectCreation(typeof(CallBackController));
        }


        /// <summary>
        /// Конфигурация приложения
        /// </summary>
        public IConfiguration Configuration { get; private init; }

        /// <summary>
        /// Экземпляр VK API
        /// </summary>
        public IVkApi VkApi { get; private init; }

        /// <summary>
        /// Логгер для данного класса
        /// </summary>
        public CallBackControllerLogger Logger { get; private set; }


        [HttpPost]
        public IActionResult CallbackAsync([FromBody] Updates updates)
        {
            AuthorizeInVkApi(); //Авторизация в vkApi
            Logger.LogQuarryObject(updates); //Логгирование объекта запроса в файл
            CallbackReactionManager reactionManager = new (updates, Configuration, VkApi, Logger.FileLogger); //Создание менеджера реакций
            ICallBackReaction reaction = reactionManager.GetReactionOnUpdate(); //Получение соответсвующей событию реакции
            Logger.LogStartReaction(); //Логгирование начала реакции на запрос
            Task.Run(() => reaction.StartReactionAsync()); //Запуск реакции на update в другом потоке
            Logger.LogResult(reaction.GetResult()); //Логгирование подтверждения ВК получения запроса
            return reaction.GetResult(); //Оповещение ВК API о получении обновления
        }


        /// <summary>
        /// Авторизация в API Вконтакте
        /// </summary>
        private void AuthorizeInVkApi()
        {
            var ApiAuth = new ApiAuthParams();
            ApiAuth.AccessToken = Configuration["Config:AccessToken"];
            VkApi.Authorize(ApiAuth);
        }
    }
}
