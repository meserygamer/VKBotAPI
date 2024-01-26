namespace CallBackVKAPI.Logger.CallBackReactionLoggers
{
    /// <summary>
    /// Класс инкапсулирующий общую логику для логгирования классов реакций
    /// </summary>
    public abstract class CallBackReactionLogger : ApiObjectLogger
    {
        protected CallBackReactionLogger(IFileLogger logger) : base(logger)
        {
        }


        /// <summary>
        /// Метод, логгирующий синхронный запуск команды реакцией
        /// </summary>
        /// <param name="reactionType">Тип реакции</param>
        /// <param name="commandType">Тип запускаемой команды</param>
        public virtual void LogReactionStartCommandSync(Type reactionType, Type commandType) => 
            FileLogger.WriteStringToLog("Реакция " 
                + reactionType.FullName 
                + " синхронно запускает комманду " 
                + commandType.FullName
                , LogLevel.Debug);

        /// <summary>
        /// Метод, логгирующий асинхронный запуск команды реакцией
        /// </summary>
        /// <param name="reactionType">Тип реакции</param>
        /// <param name="commandType">Тип запускаемой команды</param>
        public virtual void LogReactionStartCommandAsync(Type reactionType, Type commandType) =>
            FileLogger.WriteStringToLog("Реакция "
                + reactionType.FullName
                + " асинхронно запускает комманду "
                + commandType.FullName
                , LogLevel.Debug);
    }
}
