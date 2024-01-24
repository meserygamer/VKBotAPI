namespace CallBackVKAPI.Controllers.BotCommands
{
    /// <summary>
    /// Команды выполняемые в ответ на действие пользователя
    /// </summary>
    public interface IBotCommand
    {
        /// <summary>
        /// Метод, начинающий исполнение команды
        /// </summary>
        public void ExecuteCommand();
    }
}
