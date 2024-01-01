using CallBackVKAPI.Controllers.CallbackReactions;
using CallBackVKAPI.Logger;
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
            _configuration = configuration;
            _vkApi = vkApi;
            _fileLogger = fileLogger;
        }


        [HttpPost]
        public IActionResult CallbackAsync([FromBody] Updates updates)
        {
            SetLoggerFileName(updates); //Задание имени файлу с логами
            AuthorizeInVkApi(); //Авторизация в vkApi
            _fileLogger.WriteStringToLog("Hello It's my logger!");
            _fileLogger.WriteStringToLog(JsonSerializer.Serialize<Updates>(updates));
            CallbackReactionManager reactionManager = new (updates, _configuration, _vkApi); //Создание менеджера реакций
            ICallBackReaction reaction = reactionManager.GetReactionOnUpdate(); //Получение соответсвующей событию реакции
            Task.Run(() => reaction.StartReactionAsync()); //Запуск реакции на update в другом потоке
            return reaction.GetResult(); //Оповещение ВК API о получении обновления
        }


        /// <summary>
        /// Авторизация в API Вконтакте
        /// </summary>
        private void AuthorizeInVkApi()
        {
            var ApiAuth = new ApiAuthParams();
            ApiAuth.AccessToken = _configuration["Config:AccessToken"];
            _vkApi.Authorize(ApiAuth);
        }

        private void SetLoggerFileName(Updates quarryForLogging)
        {
            _fileLogger.LogFileName = quarryForLogging.Type + "__" + DateTime.Now.ToString("\'date\'dd.mm.yyyy\'time\'H.mm") + "__" + quarryForLogging.EventId;
        }


        private readonly IConfiguration _configuration;

        private readonly IVkApi _vkApi;

        private readonly IFileLogger _fileLogger;
    }
}
