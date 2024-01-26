namespace CallBackVKAPI.Logger.BotCommandFactoriesLoggers
{
    /// <summary>
    /// Класс инкапсулирующий общую логику логгирования для фабрик создания комманд бота
    /// </summary>
    public abstract class BotCommandFactoryLogger : ApiObjectLogger
    {
        protected BotCommandFactoryLogger(IFileLogger logger) : base(logger)
        {
        }


        /// <summary>
        /// Метод, логгирующий начало создания комманды
        /// </summary>
        /// <param name="factoryType">Тип фабрики</param>
        /// <param name="commandType">Тип комманды</param>
        public virtual void LogStartCreateBotCommand(Type factoryType, Type commandType) => 
            FileLogger.WriteStringToLog("Фабрика комманд бота "
                + factoryType.FullName 
                + ", начала создание команды типа " 
                + commandType.FullName
                , LogLevel.Debug);
    }
}
