using CallBackVKAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CallBackVKAPI.Logger.ControllersLoggers
{
    /// <summary>
    /// Класс, инкапсулирующий общую логику логирования для контроллеров
    /// </summary>
    public abstract class ControllerLogger : ApiObjectLogger
    {
        protected ControllerLogger(IFileLogger logger) : base(logger)
        {
        }

        /// <summary>
        /// Метод, логгирующий результат работы контроллера
        /// </summary>
        /// <param name="result">Класс результат</param>
        public virtual void LogResult(object result) => FileLogger.WriteStringToLog("Результат контроллера - " + result.ToString());

        /// <summary>
        /// Метод, логирующий объект запроса к контроллеру
        /// </summary>
        /// <param name="quarryObject">Объект запроса</param>
        public abstract void LogQuarryObject(object quarryObject);


        /// <summary>
        /// Метод, устанавливающий имя файла логов для контроллера
        /// </summary>
        /// <param name="logFileName">Имя файла</param>
        protected virtual void SetLoggerFileName(string logFileName) => 
            FileLogger.LogFileName = logFileName;
    }
}
