using VkNet.Model;

namespace CallBackVKAPI.Controllers.BotCommands
{
    /// <summary>
    /// Фабрика кнопок клавиатуры, отправляемой ботом в сообщении
    /// </summary>
    public class ButtonsFactory
    {
        /// <summary>
        /// Кнопка просмотра расписания на завтра
        /// </summary>
        public MessageKeyboardButton ShowScheduleForTomorrowButton
        {
            get => new MessageKeyboardButton()
            {
                Action = new MessageKeyboardButtonAction()
                {
                    Type = VkNet.Enums.StringEnums.KeyboardButtonActionType.Text,
                    Label = "Расписание на завтра",
                    Payload = "{\"button\": \"0\"}"
                },
                Color = VkNet.Enums.StringEnums.KeyboardButtonColor.Primary
            };
        }

        /// <summary>
        /// Кнопка добавления расписания на завтра
        /// </summary>
        public MessageKeyboardButton AddScheduleForTomorrowButton
        {
            get => new MessageKeyboardButton()
            {
                Action = new MessageKeyboardButtonAction()
                {
                    Type = VkNet.Enums.StringEnums.KeyboardButtonActionType.Text,
                    Label = "Добавить расписание на завтра",
                    Payload = "{\"button\": \"1\"}"
                },
                Color = VkNet.Enums.StringEnums.KeyboardButtonColor.Positive
            };
        }
    }
}
