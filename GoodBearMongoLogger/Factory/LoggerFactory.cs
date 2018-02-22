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

namespace GoodBearMongoLogger.Factory
{
    public static class LoggerFactory
    {
        private static IConfigService _configService;
        private static IMongoClient _mongoClient;
        private static Dictionary<string,Tuple<string,string>> _loggerConfigs;
        private static ConnectionManager _connectionManager;
        private static bool _isInited;

        public static void Init(MongoConnection mongoCollection, ICollection<Logger> loggers)
        {
            if (!_isInited)
            {
                try
                {
                    _configService = new ConfigService(mongoCollection, loggers);
                    Config();
                    _isInited = true;
                }
                catch (Exception e)
                {
                    throw new FailedToInitaliseLoggerFactoryException("Failed to initalise LoggerFactory : " + e.Message, e);
                }
            }
        }

        public static void Init(IMongoClient mongoClient, MongoConnection mongoCollection, ICollection<Logger> loggers)
        {
            if (!_isInited)
            {
                try
                {
                    _configService = new ConfigService(mongoCollection, loggers);
                    _mongoClient = mongoClient;
                    Config();
                    _isInited = true;
                }
                catch(Exception e)
                {
                    throw new FailedToInitaliseLoggerFactoryException("Failed to initalise LoggerFactory : "+e.Message,e);
                }
            }
        }

        private static void Config()
        {
            if(_mongoClient != null)
            {
                _connectionManager = new ConnectionManager(_mongoClient);
            }
            else
            {
                IMongoConnection mongoConnection = _configService.MongoLoggerConfig.MongoConnection;
                IMongoConfig mongoConfig = new MongoConfig(mongoConnection);
                _connectionManager = new ConnectionManager(mongoConfig);
            }
            _loggerConfigs = new Dictionary<string, Tuple<string, string>>();
            foreach (var logger in _configService.MongoLoggerConfig.Loggers)
            {
                _loggerConfigs.Add(logger.LoggerName, new Tuple<string, string>(logger.LoggerName, logger.DatabaseName));
            }
        }

        public static ILogger GetLogger(string loggerName)
        {
            if (_isInited)
            {
                IDataAccessService dataAccessService = new DataAccessService(_connectionManager);
                IBsonDocumentBuilderService bsonDocumentBuilderService = new BsonDocumentBuilderService();
                return new Logging.Impl.Logger(dataAccessService, bsonDocumentBuilderService, _loggerConfigs[loggerName].Item2, _loggerConfigs[loggerName].Item1);
            }
            throw new LoggerFactoryNotInitalisedException("LoggerFactory is not initalised. Please call LoggerFactory.Init() before GetLogger().");
        }
    }
}
