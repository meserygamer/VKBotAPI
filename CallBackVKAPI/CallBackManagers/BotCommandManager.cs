using CallBackVKAPI.Controllers.BotCommands;
using CallBackVKAPI.Controllers.BotCommandsFactories;
using CallBackVKAPI.Logger;
using CallBackVKAPI.Logger.ManagersLoggers;
using CallBackVKAPI.Models;
using VkNet.Abstractions;
using VkNet.Model;

namespace CallBackVKAPI.Controllers
{
    public class BotCommandManager
    {
        public BotCommandManager(IVkApi vkApi, Message message, IFileLogger logger) 
        {
            MessageFromUser = message;
            VkApi = vkApi;
            Logger = new BotCommandManagerLogger(logger); //Создание логгера для менеджера
            Logger.LogObjectCreation(typeof(BotCommandManager)); //Логгирование создания менеджера
        }


        /// <summary>
        /// Message из Callback API
        /// </summary>
        public Message MessageFromUser { get; private init; }

        /// <summary>
        /// Экземпляр VK API
        /// </summary>
        public IVkApi VkApi { get; private init; }

        /// <summary>
        /// Логгер для данного класса
        /// </summary>
        public BotCommandManagerLogger Logger { get; private set; }


        /// <summary>
        /// Создание команды, соответсвующей запросу отправленному пользователем
        /// </summary>
        /// <returns>команда, соответсвующая запросу обернутая в IBotCommand</returns>
        public IBotCommand GetBotCommand()
        {
            Logger.LogQuarryOnManage(typeof(IBotCommand), MessageFromUser.Text); //Логрование пришедшего запроса
            switch (MessageFromUser.Text) 
            {
                default:
                    Logger.LogManagerChoice("default"); //Логгирование выбора стандартной ветки
                    return new ShowMenuBotCommandFactory(VkApi
                        , MessageFromUser
                        , Logger.FileLogger)
                        .CreateBotCommand();
            }
        }
    }
}
