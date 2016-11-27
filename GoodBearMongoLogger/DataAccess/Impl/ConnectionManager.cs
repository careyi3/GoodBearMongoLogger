using System.Collections.Generic;
using GoodBearMongoLogger.DataAccess.Interfaces;
using MongoDB.Driver;

namespace GoodBearMongoLogger.DataAccess
{
    internal class ConnectionManager : IConnectionManager
    {
        
        private MongoCredential _mongoCredential;
        private ICollection<MongoCredential> _mongoCredentials;
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
            _mongoCredential = MongoCredential.CreateCredential(mongoConfig.AuthDatabase, mongoConfig.Username, mongoConfig.Password);
            _mongoCredentials = new List<MongoCredential>();
            _mongoCredentials.Add(_mongoCredential);
            _mongoClientSettings.Credentials = _mongoCredentials;
            _mongoServerAddress = new MongoServerAddress(mongoConfig.Host, mongoConfig.Port);
            _mongoClientSettings.Server = _mongoServerAddress;
            _mongoClient = new MongoClient(_mongoClientSettings);
        }

        public ConnectionManager(IMongoClient mongoClient)
        {
            _mongoClient = mongoClient;
        }
    }
}
