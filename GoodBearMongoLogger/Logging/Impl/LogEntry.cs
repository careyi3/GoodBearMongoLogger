using GoodBearMongoLogger.Logging.Enum;
using GoodBearMongoLogger.Logging.Interfaces;
using System;

namespace GoodBearMongoLogger.Logging.Impl
{
    public class LogEntry : AbstractLogEntryBase
    {
        public string Level {get; set;}
        public string Exception { get; set; }
        public string Message { get; set; }
    }
}
