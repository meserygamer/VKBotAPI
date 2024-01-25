using CallBackVKAPI.Models;
using System.Text.Json;

namespace CallBackVKAPI.Logger.ControllersLoggers
{
    /// <summary>
    /// Класс инкапсулирующий логику для логгирования CallBack контроллера
    /// </summary>
    public class CallBackControllerLogger : ControllerLogger
    {
        public CallBackControllerLogger(IFileLogger logger) : base(logger)
        {
        }

        /// <summary>
        /// Метод, логирующий объект запроса к контроллеру
        /// </summary>
        /// <param name="quarryObject">Объект запроса</param>
        /// <exception cref="Exception">Ошибка невозможности обработки объекта запроса логгером</exception>
        public override void LogQuarryObject(object quarryObject)
        {
            if (!FileLogger.IsFileNameSet)
            {
                if (quarryObject is Updates quarryObjectUpdates)
                {
                    SetLoggerFileName(quarryObjectUpdates.Type + "__" + DateTime.Now.ToString("\'date\'dd.mm.yyyy\'time\'H.mm") + "__" + quarryObjectUpdates.EventId);
                }
                else throw new Exception("Некорректный класс объекта запроса для работы с логгером");
            }
            FileLogger.WriteStringToLog("Пришедший запрос:");
            FileLogger.WriteStringToLog(JsonSerializer.Serialize<Updates>((Updates)quarryObject));
        }

        /// <summary>
        /// Метод, логирующий начало реакции на поступивший запрос
        /// </summary>
        public void LogStartReaction()
        {
            FileLogger.WriteStringToLog("Начало реакции на поступивший запрос");
        }


    }
}
