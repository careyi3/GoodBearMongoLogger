using GoodBearMongoLogger.Logging.Interfaces;
using System;
using System.Reflection;


namespace GoodBearMongoLogger.Logging.Impl
{
    public abstract class AbstractLogEntryBase : ILogEntryBase
    {
        public DateTime TimeStamp { get; set; }

        public int ThreadId { get; set; }

        public string SourceClass { get; set; }

        public string SourceMethod { get; set; }

    }
}
