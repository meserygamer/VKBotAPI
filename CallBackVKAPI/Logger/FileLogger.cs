using System;
using System.Text;
using System.Text.Json.Nodes;

namespace CallBackVKAPI.Logger
{
    public class FileLogger : ILogger, IDisposable
    {
        /// <summary>
        /// При использовании данного конструктора необходимо передать имя файла с логами собственноручно
        /// </summary>
        public FileLogger() { }


        /// <summary>
        /// Название файла логов
        /// </summary>
        public string? LogFileName { get; init; }


        public void WriteStringToLog(string StringToWrite
                                    ,LogLevel logLevel = LogLevel.Information)
        {
            Log<String>(logLevel
                       ,0 
                       ,StringToWrite 
                       ,null 
                       ,(str, exp) => str);
        }

        public void WriteJSONToLog(JsonObject jsonObjectToWrite
                                  ,LogLevel logLevel = LogLevel.Information)
        {

        }


        #region Реализация ILogger
        public IDisposable? BeginScope<TState>(TState state) where TState : notnull => this;

        /// <summary>
        /// Метод определяющий доступность логгера
        /// </summary>
        /// <param name="logLevel">Уровень логгирования, для которого осуществляется проверка</param>
        /// <returns>true - Логгер доступен, false - Логгер недоступен</returns>
        public bool IsEnabled(LogLevel logLevel) => true;

        /// <summary>
        /// Запись в лог
        /// </summary>
        /// <typeparam name="TState">Тип объекта, принимаемый в лог</typeparam>
        /// <param name="logLevel">Уровень запроса логгирования</param>
        /// <param name="eventId">Идентификатор события</param>
        /// <param name="state">Объект состояния, хранящий сообщение</param>
        /// <param name="exception">Логгируемое исключение</param>
        /// <param name="formatter">функция форматирования, которая с помощью двух предыдущих параметров позволяет получить собственно сообщение для логгирования</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            if (!IsEnabled(logLevel)) return;
            CreateLogFileIfDoesNotExist();
            lock(_lockerDummy)
            {
                WriteLineToLogFile(formatter(state, exception));
            }
        }
        #endregion

        #region Реализация IDisposable
        public void Dispose() { }
        #endregion


        /// <summary>
        /// Файл для хранения логов запроса
        /// </summary>
        private FileInfo? _logFile = null;

        /// <summary>
        /// Заглушка для синхронизации потоков при работе с файлом логов
        /// </summary>
        private object _lockerDummy = new object();


        /// <summary>
        /// Создание файла логов, если он не существует
        /// </summary>
        private void CreateLogFileIfDoesNotExist()
        {
            if (_logFile is not null) return;
            if (LogFileName is null) throw new ArgumentNullException(nameof(LogFileName));
            _logFile = new FileInfo(LogFileName);
            _logFile.Create();
        }

        /// <summary>
        /// Запись строки в файл с логами
        /// </summary>
        /// <param name="stringOnWrite">Строка для записи</param>
        private void WriteLineToLogFile(string stringOnWrite)
        {
            using (StreamWriter SW = _logFile!.AppendText())
            {
                SW.WriteLine(stringOnWrite);
                SW.Flush();
                SW.Close();
            }
        }
    }
}
