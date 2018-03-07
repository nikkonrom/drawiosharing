using ITechArt.Common.Logging;

namespace ITechArt.Common.Logging
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