using GoodBearMongoLogger.Logging.Interfaces;
using System;
using System.Reflection;


namespace GoodBearMongoLogger.Logging.Impl
{
    internal abstract class AbstractLogEntryBase : ILogEntryBase
    {
        public DateTime TimeStamp { get; set; }

        public int ThreadId { get; set; }

        public Type SourceClass { get; set; }

        public MethodBase SourceMethod { get; set; }

    }
}
