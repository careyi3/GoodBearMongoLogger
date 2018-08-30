using GoodBearMongoLogger.Logging.Interfaces;
using System;
using System.Reflection;


namespace GoodBearMongoLogger.Logging.Impl
{
    public abstract class AbstractLogEntryBase : ILogEntryBase
    {
        public DateTime TimeStamp { get; set; }

    }
}
