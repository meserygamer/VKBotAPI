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
    }
}
