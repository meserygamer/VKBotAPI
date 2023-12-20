using VkNet.Model;

namespace CallBackVKAPI.Controllers.ButtonsBuilders
{
    public class AddScheduleTomorrowButtonBuilder : IButtonBuilder
    {
        public AddScheduleTomorrowButtonBuilder() => _button = new();


        public IButtonBuilder SetAction()
        {
            _button.Action = new MessageKeyboardButtonAction()
            {
                Type = VkNet.Enums.StringEnums.KeyboardButtonActionType.Text,
                Label = "Добавить расписание на завтра",
                Payload = "{\"button\": \"1\"}"
            };
            return this;
        }

        public IButtonBuilder SetColor()
        {
            _button.Color = VkNet.Enums.StringEnums.KeyboardButtonColor.Default;
            return this;
        }

        public MessageKeyboardButton Build() => _button;


        private MessageKeyboardButton _button;
    }
}
