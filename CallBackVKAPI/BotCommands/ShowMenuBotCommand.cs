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
        public ShowMenuBotCommand(IVkApi vkApi, MessagesSendParams messageParams)
        {
            _vkApi = vkApi;
            MessageParams = messageParams;
        }


        /// <summary>
        /// Свойство, хранящее параметры сообщения
        /// </summary>
        public MessagesSendParams MessageParams { get; set; }


        /// <summary>
        /// Метод, отправляющий меню
        /// </summary>
        public void ExecuteCommand() => _vkApi.Messages.SendAsync(MessageParams);


        /// <summary>
        /// Экземпляр VK api, через который происходит отправка меню
        /// </summary>
        private IVkApi _vkApi;
    }
}
