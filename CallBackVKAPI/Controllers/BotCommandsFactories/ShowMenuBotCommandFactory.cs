using CallBackVKAPI.Controllers.BotCommands;
using VkNet.Abstractions;
using VkNet.Model;

namespace CallBackVKAPI.Controllers.BotCommandsFactories
{
    /// <summary>
    /// Фабрика создания команд показа главного меню
    /// </summary>
    public class ShowMenuBotCommandFactory : IBotCommandsFactory
    {
        public ShowMenuBotCommandFactory(IVkApi vkApi, Message message)
        {
            _vkApi = vkApi;
            _message = message;
        }


        /// <summary>
        /// Создать команду показа главного меню
        /// </summary>
        /// <returns>Экземпляр ShowMenuBotCommand обернутый в IBotCommand</returns>
        public IBotCommand CreateBotCommand()
        {
            if(_message.FromId is null)
            {
                throw new ArgumentNullException("ID отправителя отсутствует");
            }

            return new ShowMenuBotCommand(_vkApi, (long)_message.FromId);
        }

        /// <summary>
        /// Экземпляр VK api
        /// </summary>
        private IVkApi _vkApi;

        /// <summary>
        /// Message из CallbackAPI
        /// </summary>
        private Message _message;
    }
}
