
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Models;
using VkNet.Abstractions;
using VkNet.Enums.StringEnums;
using VkNet.Model;
using VkNet;
using CallBackVKAPI.Models.DataBase;

namespace CallBackVKAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors();
            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo { Title = "Test VK API", Version = "1v" });
                option.TagActionsBy(api =>
                {
                    if (api.GroupName != null)
                    {
                        return new[] { api.GroupName };
                    }

                    var controllerActionDescriptor = api.ActionDescriptor as ControllerActionDescriptor;
                    if (controllerActionDescriptor != null)
                    {
                        return new[] { controllerActionDescriptor.ControllerName };
                    }

                    throw new InvalidOperationException("Unable to determine tag for endpoint.");
                });
                option.DocInclusionPredicate((name, api) => true);
            });
            builder.Services.AddSingleton<IVkApi, VkApi>();

            var app = builder.Build();

            app.UseCors(builder => builder.AllowAnyOrigin());

            app.MapControllers();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });

            using (DataBaseContext db = new DataBaseContext())
            {
                db.BotUsers.Add(new BotUser() 
                {
                    VkId = 474771569,
                    IsAdmin = true,
                    IsSubscriber = true,
                });
                db.SaveChanges();
            }

            app.Run();
        }
    }
}
