using CallBackVKAPI.Controllers.CallbackReactions;

namespace CallBackVKAPI.Controllers.CallBackReactionsFactories
{
    /// <summary>
    /// Интерфейс фабрики создания реакций на callback
    /// </summary>
    public interface ICallbackReactionFactory
    {
        /// <summary>
        /// Создаёт экземпляр реакции на callback
        /// </summary>
        /// <returns>экземпляр реакции на callback</returns>
        public ICallBackReaction CreateCallbackReaction();
    }
}
