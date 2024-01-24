
using CallBackVKAPI.Controllers.BotCommands;

namespace CallBackVKAPI.Controllers.CallbackReactions
{
    public class NewMessageCallbackReaction : CallbackReactionBase
    {
        public NewMessageCallbackReaction(IBotCommand callbackCommand)
        {
            _callbackCommand = callbackCommand;
        }


        /// <summary>
        /// Метод, запускающий реакцию на отправленное пользователем сообщение
        /// </summary>
        public override void StartReaction()
        {
            _callbackCommand.ExecuteCommand();
        }

        /// <summary>
        /// Метод, запускающий реакцию на отправленное пользователем сообщение, асинхронный
        /// </summary>
        /// <returns>Асинхронная операция</returns>
        public async override Task StartReactionAsync()
        {
            await Task.Run(() => _callbackCommand.ExecuteCommand());
        }


        /// <summary>
        /// Команда исполняемая ботом в качестве реакции на возникшее событие
        /// </summary>
        private IBotCommand _callbackCommand;
    }
}
