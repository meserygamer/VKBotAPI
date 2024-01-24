using CallBackVKAPI.Controllers.CallbackReactions;
using CallBackVKAPI.Controllers.CallBackReactionsFactories;
using CallBackVKAPI.Logger;
using CallBackVKAPI.Models;
using VkNet.Abstractions;
using VkNet.Enums;

namespace CallBackVKAPI.Controllers
{
    /// <summary>
    /// Класс отвечающий за создание необходимой реакции в ответ на поступившее обновление
    /// </summary>
    public class CallbackReactionManager
    {
        public CallbackReactionManager(Updates updateFromVK, IConfiguration configuration, IVkApi vkApi, IFileLogger logger) 
        {
            UpdateFromVK = updateFromVK;
            Configuration = configuration;
            VkApi = vkApi;
            Logger = logger;
            _reactionManagerLogger = new CallBackReactionManagerLogger(logger);
            _reactionManagerLogger.LogDebugInfoAboutObject();
        }


        /// <summary>
        /// Сообщение полученное от ВК CallbackAPI
        /// </summary>
        public Updates UpdateFromVK { get; private init; }

        /// <summary>
        /// Конфигурация приложения
        /// </summary>
        public IConfiguration Configuration { get; private init; }

        /// <summary>
        /// Экземпляр VK API
        /// </summary>
        public IVkApi VkApi { get; private init; }

        /// <summary>
        /// Используемый файловый логгер
        /// </summary>
        public IFileLogger Logger { get; private init; }


        /// <summary>
        /// Возвращает объект реакции на поступившее обновление
        /// </summary>
        /// <returns>Объект реакции</returns>
        /// <exception cref="ArgumentNullException">Происходит, если в appsettings отсутствует аругемент Config:Confirmation</exception>
        public ICallBackReaction GetReactionOnUpdate()
        {
            _reactionManagerLogger.LogInfoAboutQuarryOnCreatingReaction(UpdateFromVK.Type); //Логгирование пришедшего запроса
            switch (UpdateFromVK.Type)
            {
                case "confirmation":
                    if(Configuration["Config:Confirmation"] is null)
                    {
                        _reactionManagerLogger.LogConfirmationError(); //Логгирование ошибки
                        throw new ArgumentNullException("Config:Confirmation - noncontains");
                    }
                    _reactionManagerLogger.LogConfirmationSucceed(); //Логгирование создания фабрики
                    return (new ConfirmationCallBackReactionFactory(Logger) 
                    {
                        ResultMessage = Configuration["Config:Confirmation"]
                    }).CreateCallbackReaction();

                case "message_new":
                    _reactionManagerLogger.LogMessageNewSucceed(); //Логгирование создания фабрики
                    return new NewMessageCallbackReactionFactory(VkApi, UpdateFromVK, Logger).CreateCallbackReaction();

                default:
                    _reactionManagerLogger.LogFailedQuarryType(); //Логгирование ошибки выбора реакции
                    return new FailedQueryCallbackReactionFactory().CreateCallbackReaction();
            }
        }


        private CallBackReactionManagerLogger _reactionManagerLogger;
    }


    /// <summary>
    /// Класс инкапсулирующий логику логгирования для менеджера реакций
    /// </summary>
    public class CallBackReactionManagerLogger
    {
        /// <summary>
        /// Основной конструктор логгера для менеджера реакций
        /// </summary>
        /// <param name="logger">Используемый файловый логгер</param>
        public CallBackReactionManagerLogger(IFileLogger logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Метод логгирования информации о создании менеджера реакций
        /// </summary>
        public void LogDebugInfoAboutObject()
        {
            _logger.WriteStringToLog("Сформирован объект менеджера реакций", LogLevel.Debug);
        }

        /// <summary>
        /// Логгирование информации о поступлении запроса на формирование реакции
        /// </summary>
        /// <param name="reactionType">Тип запроса</param>
        public void LogInfoAboutQuarryOnCreatingReaction(string reactionType)
        {
            _logger.WriteStringToLog("Поступил запрос на формирование реакции, Type - " + reactionType);
        }

        /// <summary>
        /// Метод логгирования ошибки отсутвия кода подтверждения
        /// </summary>
        public void LogConfirmationError()
        {
            _logger.WriteStringToLog("При формировании реакции на запрос произошла ошибка," +
                " в конфигурационном файле отсутствует параметр Config:Confirmation," +
                " отвечающий за отправляемый в ответ код подтверждения", LogLevel.Error);
        }

        /// <summary>
        /// Метод логгирования создания фабрики реакции подтверждения
        /// </summary>
        public void LogConfirmationSucceed()
        {
            _logger.WriteStringToLog("Запрошена реакция подтверждения", LogLevel.Debug);
        }

        /// <summary>
        /// Метод логгирования создания фабрики реакции на новое сообщение
        /// </summary>
        public void LogMessageNewSucceed()
        {
            _logger.WriteStringToLog("Запрошена реакция на новое сообщение", LogLevel.Debug);
        }

        public void LogFailedQuarryType()
        {
            _logger.WriteStringToLog("Запрашиваемого типа реакции не существует", LogLevel.Error);
        }


        /// <summary>
        /// Используемый файловый логгер
        /// </summary>
        private IFileLogger _logger;
    }
}
