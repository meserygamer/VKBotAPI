using VkNet.Model;

namespace CallBackVKAPI.Controllers.ButtonsBuilders
{
    public class ShowTodayScheduleButtonBuilder : IButtonBuilder
    {
        public ShowTodayScheduleButtonBuilder() => _button = new();


        public IButtonBuilder SetAction()
        {
            _button.Action = new MessageKeyboardButtonAction()
            {
                Type = VkNet.Enums.StringEnums.KeyboardButtonActionType.Text,
                Label = "Посмотреть расписание на сегодня",
                Payload = "{\"button\": \"4\"}"
            };
            return this;
        }
        public IButtonBuilder SetColor()
        {
            _button.Color = VkNet.Enums.StringEnums.KeyboardButtonColor.Secondary;
            return this;
        }

        public MessageKeyboardButton Build() => _button;


        private MessageKeyboardButton _button;
    }
}
