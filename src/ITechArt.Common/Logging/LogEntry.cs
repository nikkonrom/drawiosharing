using System;

namespace ITechArt.Common.Logging
{
    public class LogEntry
    {
        private const string argumentNullExceptionMessage = "Log message is null or empty";

        public LoggingEventType Severity { get; }
        public string Message { get; }
        public Exception Exception { get; }
        

        public LogEntry(LoggingEventType severity, string message, Exception exception = null)
        {
            if (String.IsNullOrEmpty(message))
            {
                throw new ArgumentNullException(argumentNullExceptionMessage);
            }


            Severity = severity;
            Message = message;
            Exception = exception;
        }
    }
}
