using CallBackVKAPI.Logger;
using CallBackVKAPI.Logger.BotCommandLoggers;
using CallBackVKAPI.Logger.ManagersLoggers;
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
        public ShowMenuBotCommand(IVkApi vkApi, MessagesSendParams messageParams, IFileLogger logger)
        {
            VkApi = vkApi;
            MessageParams = messageParams;
            Logger = new ShowMenuBotCommandLogger(logger); //Создание логгера
            Logger.LogObjectCreation(typeof(ShowMenuBotCommand)); //Логгирование создания объекта
        }


        /// <summary>
        /// Свойство, хранящее параметры сообщения
        /// </summary>
        public MessagesSendParams MessageParams { get; private init; }

        /// <summary>
        /// Экземпляр VK API
        /// </summary>
        public IVkApi VkApi { get; private init; }

        /// <summary>
        /// Логгер для данного класса
        /// </summary>
        public ShowMenuBotCommandLogger Logger { get; private set; }


        /// <summary>
        /// Метод, отправляющий меню
        /// </summary>
        public void ExecuteCommand()
        {
            Logger.LogStartCommandExecution(typeof(ShowMenuBotCommand)); //Логгирование
                                                                         //запуска комманды
                                                                         //на исполнение
            VkApi.Messages.SendAsync(MessageParams);
        }
    }
}
