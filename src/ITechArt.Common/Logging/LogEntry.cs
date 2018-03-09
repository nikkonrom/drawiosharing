using System;

namespace ITechArt.Common.Logging
{
    public class LogEntry
    {
        private const string argumentNullExceptionMessage = "Log message is null or empty";

        public LoggingEventType LoggingEventType { get; }
        public string Message { get; }
        public Exception Exception { get; }
        

        public LogEntry(LoggingEventType loggingEventType, string message, Exception exception = null)
        {
            if (String.IsNullOrEmpty(message))
            {
                throw new ArgumentNullException(argumentNullExceptionMessage);
            }


            LoggingEventType = loggingEventType;
            Message = message;
            Exception = exception;
        }
    }
}
