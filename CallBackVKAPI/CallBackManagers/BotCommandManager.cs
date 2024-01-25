using CallBackVKAPI.Controllers.BotCommands;
using CallBackVKAPI.Controllers.BotCommandsFactories;
using CallBackVKAPI.Logger;
using VkNet.Abstractions;
using VkNet.Model;

namespace CallBackVKAPI.Controllers
{
    public class BotCommandManager
    {
        public BotCommandManager(IVkApi vkApi, Message message, IFileLogger logger) 
        {
            _messageFromUser = message;
            _vkApi = vkApi;
            _logger = logger;
            _botCommandManagerLogger = new BotCommandManagerLogger(_logger); //Создание логгера для менеджера
            _botCommandManagerLogger.LogCreatingObject();
        }

        /// <summary>
        /// Создание команды, соответсвующей запросу отправленному пользователем
        /// </summary>
        /// <returns>команда, соответсвующая запросу обернутая в IBotCommand</returns>
        public IBotCommand GetBotCommand()
        {
            switch (_messageFromUser.Text) 
            {
                default:
                    _botCommandManagerLogger.LogDefaultBranch(); //Логгирование выбора стандартной ветки
                    return new ShowMenuBotCommandFactory(_vkApi, _messageFromUser).CreateBotCommand();
            }
        }

        /// <summary>
        /// Message из Callback API
        /// </summary>
        private Message _messageFromUser;

        /// <summary>
        /// Экземпляр VK API
        /// </summary>
        private IVkApi _vkApi;

        /// <summary>
        /// Используемый логгер
        /// </summary>
        private IFileLogger _logger;

        /// <summary>
        /// Логгирующий класс
        /// </summary>
        private BotCommandManagerLogger _botCommandManagerLogger;
    }

    /// <summary>
    /// Класс инкапсулирующий логику логгирования BotCommandManager
    /// </summary>
    public class BotCommandManagerLogger
    {
        public BotCommandManagerLogger(IFileLogger logger) 
        {
            _logger = logger;
        }


        /// <summary>
        /// Метод логгирующий создание объекта
        /// </summary>
        public void LogCreatingObject()
        {
            _logger.WriteStringToLog("Объект BotCommandManager создан!", LogLevel.Debug);
        }

        /// <summary>
        /// Метод логгирующий выбор менеджером дефолтной ветки
        /// </summary>
        public void LogDefaultBranch()
        {
            _logger.WriteStringToLog("Объект BotCommandManager, выбрал ветку default");
        }


        /// <summary>
        /// Используемый логгер
        /// </summary>
        private IFileLogger _logger;
    }
}
