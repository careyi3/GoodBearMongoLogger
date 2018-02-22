using System;
using System.Collections.Generic;
using GoodBearMongoLogger.Exceptions;
using GoodBearMongoLogger.Services.Interfaces;
using GoodBearMongoLogger.Config.Impl;

namespace GoodBearMongoLogger.Services.Impl
{
    public class ConfigService : IConfigService
    {
        private MongoLogger _mongoLogger;
        private MongoConnection _mongoConnection;
        private ICollection<Logger> _loggers;
        
        public ConfigService(MongoConnection mongoCollection, ICollection<Logger> loggers)
        {
            _mongoConnection = mongoCollection;
            _loggers = loggers;
        }

        public MongoLogger MongoLoggerConfig
        {
            get
            {
                if(_mongoLogger == null)
                {
                    _mongoLogger = new MongoLogger(_mongoConnection, _loggers);
                }
                return _mongoLogger;
            }
        }
        
        private MongoLogger GetConfig(string loggerName)
        {
            try
            {
                return new MongoLogger(_mongoConnection, _loggers);
            }
            catch (Exception e)
            {
                throw new InvalidMongoLoggerConfigurationException("No logger configured for '"+ loggerName + "': " + e.Message, e);
            }
        }

    }
}
