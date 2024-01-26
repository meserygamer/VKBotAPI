using CallBackVKAPI.Controllers.BotCommands;
using CallBackVKAPI.Controllers.MessageParamsBuilders;
using CallBackVKAPI.Logger;
using CallBackVKAPI.Logger.BotCommandFactoriesLoggers;
using CallBackVKAPI.Logger.ManagersLoggers;
using CallBackVKAPI.Models;
using VkNet.Abstractions;
using VkNet.Model;

namespace CallBackVKAPI.Controllers.BotCommandsFactories
{
    /// <summary>
    /// Фабрика создания команд показа главного меню
    /// </summary>
    public class ShowMenuBotCommandFactory : IBotCommandsFactory
    {
        public ShowMenuBotCommandFactory(IVkApi vkApi, Message message, IFileLogger logger)
        {
            VkApi = vkApi;
            Message = message;
            Logger = new ShowMenuBotCommandFactoryLogger(logger); //Создание логгера
            Logger.LogObjectCreation(typeof(ShowMenuBotCommandFactory)); //Логгирование
                                                                         //создания объекта
        }


        /// <summary>
        /// Message из CallbackAPI
        /// </summary>
        public Message Message { get; private init; }

        /// <summary>
        /// Экземпляр VK API
        /// </summary>
        public IVkApi VkApi { get; private init; }

        /// <summary>
        /// Логгер для данного класса
        /// </summary>
        public ShowMenuBotCommandFactoryLogger Logger { get; private set; }


        /// <summary>
        /// Создать команду показа главного меню
        /// </summary>
        /// <returns>Экземпляр ShowMenuBotCommand обернутый в IBotCommand</returns>
        public IBotCommand CreateBotCommand()
        {
            Logger.LogStartCreateBotCommand(typeof(ShowMenuBotCommandFactory)
                , typeof(ShowMenuBotCommand)); //Логгирование начала создания комманды
            if(Message.FromId is null)
            {
                Exception ex = new ArgumentNullException("Message.FromId"
                    , "ID отправителя отсутствует");
                Logger.LogException(ex); //Логгирование ошибки
                throw ex;
            }

            return new ShowMenuBotCommand(VkApi
                , new ShowMainMenuMessageParamsBuilder((long)Message.FromId)
                    .AddContent()
                    .AddKeyboard()
                    .Build()
                , Logger.FileLogger);
        }
    }
}
