using System;
using GoodBearMongoLogger.Logging.Impl;
using GoodBearMongoLogger.Services.Interfaces;
using MongoDB.Bson;

namespace GoodBearMongoLogger.Services.Impl
{
    internal class BsonDocumentBuilderService : IBsonDocumentBuilderService
    {
        public BsonDocument BuildAuditLogEntry(AuditLogEntry logEntry)
        {
            throw new NotImplementedException();
        }

        public BsonDocument BuildEventLogEntry(EventLogEntry logEntry)
        {
            throw new NotImplementedException();
        }

        public BsonDocument BuildLogEntry(LogEntry logEntry)
        {
            throw new NotImplementedException();
        }
    }
}
