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
            _callBackControllerLogger = new (fileLogger);
        }


        [HttpPost]
        public IActionResult CallbackAsync([FromBody] Updates updates)
        {
            AuthorizeInVkApi(); //Авторизация в vkApi
            _callBackControllerLogger.LogQuarryObjectIntoFile(updates); //Логгирование объекта запроса в файл
            CallbackReactionManager reactionManager = new (updates, _configuration, _vkApi, _fileLogger); //Создание менеджера реакций
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


        private readonly IConfiguration _configuration;

        private readonly IVkApi _vkApi;

        private readonly IFileLogger _fileLogger;

        private readonly CallBackControllerLogger _callBackControllerLogger;
    }


    /// <summary>
    /// Класс инкапсулирующий логику для логгирования CallBack контроллера
    /// </summary>
    public class CallBackControllerLogger
    {
        /// <summary>
        /// Основной конструктор
        /// </summary>
        /// <param name="logger">Реализация сервиса по логгированию в файл</param>
        public CallBackControllerLogger(IFileLogger logger)
        {
            _logger = logger;
        }


        /// <summary>
        /// Метод логгирования пришедшего запроса
        /// </summary>
        /// <param name="updates">Объект запроса</param>
        public void LogQuarryObjectIntoFile(Updates updates)
        {
            if (!_logger.IsFileNameSet)
            {
                SetLoggerFileName(updates);
            }
            _logger.WriteStringToLog("Пришедший запрос:");
            _logger.WriteStringToLog(JsonSerializer.Serialize<Updates>(updates));
        }


        /// <summary>
        /// Установка имени для фала логов в соотвествии с содержанием пришедшего запроса
        /// </summary>
        /// <param name="quarryForLogging">Объект пришедшего запроса</param>
        private void SetLoggerFileName(Updates quarryForLogging)
        {
            _logger.LogFileName = quarryForLogging.Type + "__" + DateTime.Now.ToString("\'date\'dd.mm.yyyy\'time\'H.mm") + "__" + quarryForLogging.EventId;
        }


        /// <summary>
        /// Реализация сервиса по логгированию в файл
        /// </summary>
        private readonly IFileLogger _logger;
    }
}
