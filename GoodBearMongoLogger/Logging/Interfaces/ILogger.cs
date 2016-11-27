using System;
using GoodBearMongoLogger.Logging.Enum;

namespace GoodBearMongoLogger.Logging.Interfaces
{
    public interface ILogger
    {
        void Log(LogLevel level, string message, Exception exception);
        void Log(LogLevel level, string message);
        void LogEvent(string message, IEventEntry eventEntry);
        void LogAudit(string message, IAuditEntry auditEntry);

        string LoggerName { get; }

        string DatabaseName { get; }
    }
}
