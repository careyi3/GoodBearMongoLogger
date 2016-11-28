using GoodBearMongoLogger.Logging.Enum;
using GoodBearMongoLogger.Logging.Interfaces;
using System;

namespace GoodBearMongoLogger.Logging.Impl
{
    internal class LogEntry : AbstractLogEntryBase
    {
        public LogLevel Level {get; set;}
        public Exception Exception { get; set; }
        public string Message { get; set; }
    }
}
