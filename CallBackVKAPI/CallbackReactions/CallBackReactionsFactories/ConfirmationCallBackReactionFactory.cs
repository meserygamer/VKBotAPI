using CallBackVKAPI.Controllers.CallbackReactions;

namespace CallBackVKAPI.Controllers.CallBackReactionsFactories
{
    /// <summary>
    /// Фабрика создания ConfirmationCallbackReaction
    /// </summary>
    public class ConfirmationCallBackReactionFactory : ICallbackReactionFactory
    {
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
            return new ConfirmationCallbackReaction(ResultMessage);
        }
    }
}
