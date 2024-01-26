namespace CallBackVKAPI.Logger.CallBackReactionLoggers
{
    /// <summary>
    /// Класс, инкапсулирующий логику логгирования для класса FailedQueryCallbackReaction
    /// </summary>
    public class FailedQueryCallbackReactionLogger : CallBackReactionLogger
    {
        public FailedQueryCallbackReactionLogger(IFileLogger logger) : base(logger)
        {
        }
    }
}
