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
        private readonly IConfiguration _configuration = Program.app.Configuration;

        private readonly IVkApi _vkApi = new VkApi();

        public CallBackController()
        {
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
            }
            // Возвращаем "ok" серверу Callback API
            return Ok("ok");
        }
    }
}
