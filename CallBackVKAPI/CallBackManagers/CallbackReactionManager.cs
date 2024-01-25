using CallBackVKAPI.Controllers.CallbackReactions;
using CallBackVKAPI.Controllers.CallBackReactionsFactories;
using CallBackVKAPI.Logger;
using CallBackVKAPI.Logger.ManagersLoggers;
using CallBackVKAPI.Models;
using VkNet.Abstractions;
using VkNet.Enums;

namespace CallBackVKAPI.Controllers
{
    /// <summary>
    /// Класс отвечающий за создание необходимой реакции в ответ на поступившее обновление
    /// </summary>
    public class CallbackReactionManager
    {
        public CallbackReactionManager(Updates updateFromVK, IConfiguration configuration, IVkApi vkApi, IFileLogger logger) 
        {
            UpdateFromVK = updateFromVK;
            Configuration = configuration;
            VkApi = vkApi;
            Logger = new CallBackReactionManagerLogger(logger); //Создание логгера для класса
            Logger.LogObjectCreation(typeof(CallbackReactionManager)); //Логирование информации
                                                                                              //о создании экземпляра класса
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
        /// Логгер для данного класса
        /// </summary>
        public CallBackReactionManagerLogger Logger { get; private set; }


        /// <summary>
        /// Возвращает объект реакции на поступившее обновление
        /// </summary>
        /// <returns>Объект реакции</returns>
        /// <exception cref="ArgumentNullException">Происходит, если в appsettings отсутствует аругемент Config:Confirmation</exception>
        public ICallBackReaction GetReactionOnUpdate()
        {
            Logger.LogQuarryOnManage(typeof(ICallBackReaction), UpdateFromVK.Type); //Логгирование
                                                                                                           //пришедшего запроса
            switch (UpdateFromVK.Type)
            {
                case "confirmation":
                    Logger.LogManagerChoice("confirmation"); //Логгирование выбора ветки подтверждения
                    if (Configuration["Config:Confirmation"] is null)
                    {
                        Exception exception = new ArgumentNullException("Config:Confirmation"
                            , "Config:Confirmation - noncontains"); //Создание ошибки
                        Logger.LogException(exception); //Логгирование ошибки
                        throw exception;
                    }
                    return (new ConfirmationCallBackReactionFactory(Logger.FileLogger) 
                    {
                        ResultMessage = Configuration["Config:Confirmation"]
                    }).CreateCallbackReaction();

                case "message_new":
                    Logger.LogManagerChoice("message_new"); //Логгирование выбора ветки нового сообщения
                    return new NewMessageCallbackReactionFactory(VkApi
                        , UpdateFromVK
                        , Logger.FileLogger).CreateCallbackReaction();

                default:
                    Logger.LogManagerChoice("default"); //Логгирование выбора ветки по умолчанию
                    return new FailedQueryCallbackReactionFactory().CreateCallbackReaction();
            }
        }
    }
}
