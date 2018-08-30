using System;
using System.Reflection;

namespace GoodBearMongoLogger.Logging.Interfaces
{
    internal interface ILogEntryBase
    {
        DateTime TimeStamp { get; set; }
    }
}
