using CallBackVKAPI.Controllers.BotCommands;
using CallBackVKAPI.Controllers.CallbackReactions;
using CallBackVKAPI.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using VkNet.Abstractions;
using VkNet.Model;

namespace CallBackVKAPI.Controllers.CallBackReactionsFactories
{
    public class NewMessageCallbackReactionFactory : ICallbackReactionFactory
    {
        public NewMessageCallbackReactionFactory(IVkApi vkApi, Updates update) 
        {
            string messageStringForm = update.Object["message"].AsObject().ToJsonString();
            _messageFromUser = JsonConvert.DeserializeObject<Message>(messageStringForm);
            if (_messageFromUser is null)
            {
                throw new ArgumentNullException("Преобразование Object:Message в тип Message не удалось");
            }
            _vkApi = vkApi;
        }


        /// <summary>
        /// Создание NewMessageCallbackReaction обернутого в ICallBackReaction
        /// </summary>
        /// <returns>экземпляр NewMessageCallbackReaction</returns>
        public ICallBackReaction CreateCallbackReaction() => new NewMessageCallbackReaction(CreateBotCommand());


        /// <summary>
        /// Получение соответствующей команды для запроса пользователя
        /// </summary>
        /// <returns>Команда обернутая в IBotCommand</returns>
        private IBotCommand CreateBotCommand() => new BotCommandManager(_vkApi, _messageFromUser).GetBotCommand();


        /// <summary>
        /// Сообщение полученное из CallbackAPI
        /// </summary>
        private Message _messageFromUser;

        /// <summary>
        /// Экземпляр vkApi
        /// </summary>
        private IVkApi _vkApi;
    }
}
