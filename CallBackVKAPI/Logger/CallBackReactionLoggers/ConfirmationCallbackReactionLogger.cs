namespace CallBackVKAPI.Logger.CallBackReactionLoggers
{
    /// <summary>
    /// Класс, икапсулирующий логику логгирования для класса ConfirmationCallbackReaction
    /// </summary>
    public class ConfirmationCallbackReactionLogger : CallBackReactionLogger
    {
        public ConfirmationCallbackReactionLogger(IFileLogger logger) : base(logger)
        {
        }
    }
}
