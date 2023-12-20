using System.Drawing;
using VkNet.Model;

namespace CallBackVKAPI.Controllers.ButtonsBuilders
{
    public class SubscribeOnUpdateButtonBuilder : IButtonBuilder
    {
        public SubscribeOnUpdateButtonBuilder() => _button = new();


        public IButtonBuilder SetAction()
        {
            _button.Action = new MessageKeyboardButtonAction()
            {
                Type = VkNet.Enums.StringEnums.KeyboardButtonActionType.Text,
                Label = "Подписаться на рассылку",
                Payload = "{\"button\": \"2\"}"
            };
            return this;
        }
        public IButtonBuilder SetColor()
        {
            _button.Color = VkNet.Enums.StringEnums.KeyboardButtonColor.Positive;
            return this;
        }

        public MessageKeyboardButton Build()
        {
            return _button;
        }


        private MessageKeyboardButton _button;
    }
}
