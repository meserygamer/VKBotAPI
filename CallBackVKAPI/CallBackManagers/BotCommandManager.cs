using CallBackVKAPI.Controllers.BotCommands;
using CallBackVKAPI.Controllers.BotCommandsFactories;
using VkNet.Abstractions;
using VkNet.Model;

namespace CallBackVKAPI.Controllers
{
    public class BotCommandManager
    {
        public BotCommandManager(IVkApi vkApi, Message message) 
        {
            _messageFromUser = message;
            _vkApi = vkApi;
        }

        /// <summary>
        /// Создание команды, соответсвующей запросу отправленному пользователем
        /// </summary>
        /// <returns>команда, соответсвующая запросу обернутая в IBotCommand</returns>
        public IBotCommand GetBotCommand()
        {
            switch (_messageFromUser.Text) 
            {
                default:
                    return new ShowMenuBotCommandFactory(_vkApi, _messageFromUser).CreateBotCommand();
            }
        }

        /// <summary>
        /// Message из Callback API
        /// </summary>
        private Message _messageFromUser;

        /// <summary>
        /// Эземпляр VK API
        /// </summary>
        private IVkApi _vkApi;
    }
}
