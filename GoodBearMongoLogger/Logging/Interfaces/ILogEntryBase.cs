using System;
using System.Reflection;

namespace GoodBearMongoLogger.Logging.Interfaces
{
    internal interface ILogEntryBase
    {
        DateTime TimeStamp { get; set; }
        int ThreadId { get; set; }
        Type SourceClass { get; set; }
        MethodBase SourceMethod { get; set; }
    }
}
