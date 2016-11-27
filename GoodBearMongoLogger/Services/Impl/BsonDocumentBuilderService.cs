using GoodBearMongoLogger.Logging.Impl;
using GoodBearMongoLogger.Services.Interfaces;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace GoodBearMongoLogger.Services.Impl
{
    internal class BsonDocumentBuilderService : IBsonDocumentBuilderService
    {
        public BsonDocument BuildAuditLogEntry(AuditLogEntry logEntry)
        {
            var json = JsonConvert.SerializeObject(logEntry);
            return BsonDocument.Parse(json);
        }

        public BsonDocument BuildEventLogEntry(EventLogEntry logEntry)
        {
            var json = JsonConvert.SerializeObject(logEntry);
            return BsonDocument.Parse(json);
        }

        public BsonDocument BuildLogEntry(LogEntry logEntry)
        {
            var json = JsonConvert.SerializeObject(logEntry);
            return BsonDocument.Parse(json);
        }
    }
}
