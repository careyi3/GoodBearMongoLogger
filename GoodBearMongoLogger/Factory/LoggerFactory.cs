using GoodBearMongoLogger.Config.Interfaces;
using GoodBearMongoLogger.DataAccess;
using GoodBearMongoLogger.DataAccess.Impl;
using GoodBearMongoLogger.DataAccess.Interfaces;
using GoodBearMongoLogger.Logging.Interfaces;
using GoodBearMongoLogger.Services.Impl;
using GoodBearMongoLogger.Services.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace GoodBearMongoLogger.Factory
{
    public static class LoggerFactory
    {
        private static IConfigService _configService;
        private static IMongoClient _mongoClient;
        private static Dictionary<string,Tuple<string,string>> _loggerConfigs;
        private static ConnectionManager _connectionManager;

        public static void Init()
        {
            _configService = new ConfigService();
            Config();
        }

        public static void Init(IMongoClient mongoClient)
        {
            _configService = new ConfigService();
            _mongoClient = mongoClient;
            Config();
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
            foreach (var logger in _configService.MongoLoggerConfig.Loggers.GetLoggers())
            {
                _loggerConfigs.Add(logger.LoggerName, new Tuple<string, string>(logger.LoggerName, logger.DatabaseName));
            }
        }

        public static ILogger GetLogger(string loggerName)
        {
            IDataAccessService dataAccessService = new DataAccessService(_connectionManager);
            IBsonDocumentBuilderService bsonDocumentBuilderService = new BsonDocumentBuilderService();
            return new Logging.Impl.Logger(dataAccessService,bsonDocumentBuilderService,_loggerConfigs[loggerName].Item2, _loggerConfigs[loggerName].Item1);
        }
    }
}
