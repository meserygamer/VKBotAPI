using Microsoft.AspNetCore.Mvc;

namespace CallBackVKAPI.Controllers.CallbackReactions
{
    /// <summary>
    /// Интерфейс реакции
    /// </summary>
    public interface ICallBackReaction
    {
        /// <summary>
        /// Метод, возвращающий результат реакции
        /// </summary>
        /// <returns>Результат реакции</returns>
        public IActionResult GetResult();

        /// <summary>
        /// Метод, запускающий реакцию на входящий запрос
        /// </summary>
        public void StartReaction();

        /// <summary>
        /// Метод, запускающий асинхронную реакцию на входящий запрос
        /// </summary>
        /// <returns>Асинхронная операция</returns>
        public Task StartReactionAsync();
    }
}
