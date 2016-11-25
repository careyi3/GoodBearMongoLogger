using System;
using System.Reflection;

namespace GoodBearMongoLogger.Logging.Impl
{
    internal class LogEntryBase
    {
        public DateTime TimeStamp { get; set; }

        public int ThreadId { get; set; }

        public Type SourceClass { get; set; }

        public MethodInfo SourceMethod { get; set; }

    }
}
