using CallBackVKAPI.Controllers.BotCommands;
using CallBackVKAPI.Controllers.CallbackReactions;
using CallBackVKAPI.Logger;
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
            _logger = logger;
            _newMessageCallbackReactionFactoryLogger = new NewMessageCallbackReactionFactoryLogger(_logger);
            string messageStringForm = update.Object["message"].AsObject().ToJsonString();
            _messageFromUser = JsonConvert.DeserializeObject<Message>(messageStringForm);
            if (_messageFromUser is null)
            {
                _newMessageCallbackReactionFactoryLogger.LogMessageDeserializeError();//Логгирование ошибки
                throw new ArgumentNullException("Преобразование Object:Message в тип Message не удалось");
            }
            _vkApi = vkApi;
            _newMessageCallbackReactionFactoryLogger.LogInfoAboutCreatingObject(); 
            //Логгирование создания фабрики
        }


        /// <summary>
        /// Создание NewMessageCallbackReaction обернутого в ICallBackReaction
        /// </summary>
        /// <returns>экземпляр NewMessageCallbackReaction</returns>
        public ICallBackReaction CreateCallbackReaction()
        {
            IBotCommand botCommand = CreateBotCommand();
            _newMessageCallbackReactionFactoryLogger.LogInfoAboutCreatingCallbackReaction(); 
            //Логгирование создания реакции нового сообщения
            return new NewMessageCallbackReaction(botCommand);
        }


        /// <summary>
        /// Получение соответствующей команды для запроса пользователя
        /// </summary>
        /// <returns>Команда обернутая в IBotCommand</returns>
        private IBotCommand CreateBotCommand()
        {
            _newMessageCallbackReactionFactoryLogger.LogInfoAboutCreatingCallbackReactionCommand(); 
            //Логгирование создания комманды для реакции
            return new BotCommandManager(_vkApi, _messageFromUser, _logger).GetBotCommand();
        }


        /// <summary>
        /// Сообщение полученное из CallbackAPI
        /// </summary>
        private Message _messageFromUser;

        /// <summary>
        /// Экземпляр vkApi
        /// </summary>
        private IVkApi _vkApi;

        /// <summary>
        /// Используемый файловый логгер
        /// </summary>
        private IFileLogger _logger;

        /// <summary>
        /// Логгер для фабрики
        /// </summary>
        private NewMessageCallbackReactionFactoryLogger _newMessageCallbackReactionFactoryLogger;
    }

    /// <summary>
    /// Класс инкапсулирующий в себе логику логгирования фабрики создания реакции нового сообщения
    /// </summary>
    public class NewMessageCallbackReactionFactoryLogger
    {
        /// <summary>
        /// Основной конструктор логгера для фабрики реакции нового сообщения
        /// </summary>
        /// <param name="logger">Используемый файловый логгер</param>
        public NewMessageCallbackReactionFactoryLogger(IFileLogger logger)
        {
            _logger = logger;
        }


        /// <summary>
        /// Метод логгирования информации о создании нового объекта
        /// </summary>
        public void LogInfoAboutCreatingObject()
        {
            _logger.WriteStringToLog("Создан объект фабрики реакции нового сообщения", LogLevel.Debug);
        }

        /// <summary>
        /// Метод логгирования ошибки десериализации сообщения из json
        /// </summary>
        public void LogMessageDeserializeError()
        {
            _logger.WriteStringToLog("Неудалось дессериализовать message из Json", LogLevel.Error);
        }

        /// <summary>
        /// Метод логгирования информации о начале создания реакции
        /// </summary>
        public void LogInfoAboutCreatingCallbackReaction()
        {
            _logger.WriteStringToLog("Фабрика создаёт реакцию нового сообщения", LogLevel.Debug);
        }

        /// <summary>
        /// Метод логгирования информации о начале создания команды для реакции
        /// </summary>
        public void LogInfoAboutCreatingCallbackReactionCommand()
        {
            _logger.WriteStringToLog("Фабрика создаёт команду для реакции нового сообщения", LogLevel.Debug);
        }


        /// <summary>
        /// Используемый файловый логгер
        /// </summary>
        private IFileLogger _logger;
    }
}
