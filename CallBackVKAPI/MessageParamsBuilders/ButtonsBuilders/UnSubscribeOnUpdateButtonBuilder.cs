using VkNet.Model;

namespace CallBackVKAPI.Controllers.ButtonsBuilders
{
    public class UnSubscribeOnUpdateButtonBuilder : IButtonBuilder
    {
        public UnSubscribeOnUpdateButtonBuilder() => _button = new();


        public IButtonBuilder SetAction()
        {
            _button.Action = new MessageKeyboardButtonAction()
            {
                Type = VkNet.Enums.StringEnums.KeyboardButtonActionType.Text,
                Label = "Отписаться от рассылки",
                Payload = "{\"button\": \"3\"}"
            };
            return this;
        }
        public IButtonBuilder SetColor()
        {
            _button.Color = VkNet.Enums.StringEnums.KeyboardButtonColor.Negative;
            return this;
        }

        public MessageKeyboardButton Build() => _button;


        private MessageKeyboardButton _button;
    }
}
