using CallBackVKAPI.Models;
using VkNet.Abstractions;
using VkNet.Model;

namespace CallBackVKAPI.Controllers.BotCommands
{
    /// <summary>
    /// Команда в результате вызова отправляющая меню бота
    /// </summary>
    public class ShowMenuBotCommand : IBotCommand
    {
        public ShowMenuBotCommand(IVkApi vkApi, long peerID)
        {
            _vkApi = vkApi;
            _peerID = peerID;
        }


        /// <summary>
        /// Метод, отправляющий меню
        /// </summary>
        public void ExecuteCommand() => _vkApi.Messages.SendAsync(MessageParams);


        /// <summary>
        /// Экземпляр VK api, через который происходит отправка меню
        /// </summary>
        private IVkApi _vkApi;

        /// <summary>
        /// ID пользователя, которому отправится меню
        /// </summary>
        private long _peerID;


        /// <summary>
        /// Параметры отправляемого сообщения
        /// </summary>
        private MessagesSendParams MessageParams 
        {
            get => new MessagesSendParams()
            {
                RandomId = new DateTime().Millisecond,
                Message = "Меню бота",
                PeerId = _peerID,
                Keyboard = MessageKeyboard
            };
        }

        /// <summary>
        /// Клавиатура в отправляемом сообщении
        /// </summary>
        private MessageKeyboard MessageKeyboard
        {
            get => new MessageKeyboard()
            {
                OneTime = false,
                Inline = true,
                Buttons = MessageKeyboardButtons
            };
        }

        /// <summary>
        /// Набор кнопок в отправляемой клавиатуре
        /// </summary>
        private IEnumerable<IEnumerable<MessageKeyboardButton>> MessageKeyboardButtons
        {
            get 
            {
                var buttonsFactory = new ButtonsFactory();
                return new List<List<MessageKeyboardButton>>
                {
                    new List<MessageKeyboardButton>() {buttonsFactory.ShowScheduleForTomorrowButton},
                    new List<MessageKeyboardButton>() {buttonsFactory.AddScheduleForTomorrowButton}
                };
            }
        }
    }
}
