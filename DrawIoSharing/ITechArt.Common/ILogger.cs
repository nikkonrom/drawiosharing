using System.Diagnostics;

namespace ITechArt.Common
{
    public enum LoggingEventType
    {
        Debug,
        Information,
        Warning,
        Error,
        Fatal
    }

    public interface ILogger
    {
        void Log(LogEntry entry);
    }
}