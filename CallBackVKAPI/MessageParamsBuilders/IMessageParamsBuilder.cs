using VkNet.Model;

namespace CallBackVKAPI.Controllers.MessageParamsBuilders
{
    public interface IMessageParamsBuilder
    {
        public IMessageParamsBuilder AddContent();
        public IMessageParamsBuilder AddKeyboard();

        public MessagesSendParams Build();
    }
}
