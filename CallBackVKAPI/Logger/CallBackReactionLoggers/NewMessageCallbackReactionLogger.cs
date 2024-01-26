namespace CallBackVKAPI.Logger.CallBackReactionLoggers
{
    /// <summary>
    /// Класс, инкапсулирующий логику логгирования для NewMessageCallbackReaction
    /// </summary>
    public class NewMessageCallbackReactionLogger : CallBackReactionLogger
    {
        public NewMessageCallbackReactionLogger(IFileLogger logger) : base(logger)
        {
        }
    }
}
