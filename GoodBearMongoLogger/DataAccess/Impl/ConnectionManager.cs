﻿using System.Collections.Generic;
using GoodBearMongoLogger.DataAccess.Interfaces;
using MongoDB.Driver;
using System;
using GoodBearMongoLogger.Exceptions;

namespace GoodBearMongoLogger.DataAccess
{
    public class ConnectionManager : IConnectionManager
    {
        
        private MongoCredential _mongoCredential;
        private MongoClientSettings _mongoClientSettings;
        private IMongoClient _mongoClient;
        private MongoServerAddress _mongoServerAddress;

        public IMongoClient MongoClient
        {
            get
            {
                return _mongoClient;
            }
        }

        public ConnectionManager(IMongoConfig mongoConfig)
        {
            try
            { 
                _mongoCredential = MongoCredential.CreateCredential(mongoConfig.AuthDatabase, mongoConfig.Username, mongoConfig.Password);
                _mongoClientSettings = new MongoClientSettings();
                _mongoClientSettings.Credential = _mongoCredential;
                _mongoServerAddress = new MongoServerAddress(mongoConfig.Host, mongoConfig.Port);
                _mongoClientSettings.Server = _mongoServerAddress;
                _mongoClientSettings.UseSsl = true; 
                _mongoClient = new MongoClient(_mongoClientSettings);
            }
            catch (Exception e)
            {
                throw new InvalidMongoDBConfigurationException("Failed to configure MongoDB connection : "+e.Message,e);
            }
        }

        public ConnectionManager(IMongoClient mongoClient)
        {
            _mongoClient = mongoClient;
        }
    }
}
