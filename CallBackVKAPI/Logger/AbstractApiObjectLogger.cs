namespace CallBackVKAPI.Logger
{
    /// <summary>
    /// Абстрактный класс, инкапсулирующий общую логику логгирования для всех классов в программе
    /// </summary>
    public abstract class ApiObjectLogger
    {
        protected ApiObjectLogger(IFileLogger logger)
        {
            FileLogger = logger;
        }


        /// <summary>
        /// Свойство, хранящее используемый логгер
        /// </summary>
        public IFileLogger FileLogger { get; private init; }


        /// <summary>
        /// Метод, логгирующий факт создания объекта
        /// </summary>
        /// <param name="objectType">Тип созданного объекта</param>
        public virtual void LogObjectCreation(Type objectType) =>
            FileLogger.WriteStringToLog("Создан объект - " + objectType.FullName
                                        , LogLevel.Debug);

        /// <summary>
        /// Метод, логгирующий факт возникновения ошибки
        /// </summary>
        /// <param name="exception"></param>
        public virtual void LogException(Exception exception) => 
            FileLogger.WriteStringToLog("В методе - + "
                                      + exception.TargetSite 
                                      + ", возникло исключение - " 
                                      + exception.ToString()
                                      + ", Сообщение - "
                                      + exception.Message
                                      + ", Трассировка стека - "
                                      + exception.StackTrace, LogLevel.Error);
    }
}
