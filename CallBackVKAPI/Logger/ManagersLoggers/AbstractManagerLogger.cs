namespace CallBackVKAPI.Logger.ManagersLoggers
{
    /// <summary>
    /// Абстрактный класс инкапсулирующий логику логгирования для всех классов типа менеджер в программе
    /// </summary>
    public abstract class ManagerLogger : ApiObjectLogger
    {
        protected ManagerLogger(IFileLogger logger) : base(logger)
        {
        }

        /// <summary>
        /// Метод, логирующий получение, классом менеджером, запроса на объект
        /// </summary>
        /// <param name="quarryType">Тип объекта, запрашиваемого у менеджера</param>
        /// <param name="manageParam">значение параметра, используемого менеджером для выбора класса создаваемого объекта</param>
        public virtual void LogQuarryOnManage(Type quarryType, string manageParam)
        {
            FileLogger.WriteStringToLog("Поступил запрос объекта с типом - " 
                + quarryType.FullName 
                + ", Значение параметра, используемое для выбора класса - " 
                + manageParam);
        }

        /// <summary>
        /// Метод, логгирующий выбор ветки менеджером
        /// </summary>
        /// <param name="branchName">Название ветки</param>
        public virtual void LogManagerChoice(string branchName)
        {
            FileLogger.WriteStringToLog("Менеджер принял решение о проходе на ветку - "
                + branchName
                , LogLevel.Debug);
        }
    }
}
