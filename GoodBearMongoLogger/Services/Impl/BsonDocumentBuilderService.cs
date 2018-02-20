using GoodBearMongoLogger.Logging.Impl;
using GoodBearMongoLogger.Services.Interfaces;
using MongoDB.Bson;
using Newtonsoft.Json;
using System;

namespace GoodBearMongoLogger.Services.Impl
{
    public class BsonDocumentBuilderService : IBsonDocumentBuilderService
    {
        public BsonDocument BuildAuditLogEntry(AuditLogEntry logEntry)
        {
            var json = JsonConvert.SerializeObject(logEntry, Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return BsonDocument.Parse(json);
        }

        public BsonDocument BuildEventLogEntry(EventLogEntry logEntry)
        {
            var json = JsonConvert.SerializeObject(logEntry, Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return BsonDocument.Parse(json);
        }

        public BsonDocument BuildLogEntry(LogEntry logEntry)
        {
            var json = JsonConvert.SerializeObject(logEntry, Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return BsonDocument.Parse(json);
        }
    }
}
