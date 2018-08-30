using System;
using GoodBearMongoLogger.Logging.Interfaces;
using GoodBearMongoLogger.Logging.Enum;
using GoodBearMongoLogger.Services.Interfaces;
using GoodBearMongoLogger.Exceptions;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;

namespace GoodBearMongoLogger.Logging.Impl
{
    public class Logger : ILogger
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


        public async Task LogAsync(LogLevel level, string message)
        {
            try
            {
                LogEntry entry = new LogEntry { Level = level.ToString(), Message = message };
                SetLogEntryTimeStamp(entry);
                var document = _bsonDocumentBuilderService.BuildLogEntry(entry);
                await _dataAccessService.SaveAsync(document, _databaseName, _loggerName);
            }
            catch (Exception e)
            {
                throw new FailedToLogException("Failed to log : " + e.Message, e);
            }
        }

        public async Task LogAsync(LogLevel level, string message, Exception exception)
        {
            try
            {
                LogEntry entry = new LogEntry { Level = level.ToString(), Message = message, Exception = exception.Message };
                SetLogEntryTimeStamp(entry);
                var document = _bsonDocumentBuilderService.BuildLogEntry(entry);
                await _dataAccessService.SaveAsync(document, _databaseName, _loggerName);
            }
            catch (Exception e)
            {
                throw new FailedToLogException("Failed to log : " + e.Message, e);
            }
        }

        public async Task LogEventAsync(string message, IEventEntry eventEntry)
        {
            try
            {
                EventLogEntry entry = new EventLogEntry { Message = message, EventEntry = eventEntry };
                SetLogEntryTimeStamp(entry);
                var document = _bsonDocumentBuilderService.BuildEventLogEntry(entry);
                await _dataAccessService.SaveAsync(document, _databaseName, _loggerName);
            }
            catch (Exception e)
            {
                throw new FailedToLogException("Failed to log : " + e.Message, e);
            }
        }

        public async Task LogAuditAsync(string message, IAuditEntry auditEntry)
        {
            try
            {
                AuditLogEntry entry = new AuditLogEntry { Message = message, AuditEntry = auditEntry };
                SetLogEntryTimeStamp(entry);
                var document = _bsonDocumentBuilderService.BuildAuditLogEntry(entry);
                await _dataAccessService.SaveAsync(document, _databaseName, _loggerName);
            }
            catch (Exception e)
            {
                throw new FailedToLogException("Failed to log : "+e.Message,e);
            }
        }

        private void SetLogEntryTimeStamp(ILogEntryBase logEntryBase)
        {
            logEntryBase.TimeStamp = DateTime.UtcNow;
        }
    }
}
