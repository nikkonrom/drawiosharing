using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;

namespace ITechArt.Common
{
    public class Log4NetAdapter : ILogger
    {
        private readonly log4net.ILog _adapter;

        public Log4NetAdapter()
        {
            _adapter = log4net.LogManager.GetLogger("Logger");
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
