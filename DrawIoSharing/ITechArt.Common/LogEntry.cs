using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITechArt.Common
{
    class LogEntry
    {
        public readonly LoggingEventType Severity;
        public readonly string Message;
        public readonly Exception Exception;

        public LogEntry(LoggingEventType severity, string message, Exception exception = null)
    }
}
