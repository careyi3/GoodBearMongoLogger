using System;
using GoodBearMongoLogger.Logging.Interfaces;
using GoodBearMongoLogger.Logging.Enum;

namespace GoodBearMongoLogger.Logging.Impl
{
    internal class Logger : ILogger
    {
        public void Log(LogLevel level, string message)
        {
            throw new NotImplementedException();
        }

        public void Log(LogLevel level, string message, Exception exception)
        {
            throw new NotImplementedException();
        }

        public void LogEvent(string message, IEventEntry eventEntry)
        {
            throw new NotImplementedException();
        }

        public void LogAudit(string message, IAuditEntry auditEntry)
        {
            throw new NotImplementedException();
        }
    }
}
