namespace CallBackVKAPI.Logger.CallBackReactionFactoriesLoggers
{
    /// <summary>
    /// Класс, инкапсулирующий общий функционал логгирования фабрик создания реакций
    /// </summary>
    public abstract class CallBackReactionFactoryLogger : ApiObjectLogger
    {
        protected CallBackReactionFactoryLogger(IFileLogger logger) : base(logger)
        {
        }


        /// <summary>
        /// Метод, логгирующий информацию о начале создания фабрикой реакции
        /// </summary>
        /// <param name="reactionType">тип реакции, создаваемой фабрикой</param>
        public virtual void LogReactionCreating(Type reactionType) => 
            FileLogger.WriteStringToLog("Фабрика реакций начала создание объекта - " 
            + reactionType.FullName);
    }
}
