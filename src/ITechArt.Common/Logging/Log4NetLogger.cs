using System;
using log4net.Core;

namespace ITechArt.Common.Logging
{
    public class Log4NetLogger : ILogger
    {
        private readonly log4net.ILog _nativeLogger;
        private readonly Type loggerType = typeof(Log4NetLogger);
        public Log4NetLogger()
        {
            _nativeLogger = log4net.LogManager.GetLogger(loggerType);
            log4net.Config.XmlConfigurator.Configure();
        }


        public void Log(LogEntry entry)
        {
            switch (entry.LoggingEventType)
            {
                case LoggingEventType.Debug:
                    {
                        _nativeLogger.Logger.Log(loggerType, Level.Debug, entry.Message, entry.Exception);
                        break;
                    }
                case LoggingEventType.Information:
                    {
                        _nativeLogger.Logger.Log(loggerType, Level.Info, entry.Message, entry.Exception);
                        break;
                    }
                case LoggingEventType.Warning:
                    {
                        _nativeLogger.Logger.Log(loggerType, Level.Warn, entry.Message, entry.Exception);
                        break;
                    }
                case LoggingEventType.Error:
                    {
                        _nativeLogger.Logger.Log(loggerType, Level.Error, entry.Message, entry.Exception);
                        break;
                    }
                case LoggingEventType.Fatal:
                    {
                        _nativeLogger.Logger.Log(loggerType, Level.Fatal, entry.Message, entry.Exception);
                        break;
                    }
            }
        }
    }
}
