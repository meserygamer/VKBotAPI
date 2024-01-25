namespace CallBackVKAPI.Logger.CallBackReactionFactoriesLoggers
{
    /// <summary>
    /// Класс, инкапсулирующий логику логгирования класса NewMessageCallbackReactionFactory
    /// </summary>
    public class NewMessageCallbackReactionFactoryLogger : CallBackReactionFactoryLogger
    {
        public NewMessageCallbackReactionFactoryLogger(IFileLogger logger) : base(logger)
        {
        }


        /// <summary>
        /// Метод, логгирующий информацию о начале создания команды для реакции
        /// </summary>
        public void LogCommandCreating() => 
            FileLogger.WriteStringToLog("NewMessageCallbackReactionFactory запрашивает" +
                " у менеджера комманду, для формирования реакции");
    }
}
