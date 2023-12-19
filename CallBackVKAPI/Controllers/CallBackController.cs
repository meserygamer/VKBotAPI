using CallBackVKAPI.Controllers.CallbackReactions;
using CallBackVKAPI.Models;
using Microsoft.AspNetCore.Mvc;
using VkNet;
using VkNet.Abstractions;
using VkNet.Model;

namespace CallBackVKAPI.Controllers
{
    [ApiController]
    [Route("")]
    public class CallBackController : Controller
    {
        public CallBackController(IConfiguration configuration, IVkApi vkApi)
        {
            _configuration = configuration;
            _vkApi = vkApi;
            var ApiAuth = new ApiAuthParams();
            ApiAuth.AccessToken = _configuration["Config:AccessToken"];
            _vkApi.Authorize(ApiAuth);
        }


        [HttpPost]
        public IActionResult CallbackAsync([FromBody] Updates updates)
        {
            CallbackReactionManager reactionManager = new (updates, _configuration); //Создание менеджера реакций
            ICallBackReaction reaction = reactionManager.GetReactionOnUpdate(); //Получение соответсвующей событию реакции
            Task.Run(() => reaction.StartReactionAsync()); //Запуск реакции на update в другом потоке
            return reaction.GetResult(); //Оповещение ВК API о получении обновления
        }


        private readonly IConfiguration _configuration;

        private readonly IVkApi _vkApi;
    }
}
