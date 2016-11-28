using GoodBearMongoLogger.DataAccess.Interfaces;
using GoodBearMongoLogger.Exceptions;
using GoodBearMongoLogger.Services.Interfaces;
using MongoDB.Bson;
using System;
using System.Threading.Tasks;

namespace GoodBearMongoLogger.Services.Impl
{
    internal class DataAccessService : IDataAccessService
    {
        private IConnectionManager _connectionManager;
        public DataAccessService(IConnectionManager connectionManager)
        {
            _connectionManager = connectionManager;
        }

        public void Save(BsonDocument data, string targetDatabase, string targetCollection)
        {
            try
            {
                var db = _connectionManager.MongoClient.GetDatabase(targetDatabase);

                var collection = db.GetCollection<BsonDocument>(targetCollection);

                collection.InsertOne(data);
            }
            catch(Exception e)
            {
                throw new MongoPersistanceException("Failed to persist log to MongoDb instance : "+e.Message,e);
            }
        }

    }
}
