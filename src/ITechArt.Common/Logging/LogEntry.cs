using System;

namespace ITechArt.Common.Logging
{
    public class LogEntry
    {
        public LoggingEventType LoggingEventType { get; }
        public string Message { get; }
        public Exception Exception { get; }

        private const string ArgumentNullExceptionMessage = "Log message is null or empty";


        public LogEntry(LoggingEventType loggingEventType, string message, Exception exception = null)
        {
            if (String.IsNullOrEmpty(message))
            {
                throw new ArgumentNullException(ArgumentNullExceptionMessage);
            }
            
            LoggingEventType = loggingEventType;
            Message = message;
            Exception = exception;
        }
    }
}
