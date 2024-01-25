namespace CallBackVKAPI.Logger
{
    public interface IApiObjectLogger
    {
        /// <summary>
        /// Свойство, хранящее используемый логгер
        /// </summary>
        IFileLogger FileLogger { get; }


        /// <summary>
        /// Метод, логгирующий факт создания объекта
        /// </summary>
        /// <param name="objectType">Тип созданного объекта</param>
        virtual void LogObjectCreation(Type objectType) =>
            FileLogger.WriteStringToLog("Создан объект - " + objectType.FullName
                                        , LogLevel.Debug);

        /// <summary>
        /// Метод, логгирующий факт возникновения ошибки
        /// </summary>
        /// <param name="exception"></param>
        virtual void LogException(Exception exception) => 
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
