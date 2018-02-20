using System;
using System.Reflection;

namespace GoodBearMongoLogger.Logging.Interfaces
{
    internal interface ILogEntryBase
    {
        DateTime TimeStamp { get; set; }
        int ThreadId { get; set; }
        string SourceClass { get; set; }
        string SourceMethod { get; set; }
    }
}
