using System;
using GoodBearMongoLogger.Exceptions;
using GoodBearMongoLogger.Services.Interfaces;
using GoodBearMongoLogger.Config.Impl;

namespace GoodBearMongoLogger.Services.Impl
{
    internal public class ConfigService : IConfigService
    {
        private MongoLogger _mongoLogger;
        
        public MongoLogger MongoLoggerConfig
        {
            get
            {
                return _mongoLogger;
            }
        }

        public ConfigService()
        {
            var sectionName = "mongoLogger";
            _mongoLogger = GetConfig(sectionName);
        }

        public ConfigService(string sectionName)
        {
            _mongoLogger = GetConfig(sectionName);
        }
        
        private MongoLogger GetConfig(string sectionName)
        {
            try
            {
                return (MongoLogger)System.Configuration.ConfigurationManager.GetSection(sectionName);
            }
            catch (Exception e)
            {
                throw new InvalidMongoLoggerConfigurationException("Invalid logger configuration for '"+ sectionName + "': " + e.Message, e);
            }
        }

    }
}
