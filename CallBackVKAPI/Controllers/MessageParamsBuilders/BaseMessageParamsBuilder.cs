using VkNet.Model;

namespace CallBackVKAPI.Controllers.MessageParamsBuilders
{
    public abstract class BaseMessageParamsBuilder : IMessageParamsBuilder
    {
        public BaseMessageParamsBuilder(long peerID) => _peerID = peerID;


        public abstract IMessageParamsBuilder AddContent();

        public virtual IMessageParamsBuilder AddKeyboard() => this;

        public virtual MessagesSendParams Build() => _params;


        protected MessagesSendParams _params;

        protected long _peerID;
    }
}
