using CallBackVKAPI.Controllers.CallbackReactions;
using CallBackVKAPI.Controllers.CallBackReactionsFactories;
using CallBackVKAPI.Models;
using VkNet.Abstractions;

namespace CallBackVKAPI.Controllers
{
    /// <summary>
    /// Класс отвечающий за создание необходимой реакции в ответ на поступившее обновление
    /// </summary>
    public class CallbackReactionManager
    {
        public CallbackReactionManager(Updates updateFromVK, IConfiguration configuration, IVkApi vkApi) 
        {
            UpdateFromVK = updateFromVK;
            Configuration = configuration;
            VkApi = vkApi;
        }


        /// <summary>
        /// Сообщение полученное от ВК CallbackAPI
        /// </summary>
        public Updates UpdateFromVK { get; private init; }

        /// <summary>
        /// Конфигурация приложения
        /// </summary>
        public IConfiguration Configuration { get; private init; }

        /// <summary>
        /// Экземпляр VK API
        /// </summary>
        public IVkApi VkApi { get; private init; }


        /// <summary>
        /// Возвращает объект реакции на поступившее обновление
        /// </summary>
        /// <returns>Объект реакции</returns>
        /// <exception cref="ArgumentNullException">Происходит, если в appsettings отсутствует аругемент Config:Confirmation</exception>
        public ICallBackReaction GetReactionOnUpdate()
        {
            switch (UpdateFromVK.Type)
            {
                case "confirmation":
                    if(Configuration["Config:Confirmation"] is null)
                    {
                        throw new ArgumentNullException("Config:Confirmation - noncontains");
                    }
                    return (new ConfirmationCallBackReactionFactory() 
                    {
                        ResultMessage = Configuration["Config:Confirmation"]
                    }).CreateCallbackReaction();

                case "message_new":
                    return new NewMessageCallbackReactionFactory(VkApi, UpdateFromVK).CreateCallbackReaction();

                default:
                    return new FailedQueryCallbackReactionFactory().CreateCallbackReaction();
            }
        }
    }
}
