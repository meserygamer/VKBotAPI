using Microsoft.AspNetCore.Mvc;

namespace CallBackVKAPI.Controllers.CallbackReactions
{
    /// <summary>
    /// Базовый класс реакции
    /// </summary>
    public abstract class CallbackReactionBase : ICallBackReaction
    {
        /// <summary>
        /// Метод, возвращающий результат реакции
        /// </summary>
        /// <returns>Результат реакции (По умолчанию код 200 и ok)</returns>
        public virtual IActionResult GetResult() => new OkObjectResult("ok");

        /// <summary>
        /// Метод, запускающий реакцию на входящий запрос
        /// </summary>
        public abstract void StartReaction();

        /// <summary>
        /// Метод, запускающий асинхронную реакцию на входящий запрос
        /// </summary>
        /// <returns>Асинхронная операция</returns>
        public abstract Task StartReactionAsync();
    }
}
