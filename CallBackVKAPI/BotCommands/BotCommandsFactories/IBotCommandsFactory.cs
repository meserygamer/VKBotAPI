using CallBackVKAPI.Controllers.BotCommands;

namespace CallBackVKAPI.Controllers.BotCommandsFactories
{
    /// <summary>
    /// Интерфейс фабрики создания IBotCommand
    /// </summary>
    public interface IBotCommandsFactory
    {
        /// <summary>
        /// Создание IBotCommand
        /// </summary>
        /// <returns>Экземпляр IBotCommand</returns>
        public IBotCommand CreateBotCommand();
    }
}
