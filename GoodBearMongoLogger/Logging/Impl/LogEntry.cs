using GoodBearMongoLogger.Logging.Enum;
using System;

namespace GoodBearMongoLogger.Logging.Impl
{
    internal class LogEntry : LogEntryBase
    {
        public LogLevel Level {get; set;}
        public Exception Exception { get; set; }
        public string Message { get; set; }
    }
}
