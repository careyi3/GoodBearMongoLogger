using GoodBearMongoLogger.Logging.Interfaces;

namespace GoodBearMongoLogger.Logging.Impl
{
    internal class AuditLogEntry : AbstractLogEntryBase
    {
        public string Message { get; set; }

        public IAuditEntry AuditEntry { get; set; }
    }
}
