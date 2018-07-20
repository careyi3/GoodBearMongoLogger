using GoodBearMongoLogger.Config.Interfaces;
using GoodBearMongoLogger.DataAccess.Impl;
using GoodBearMongoLogger.DataAccess.Interfaces;
using GoodBearMongoLogger.Exceptions;
using GoodBearMongoLogger.Logging.Interfaces;
using GoodBearMongoLogger.Services.Impl;
using GoodBearMongoLogger.Services.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using GoodBearMongoLogger.Config.Impl;
using GoodBearMongoLogger.Logging.Impl;
using System.Linq;

namespace GoodBearMongoLogger.Factory
{
    public static class LoggerFactory
    {
        private static ICollection<LoggerConfig> _loggerConfigs;
        private static ConnectionManager _connectionManager;
        private static bool _isInited;
        private static ICollection<Logger> _loggers;

        public static void Init(IMongoConfig mongoConfig, ICollection<LoggerConfig> loggerConfigs)
        {
            if (!_isInited)
            {
                try
                {
                    InitCommon(loggerConfigs);
                    _connectionManager = new ConnectionManager(mongoConfig);
                }
                catch (Exception e)
                {
                    throw new FailedToInitaliseLoggerFactoryException("Failed to initalise LoggerFactory : " + e.Message, e);
                }
            }
        }

        public static void Init(IMongoClient mongoClient, ICollection<LoggerConfig> loggerConfigs)
        {
            if (!_isInited)
            {
                try
                {
                    InitCommon(loggerConfigs);
                    _connectionManager = new ConnectionManager(mongoClient);
                }
                catch(Exception e)
                {
                    throw new FailedToInitaliseLoggerFactoryException("Failed to initalise LoggerFactory : " + e.Message,e);
                }
            }
        }

        public static ILogger GetLogger(string loggerName)
        {
            if (_isInited)
            {
                var logger = FindLoggerByName(loggerName);
                if (logger == null)
                {
                    var loggerConfig = GetLoggerConfig(loggerName);
                    _loggers.Add(BuildLogger(loggerConfig));
                    return FindLoggerByName(loggerName);
                }
                return logger;
            }
            throw new LoggerFactoryNotInitalisedException("LoggerFactory is not initalised. Please call LoggerFactory.Init() before GetLogger().");
        }

        private static void InitCommon(ICollection<LoggerConfig> loggerConfigs)
        {
            _loggerConfigs = loggerConfigs;
            _loggers = new List<Logger>();
            _isInited = true;
        }

        private static LoggerConfig GetLoggerConfig(string loggerName)
        {
            var loggerConfig = _loggerConfigs.FirstOrDefault(x => x.LoggerName == loggerName);
            if (loggerName == null)
            {
                throw new InvalidMongoLoggerConfigurationException($"No logger found with name {loggerName}.");
            }
            return loggerConfig;
        }

        private static Logger FindLoggerByName(string loggerName)
        {
            return _loggers.FirstOrDefault(x => x.LoggerName == loggerName);
        }

        private static Logger BuildLogger(LoggerConfig loggerConfig)
        {
            IDataAccessService dataAccessService = new DataAccessService(_connectionManager);
            IBsonDocumentBuilderService bsonDocumentBuilderService = new BsonDocumentBuilderService();
            return new Logger(dataAccessService, bsonDocumentBuilderService, loggerConfig.DatabaseName, loggerConfig.LoggerName);
        }
    }
}
