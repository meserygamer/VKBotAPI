using CallBackVKAPI.Controllers.CallbackReactions;
using CallBackVKAPI.Logger;

namespace CallBackVKAPI.Controllers.CallBackReactionsFactories
{
    /// <summary>
    /// Фабрика создания ConfirmationCallbackReaction
    /// </summary>
    public class ConfirmationCallBackReactionFactory : ICallbackReactionFactory
    {
        public ConfirmationCallBackReactionFactory(IFileLogger fileLogger)
        {
            _fileLogger = fileLogger;
            _confirmationCallBackReactionFactoryLogger = new ConfirmationCallBackReactionFactoryLogger(_fileLogger);
            _confirmationCallBackReactionFactoryLogger.LogInfoAboutCreatingObject(); //Логгирование создания объекта
        }


        /// <summary>
        /// Сообщение, необходимое для подтверждения сервера
        /// </summary>
        public string ResultMessage {get; set;} = string.Empty;


        /// <summary>
        /// Создаёт экземпляр реакции на callback
        /// </summary>
        /// <returns>Новый объект типа ConfirmationCallbackReaction упакованный в ICallBackReaction</returns>
        public ICallBackReaction CreateCallbackReaction()
        {
            _confirmationCallBackReactionFactoryLogger.LogInfoAboutCreatingCallbackReaction(); 
            //Логгирование информации о начале создания реакции
            return new ConfirmationCallbackReaction(ResultMessage, _fileLogger);
        }


        /// <summary>
        /// Используемый логгер
        /// </summary>
        private IFileLogger _fileLogger;

        /// <summary>
        /// Класс инкапсулирующий логику логгирования фабрики реакции подтверждения
        /// </summary>
        private ConfirmationCallBackReactionFactoryLogger _confirmationCallBackReactionFactoryLogger;
    }


    /// <summary>
    /// Класс инкапсулирующий в себе логику логгирования фабрики создания реакции подтверждения
    /// </summary>
    public class ConfirmationCallBackReactionFactoryLogger
    {
        /// <summary>
        /// Основной конструктор логгера для фабрики реакции подтверждения
        /// </summary>
        /// <param name="logger">Используемый файловый логгер</param>
        public ConfirmationCallBackReactionFactoryLogger(IFileLogger logger)
        {
            _logger = logger;
        }


        /// <summary>
        /// Метод логгирования информации о создании нового объекта
        /// </summary>
        public void LogInfoAboutCreatingObject()
        {
            _logger.WriteStringToLog("Создан объект фабрики реакции подтверждения", LogLevel.Debug);
        }

        /// <summary>
        /// Метод логгирования информации о начале создания реакции
        /// </summary>
        public void LogInfoAboutCreatingCallbackReaction()
        {
            _logger.WriteStringToLog("Фабрика создаёт реакцию подтверждения", LogLevel.Debug);
        }


        /// <summary>
        /// Используемый файловый логгер
        /// </summary>
        private IFileLogger _logger;
    }
}
