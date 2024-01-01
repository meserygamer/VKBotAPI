using System.Text.Json.Nodes;

namespace CallBackVKAPI.Logger
{
    public interface IFileLogger : ILogger
    {
        public string? LogFileName { get; set; }


        public void WriteStringToLog(string StringToWrite
                                    , LogLevel logLevel = LogLevel.Information);
    }
}
