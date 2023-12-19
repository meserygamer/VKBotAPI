using CallBackVKAPI.Controllers.CallbackReactions;

namespace CallBackVKAPI.Controllers.CallBackReactionsFactories
{
    /// <summary>
    /// Фабрика, создания реакции на запрос с обновлением не поддерживаемым на данный момент
    /// </summary>
    public class FailedQueryCallbackReactionFactory : ICallbackReactionFactory
    {
        /// <summary>
        /// Создаёт экземпляр реакции на callback
        /// </summary>
        /// <returns>Новый объект типа FailedQueryCallbackReaction упакованный в ICallBackReaction</returns>
        public ICallBackReaction CreateCallbackReaction() => new FailedQueryCallbackReaction();
    }
}
