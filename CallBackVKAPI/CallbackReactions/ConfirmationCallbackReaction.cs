using CallBackVKAPI.Logger;
using CallBackVKAPI.Logger.CallBackReactionFactoriesLoggers;
using CallBackVKAPI.Logger.CallBackReactionLoggers;
using Microsoft.AspNetCore.Mvc;

namespace CallBackVKAPI.Controllers.CallbackReactions
{
    /// <summary>
    /// Реакция на callback типа подтверждение
    /// </summary>
    public class ConfirmationCallbackReaction : CallbackReactionBase
    {
        public ConfirmationCallbackReaction(string confirmingMessage, IFileLogger logger)
        {
            ConfirmingMessage = confirmingMessage;
            Logger = new ConfirmationCallbackReactionLogger(logger);
            Logger.LogObjectCreation(typeof(ConfirmationCallbackReaction)); //Логирование создания объекта
        }


        /// <summary>
        /// Логгер для данного класса
        /// </summary>
        public ConfirmationCallbackReactionLogger Logger { get; private set; }


        /// <summary>
        /// Возвращает положительный результат запроса с кодом подтверждения внутри
        /// </summary>
        /// <returns></returns>
        public override IActionResult GetResult() => new OkObjectResult(ConfirmingMessage);

        /// <summary>
        /// Никаких действий не происходит, так как кроме возврата подтверждения ничего не нужно
        /// </summary>
        public override void StartReaction() { }

        /// <summary>
        /// Никаких действий не происходит, так как кроме возврата подтверждения ничего не нужно
        /// </summary>
        /// <returns>Аснхронная операция</returns>
        public override async Task StartReactionAsync() { }


        /// <summary>
        /// Сообщение для подтвержения сервера
        /// </summary>
        public string ConfirmingMessage { get; private set; } = "";
    }
}
