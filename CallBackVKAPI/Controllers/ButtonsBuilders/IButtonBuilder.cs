using VkNet.Model;

namespace CallBackVKAPI.Controllers.ButtonsBuilders
{
    public interface IButtonBuilder
    {
        public MessageKeyboardButton Build();

        public IButtonBuilder SetColor();
        public IButtonBuilder SetAction();
    }
}
