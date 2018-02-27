using GoodBearMongoLogger.Config.Interfaces;
using GoodBearMongoLogger.DataAccess;
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

        public static void Init(MongoConnection mongoConnection, ICollection<LoggerConfig> loggerConfigs)
        {
            if (!_isInited)
            {
                try
                {
                    _loggerConfigs = loggerConfigs;
                    IMongoConfig mongoConfig = new MongoConfig(mongoConnection);
                    _connectionManager = new ConnectionManager(mongoConfig);
                    _isInited = true;
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
                    _loggerConfigs = loggerConfigs;
                    _connectionManager = new ConnectionManager(mongoClient);
                    _isInited = true;
                }
                catch(Exception e)
                {
                    throw new FailedToInitaliseLoggerFactoryException("Failed to initalise LoggerFactory : "+e.Message,e);
                }
            }
        }

        public static ILogger GetLogger(string loggerName)
        {
            if (_isInited)
            {
                IDataAccessService dataAccessService = new DataAccessService(_connectionManager);
                IBsonDocumentBuilderService bsonDocumentBuilderService = new BsonDocumentBuilderService();
                var logger = _loggerConfigs.First(x => x.LoggerName == loggerName);
                if (loggerName == null)
                {
                    throw new InvalidMongoLoggerConfigurationException($"No logger found with name {loggerName}.");
                }
                return new Logger(dataAccessService, bsonDocumentBuilderService, logger.DatabaseName, logger.LoggerName);
            }
            throw new LoggerFactoryNotInitalisedException("LoggerFactory is not initalised. Please call LoggerFactory.Init() before GetLogger().");
        }
    }
}
