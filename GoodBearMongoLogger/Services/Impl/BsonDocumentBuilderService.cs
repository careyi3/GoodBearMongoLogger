using GoodBearMongoLogger.Logging.Impl;
using GoodBearMongoLogger.Logging.Interfaces;
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
            var bson = BsonDocument.Parse(json);
            return OverrideDateTime(bson, logEntry);
        }

        public BsonDocument BuildEventLogEntry(EventLogEntry logEntry)
        {
            var json = JsonConvert.SerializeObject(logEntry, Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            var bson = BsonDocument.Parse(json);
            return OverrideDateTime(bson, logEntry);
        }

        public BsonDocument BuildLogEntry(LogEntry logEntry)
        {
            var json = JsonConvert.SerializeObject(logEntry, Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            var bson = BsonDocument.Parse(json);
            return OverrideDateTime(bson, logEntry);
        }

        private BsonDocument OverrideDateTime(BsonDocument bson, ILogEntryBase logEntry)
        {
            bson["TimeStamp"] = logEntry.TimeStamp;
            return bson;
        }

    }
}
