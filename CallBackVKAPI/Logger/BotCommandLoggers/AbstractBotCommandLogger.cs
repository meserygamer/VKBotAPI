namespace CallBackVKAPI.Logger.BotCommandLoggers
{
    /// <summary>
    /// Класс инкапсулирующий общую логику логгирования для комманд бота
    /// </summary>
    public abstract class BotCommandLogger : ApiObjectLogger
    {
        protected BotCommandLogger(IFileLogger logger) : base(logger)
        {
        }


        /// <summary>
        /// Метод, логгирующий начало исполнения команды
        /// </summary>
        public virtual void LogStartCommandExecution(Type commandType) => 
            FileLogger.WriteStringToLog("Команда "
                + commandType.FullName
                + ", начала исполнение");
    }
}
