using CallBackVKAPI.Controllers.CallbackReactions;
using CallBackVKAPI.Logger;
using CallBackVKAPI.Logger.CallBackReactionFactoriesLoggers;
using CallBackVKAPI.Logger.ManagersLoggers;

namespace CallBackVKAPI.Controllers.CallBackReactionsFactories
{
    /// <summary>
    /// Фабрика создания ConfirmationCallbackReaction
    /// </summary>
    public class ConfirmationCallBackReactionFactory : ICallbackReactionFactory
    {
        public ConfirmationCallBackReactionFactory(IFileLogger fileLogger)
        {
            Logger = new ConfirmationCallBackReactionFactoryLogger(fileLogger); //Создание логгера
            Logger.LogObjectCreation(typeof(ConfirmationCallBackReactionFactory)); //Логгирование создания объекта
        }


        /// <summary>
        /// Сообщение, необходимое для подтверждения сервера
        /// </summary>
        public string ResultMessage {get; set;} = string.Empty;

        /// <summary>
        /// Логгер для данного класса
        /// </summary>
        public ConfirmationCallBackReactionFactoryLogger Logger { get; private set; }


        /// <summary>
        /// Создаёт экземпляр реакции на callback
        /// </summary>
        /// <returns>Новый объект типа ConfirmationCallbackReaction упакованный в ICallBackReaction</returns>
        public ICallBackReaction CreateCallbackReaction()
        {
            Logger.LogReactionCreating(typeof(ConfirmationCallbackReaction));
            //Логгирование информации о начале создания реакции
            return new ConfirmationCallbackReaction(ResultMessage, Logger.FileLogger);
        }
    }
}
