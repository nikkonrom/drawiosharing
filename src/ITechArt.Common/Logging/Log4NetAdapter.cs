using ITechArt.Common.Logging;

namespace ITechArt.Common.Logging
{
    public class Log4NetAdapter : ILogger
    {
        private readonly log4net.ILog _adapter;

        public Log4NetAdapter()
        {
            _adapter = log4net.LogManager.GetLogger(typeof(Log4NetAdapter));
            log4net.Config.XmlConfigurator.Configure();
        }


        public void Log(LogEntry entry)
        {
            switch (entry.Severity)
            {
                case LoggingEventType.Debug:
                    {
                        if (entry.Exception != null)
                            _adapter.Debug(entry.Message, entry.Exception);
                        else
                            _adapter.Debug(entry.Message);

                        break;
                    }

                case LoggingEventType.Information:
                    {
                        if (entry.Exception != null)
                            _adapter.Info(entry.Message, entry.Exception);
                        else
                            _adapter.Info(entry.Message);

                        break;
                    }
                case LoggingEventType.Warning:
                    {
                        if (entry.Exception != null)
                            _adapter.Warn(entry.Message, entry.Exception);
                        else
                            _adapter.Warn(entry.Message);

                        break;
                    }
                case LoggingEventType.Error:
                    {
                        if (entry.Exception != null)
                            _adapter.Error(entry.Message, entry.Exception);
                        else
                            _adapter.Error(entry.Message);

                        break;
                    }
                case LoggingEventType.Fatal:
                    {
                        if (entry.Exception != null)
                            _adapter.Fatal(entry.Message, entry.Exception);
                        else
                            _adapter.Fatal(entry.Message);

                        break;
                    }
            }
        }
    }
}
