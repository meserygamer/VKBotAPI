using CallBackVKAPI.Controllers.CallbackReactions;
using CallBackVKAPI.Logger;
using CallBackVKAPI.Logger.CallBackReactionFactoriesLoggers;

namespace CallBackVKAPI.Controllers.CallBackReactionsFactories
{
    /// <summary>
    /// Фабрика, создания реакции на запрос с обновлением не поддерживаемым на данный момент
    /// </summary>
    public class FailedQueryCallbackReactionFactory : ICallbackReactionFactory
    {
        public FailedQueryCallbackReactionFactory(IFileLogger logger) 
        {
            Logger = new FailedQueryCallbackReactionFactoryLogger(logger); //Создание логгера
            Logger.LogObjectCreation(typeof(FailedQueryCallbackReactionFactory)); //Логгирование создание объекта
        }


        /// <summary>
        /// Логгер для данного класса
        /// </summary>
        public FailedQueryCallbackReactionFactoryLogger Logger { get; private set; }


        /// <summary>
        /// Создаёт экземпляр реакции на callback
        /// </summary>
        /// <returns>Новый объект типа FailedQueryCallbackReaction упакованный в ICallBackReaction</returns>
        public ICallBackReaction CreateCallbackReaction()
        {
            Logger.LogReactionCreating(typeof(FailedQueryCallbackReaction)); //Логгирование создание реакции на некорректный запрос
            return new FailedQueryCallbackReaction(Logger.FileLogger);
        }
    }
}
