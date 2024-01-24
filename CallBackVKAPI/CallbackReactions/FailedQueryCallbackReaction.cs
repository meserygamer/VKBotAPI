
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CallBackVKAPI.Controllers.CallbackReactions
{
    /// <summary>
    /// Реакция на запрос с неподдерживаемым типом
    /// </summary>
    public class FailedQueryCallbackReaction : CallbackReactionBase
    {
        /// <summary>
        /// Метод, возвращающий результат реакции
        /// </summary>
        /// <returns>Код 501 и ошибка</returns>
        public override IActionResult GetResult() => new ObjectResult("Обработка данного вида событий на данный момент не реализована") { StatusCode = 501};

        /// <summary>
        /// Метод, запускающий реакцию на входящий запрос
        /// </summary>
        public override void StartReaction(){}

        /// <summary>
        /// Метод, запускающий асинхронную реакцию на входящий запрос
        /// </summary>
        /// <returns>Асинхронная операция</returns>
        public async override Task StartReactionAsync(){}
    }
}
