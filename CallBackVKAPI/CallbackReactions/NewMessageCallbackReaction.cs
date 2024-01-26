
using CallBackVKAPI.Controllers.BotCommands;
using CallBackVKAPI.Logger;
using CallBackVKAPI.Logger.CallBackReactionLoggers;

namespace CallBackVKAPI.Controllers.CallbackReactions
{
    public class NewMessageCallbackReaction : CallbackReactionBase
    {
        public NewMessageCallbackReaction(IBotCommand callbackCommand, IFileLogger logger)
        {
            _callbackCommand = callbackCommand;
            Logger = new NewMessageCallbackReactionLogger(logger); //Создание логгера
            Logger.LogObjectCreation(typeof(NewMessageCallbackReaction)); //Логирование факта
                                                                          //создания объекта
        }


        /// <summary>
        /// Логгер для данного класса
        /// </summary>
        public NewMessageCallbackReactionLogger Logger { get; private set; }


        /// <summary>
        /// Метод, запускающий реакцию на отправленное пользователем сообщение
        /// </summary>
        public override void StartReaction()
        {
            Logger.LogReactionStartCommandSync(typeof(NewMessageCallbackReaction)
                , _callbackCommand.GetType()); //Логгирование синхронного запуска реакции
            _callbackCommand.ExecuteCommand();
        }

        /// <summary>
        /// Метод, запускающий реакцию на отправленное пользователем сообщение, асинхронный
        /// </summary>
        /// <returns>Асинхронная операция</returns>
        public async override Task StartReactionAsync()
        {
            Logger.LogReactionStartCommandAsync(typeof(NewMessageCallbackReaction)
                , _callbackCommand.GetType()); //Логгирование асинхронного запуска реакции
            await Task.Run(() => _callbackCommand.ExecuteCommand());
        }


        /// <summary>
        /// Команда исполняемая ботом в качестве реакции на возникшее событие
        /// </summary>
        private IBotCommand _callbackCommand;
    }
}
