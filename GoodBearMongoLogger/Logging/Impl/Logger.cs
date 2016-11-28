using System;
using GoodBearMongoLogger.Logging.Interfaces;
using GoodBearMongoLogger.Logging.Enum;
using GoodBearMongoLogger.Services.Interfaces;
using GoodBearMongoLogger.Exceptions;
using System.Threading;
using System.Diagnostics;

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
            try
            {
                LogEntry entry = new LogEntry { Level = level, Message = message };
                SetLogEntryCommonProperties(entry);
                var document = _bsonDocumentBuilderService.BuildLogEntry(entry);
                _dataAccessService.Save(document, _databaseName, _loggerName);
            }
            catch (Exception e)
            {
                throw new FailedToLogException("Failed to log : " + e.Message, e);
            }
        }

        public void Log(LogLevel level, string message, Exception exception)
        {
            try
            {
                LogEntry entry = new LogEntry { Level = level, Message = message, Exception = exception};
                SetLogEntryCommonProperties(entry);
                var document = _bsonDocumentBuilderService.BuildLogEntry(entry);
                _dataAccessService.Save(document, _databaseName, _loggerName);
            }
            catch (Exception e)
            {
                throw new FailedToLogException("Failed to log : " + e.Message, e);
            }
}

        public void LogEvent(string message, IEventEntry eventEntry)
        {
            try
            {
                EventLogEntry entry = new EventLogEntry { Message = message, EventEntry = eventEntry };
                SetLogEntryCommonProperties(entry);
                var document = _bsonDocumentBuilderService.BuildEventLogEntry(entry);
                _dataAccessService.Save(document, _databaseName, _loggerName);
            }
            catch (Exception e)
            {
                throw new FailedToLogException("Failed to log : " + e.Message, e);
            }
        }

        public void LogAudit(string message, IAuditEntry auditEntry)
        {
            try
            {
                AuditLogEntry entry = new AuditLogEntry { Message = message, AuditEntry = auditEntry };
                SetLogEntryCommonProperties(entry);
                var document = _bsonDocumentBuilderService.BuildAuditLogEntry(entry);
                _dataAccessService.Save(document, _databaseName, _loggerName);
            }
            catch (Exception e)
            {
                throw new FailedToLogException("Failed to log : "+e.Message,e);
            }
        }

        private void SetLogEntryCommonProperties(ILogEntryBase logEntryBase)
        {
            logEntryBase.ThreadId = Thread.CurrentThread.ManagedThreadId;
            logEntryBase.TimeStamp = DateTime.Now;
            logEntryBase.SourceMethod = new StackTrace().GetFrame(2).GetMethod();
            logEntryBase.SourceClass = logEntryBase.SourceMethod.ReflectedType;
        }
    }
}
