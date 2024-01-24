using System.Drawing;
using VkNet.Model;

namespace CallBackVKAPI.Controllers.ButtonsBuilders
{
    public class ShowTomorrowScheduleButtonBuilder : IButtonBuilder
    {
        public ShowTomorrowScheduleButtonBuilder() => _button = new ();


        public IButtonBuilder SetAction()
        {
            _button.Action = new MessageKeyboardButtonAction()
            {
                Type = VkNet.Enums.StringEnums.KeyboardButtonActionType.Text,
                Label = "Расписание на завтра",
                Payload = "{\"button\": \"0\"}"
            };
            return this;
        }
        public IButtonBuilder SetColor()
        {
            _button.Color = VkNet.Enums.StringEnums.KeyboardButtonColor.Primary;
            return this;
        }

        public MessageKeyboardButton Build()
        {
            return _button;
        }


        MessageKeyboardButton _button; 
    }
}
