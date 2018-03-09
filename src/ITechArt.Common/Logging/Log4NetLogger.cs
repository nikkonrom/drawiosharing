using System;
using log4net.Core;

namespace ITechArt.Common.Logging
{
    public class Log4NetLogger : ILogger
    {
        private readonly log4net.ILog _nativeLogger;

        private readonly Type _loggerType = typeof(Log4NetLogger);


        static Log4NetLogger()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        public Log4NetLogger()
        {
            _nativeLogger = log4net.LogManager.GetLogger(_loggerType);
        }


        public void Log(LogEntry entry)
        {
            var logMessageLevel = ConvertLoggingEventTypeToLevel(entry.LoggingEventType);
            _nativeLogger.Logger.Log(_loggerType, logMessageLevel, entry.Message, entry.Exception);
        }

        private Level ConvertLoggingEventTypeToLevel(LoggingEventType loggingEventType)
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
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}