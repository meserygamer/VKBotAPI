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
        public IActionResult Callback([FromBody] Updates updates)
        {
            // Проверяем, что находится в поле "type" 
            switch (updates.Type)
            {
                // Если это уведомление для подтверждения адреса
                case "confirmation":
                    // Отправляем строку для подтверждения 
                    return Ok(_configuration["Config:Confirmation"]);
                case "message_new":
                    {
                        break;
                    }
            }
            // Возвращаем "ok" серверу Callback API
            return Ok("ok");
        }


        private readonly IConfiguration _configuration;

        private readonly IVkApi _vkApi;
    }
}
