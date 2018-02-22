using System;
using System.Threading.Tasks;
using GoodBearMongoLogger.Logging.Enum;

namespace GoodBearMongoLogger.Logging.Interfaces
{
    public interface ILogger
    {
        Task LogAsync(LogLevel level, string message, Exception exception);
        Task LogAsync(LogLevel level, string message);
        Task LogEventAsync(string message, IEventEntry eventEntry);
        Task LogAuditAsync(string message, IAuditEntry auditEntry);

        string LoggerName { get; }

        string DatabaseName { get; }
    }
}
