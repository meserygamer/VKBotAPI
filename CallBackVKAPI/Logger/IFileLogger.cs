using System.Text.Json.Nodes;

namespace CallBackVKAPI.Logger
{
    public interface IFileLogger : ILogger
    {
        /// <summary>
        /// Имя файла в который осуществляется логгирование
        /// </summary>
        public string? LogFileName { get; set; }


        /// <summary>
        /// Свойство хранящее было ли задано имя файла для логгирования
        /// </summary>
        public bool IsFileNameSet => LogFileName != null;


        public void WriteStringToLog(string StringToWrite
                                    , LogLevel logLevel = LogLevel.Information);
    }
}
