using System;
using log4net.Core;

namespace ITechArt.Common.Logging
{
    [UsedImplicitly]
    public class Log4NetLogger : ILogger
    {
        private readonly Type _loggerType;
        private readonly log4net.ILog _nativeLogger;
        

        static Log4NetLogger()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        public Log4NetLogger()
        {
            _loggerType = typeof(Log4NetLogger);
            _nativeLogger = log4net.LogManager.GetLogger(_loggerType);
        }


        public void Log(LogEntry entry)
        {
            var logMessageLevel = ConvertLoggingEventTypeToLevel(entry.LoggingEventType);
            _nativeLogger.Logger.Log(_loggerType, logMessageLevel, entry.Message, entry.Exception);
        }


        private static Level ConvertLoggingEventTypeToLevel(LoggingEventType loggingEventType)
        {
            switch (loggingEventType)
            {
                case LoggingEventType.Debug:
                    {
                        return Level.Debug;
                    }
                case LoggingEventType.Information:
                    {
                        return Level.Info;
                    }
                case LoggingEventType.Warning:
                    {
                        return Level.Warn;
                    }
                case LoggingEventType.Error:
                    {
                        return Level.Error;
                    }
                case LoggingEventType.Fatal:
                    {
                        return Level.Fatal;
                    }
                default:
                    throw new ArgumentOutOfRangeException(nameof(loggingEventType), loggingEventType, "Enum value is out of range");
            }
        }
    }
}