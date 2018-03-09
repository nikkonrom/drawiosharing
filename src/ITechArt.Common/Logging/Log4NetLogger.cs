namespace ITechArt.Common.Logging
{
    public class Log4NetLogger : ILogger
    {
        private readonly log4net.ILog _nativeLogger;

        public Log4NetLogger()
        {
            _nativeLogger = log4net.LogManager.GetLogger(typeof(Log4NetLogger));
            log4net.Config.XmlConfigurator.Configure();
        }


        public void Log(LogEntry entry)
        {
            switch (entry.LoggingEventType)
            {
                case LoggingEventType.Debug:
                    {
                        if (entry.Exception != null)
                            _nativeLogger.Debug(entry.Message, entry.Exception);
                        else
                            _nativeLogger.Debug(entry.Message);

                        break;
                    }

                case LoggingEventType.Information:
                    {
                        if (entry.Exception != null)
                            _nativeLogger.Info(entry.Message, entry.Exception);
                        else
                            _nativeLogger.Info(entry.Message);

                        break;
                    }
                case LoggingEventType.Warning:
                    {
                        if (entry.Exception != null)
                            _nativeLogger.Warn(entry.Message, entry.Exception);
                        else
                            _nativeLogger.Warn(entry.Message);

                        break;
                    }
                case LoggingEventType.Error:
                    {
                        if (entry.Exception != null)
                            _nativeLogger.Error(entry.Message, entry.Exception);
                        else
                            _nativeLogger.Error(entry.Message);

                        break;
                    }
                case LoggingEventType.Fatal:
                    {
                        if (entry.Exception != null)
                            _nativeLogger.Fatal(entry.Message, entry.Exception);
                        else
                            _nativeLogger.Fatal(entry.Message);

                        break;
                    }
            }
        }
    }
}
