using CallBackVKAPI.Controllers.BotCommands;
using CallBackVKAPI.Controllers.CallbackReactions;
using CallBackVKAPI.Logger;
using CallBackVKAPI.Logger.CallBackReactionFactoriesLoggers;
using CallBackVKAPI.Logger.ManagersLoggers;
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
        public NewMessageCallbackReactionFactory(IVkApi vkApi, Updates update, IFileLogger logger) 
        {
            Logger = new NewMessageCallbackReactionFactoryLogger(logger);
            string messageStringForm = update.Object["message"].AsObject().ToJsonString();
            MessageFromUser = JsonConvert.DeserializeObject<Message>(messageStringForm);
            if (MessageFromUser is null)
            {
                Exception ex = new ArgumentNullException("Object:Message", "Преобразование Object:Message в тип Message не удалось");
                Logger.LogException(ex);//Логгирование ошибки
                throw ex;
            }
            VkApi = vkApi;
            Logger.LogObjectCreation(typeof(NewMessageCallbackReactionFactory)); //Логгирование создания фабрики
        }


        /// <summary>
        /// Сообщение полученное из CallbackAPI
        /// </summary>
        public Message MessageFromUser { get; private init; }

        /// <summary>
        /// Экземпляр VK API
        /// </summary>
        public IVkApi VkApi { get; private init; }

        /// <summary>
        /// Логгер для данного класса
        /// </summary>
        public NewMessageCallbackReactionFactoryLogger Logger { get; private set; }


        /// <summary>
        /// Создание NewMessageCallbackReaction обернутого в ICallBackReaction
        /// </summary>
        /// <returns>экземпляр NewMessageCallbackReaction</returns>
        public ICallBackReaction CreateCallbackReaction()
        {
            IBotCommand botCommand = CreateBotCommand();
            Logger.LogReactionCreating(typeof(NewMessageCallbackReaction)); //Логгирование создания реакции нового сообщения
            return new NewMessageCallbackReaction(botCommand);
        }


        /// <summary>
        /// Получение соответствующей команды для запроса пользователя
        /// </summary>
        /// <returns>Команда обернутая в IBotCommand</returns>
        private IBotCommand CreateBotCommand()
        {
            Logger.LogCommandCreating(); //Логгирование создания комманды для реакции
            return new BotCommandManager(VkApi, MessageFromUser, Logger.FileLogger).GetBotCommand();
        }
    }
}
