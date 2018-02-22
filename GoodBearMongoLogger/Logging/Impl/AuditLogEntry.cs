using GoodBearMongoLogger.Logging.Interfaces;

namespace GoodBearMongoLogger.Logging.Impl
{
    public class AuditLogEntry : AbstractLogEntryBase
    {
        public string Message { get; set; }

        public IAuditEntry AuditEntry { get; set; }
    }
}
