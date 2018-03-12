using System;

namespace ITechArt.Common.Logging
{
    public static class LoggerExtensions
    {
        public static void Debug(this ILogger logger, string message)
        {
            logger.Log(new LogEntry(LoggingEventType.Debug, message));
        }

        public static void Info(this ILogger logger, string message)
        {
            logger.Log(new LogEntry(LoggingEventType.Information, message));
        }
        
        public static void Warning(this ILogger logger, string message)
        {
            logger.Log(new LogEntry(LoggingEventType.Warning, message));
        }

        public static void Warning(this ILogger logger, Exception exception, string customMessage)
        {
            logger.Log(new LogEntry(LoggingEventType.Warning, customMessage, exception));
        }

        public static void Error(this ILogger logger, string message)
        {
            logger.Log(new LogEntry(LoggingEventType.Error, message));
        }

        public static void Error(this ILogger logger, Exception exception, string customMessage)
        {
            logger.Log(new LogEntry(LoggingEventType.Error, customMessage, exception));
        }

        public static void Fatal(this ILogger logger, string message)
        {
            logger.Log(new LogEntry(LoggingEventType.Fatal, message));
        }

        public static void Fatal(this ILogger logger, Exception exception, string customMessage)
        {
            logger.Log(new LogEntry(LoggingEventType.Fatal, customMessage, exception));
        }
    }
}
