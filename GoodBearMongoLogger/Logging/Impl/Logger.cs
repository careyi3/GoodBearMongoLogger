using System;
using GoodBearMongoLogger.Logging.Interfaces;
using GoodBearMongoLogger.Logging.Enum;
using GoodBearMongoLogger.Services.Interfaces;

namespace GoodBearMongoLogger.Logging.Impl
{
    internal class Logger : ILogger
    {

        private string _databaseName;
        private string _loggerName;

        private IDataAccessService _dataAccessService;
        private IBsonDocumentBuilderService _bsonDocumentBuilderService; 

        public string LoggerName { get { return _loggerName; } }
   
        public string DatabaseName { get { return _databaseName; } }


        public Logger(IDataAccessService dataAccessService, IBsonDocumentBuilderService bsonDocumentBuilderService, string databaseName, string loggerName)
        {
            _databaseName = databaseName;
            _loggerName = loggerName;
            _dataAccessService = dataAccessService;
            _bsonDocumentBuilderService = bsonDocumentBuilderService;
        }


        public void Log(LogLevel level, string message)
        {
            //TODO: Make this action into a private method and get thread, calling method etc.
            LogEntry entry = new LogEntry { Level = level, Message = message };

            var document = _bsonDocumentBuilderService.BuildLogEntry(entry);
            _dataAccessService.Save(document, _databaseName, _loggerName);
        }

        public void Log(LogLevel level, string message, Exception exception)
        {
            //TODO: Make this action into a private method and get thread, calling method etc.
            LogEntry entry = new LogEntry { Level = level, Message = message, Exception = exception};

            var document = _bsonDocumentBuilderService.BuildLogEntry(entry);
            _dataAccessService.Save(document, _databaseName, _loggerName);
        }

        public void LogEvent(string message, IEventEntry eventEntry)
        {
            //TODO: Make this action into a private method and get thread, calling method etc.
            EventLogEntry entry = new EventLogEntry { Message = message, EventEntry = eventEntry };

            var document = _bsonDocumentBuilderService.BuildEventLogEntry(entry);
            _dataAccessService.Save(document, _databaseName, _loggerName);
        }

        public void LogAudit(string message, IAuditEntry auditEntry)
        {
            //TODO: Make this action into a private method and get thread, calling method etc.
            AuditLogEntry entry = new AuditLogEntry { Message = message, AuditEntry = auditEntry };

            var document = _bsonDocumentBuilderService.BuildAuditLogEntry(entry);
            _dataAccessService.Save(document, _databaseName, _loggerName);
        }
    }
}
