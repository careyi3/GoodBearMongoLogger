using GoodBearMongoLogger.Logging.Impl;
using MongoDB.Bson;

namespace GoodBearMongoLogger.Services.Interfaces
{
    public interface IBsonDocumentBuilderService
    {
        BsonDocument BuildLogEntry(LogEntry logEntry);
        BsonDocument BuildAuditLogEntry(AuditLogEntry logEntry);
        BsonDocument BuildEventLogEntry(EventLogEntry logEntry);

    }
}
