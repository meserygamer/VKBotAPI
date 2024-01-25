namespace CallBackVKAPI.Logger.ManagersLoggers
{
    /// <summary>
    /// Класс инкапсулирующий логику логгирования для класса CallBackReactionManager
    /// </summary>
    public class CallBackReactionManagerLogger : ManagerLogger
    {
        /// <summary>
        /// Конструктор CallBackReactionManagerLogger
        /// </summary>
        /// <param name="logger">Используемый логгер</param>
        public CallBackReactionManagerLogger(IFileLogger logger) : base()
        {
            FileLogger = logger;
        }


        /// <summary>
        /// Используемый файловый логгер
        /// </summary>
        public IFileLogger FileLogger { get; private init;}
    }
}
