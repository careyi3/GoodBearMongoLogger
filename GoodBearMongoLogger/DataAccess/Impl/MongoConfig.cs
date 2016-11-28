using GoodBearMongoLogger.Config.Interfaces;
using GoodBearMongoLogger.DataAccess.Interfaces;
using System;

namespace GoodBearMongoLogger.DataAccess.Impl
{
    internal class MongoConfig : IMongoConfig
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string AuthDatabase { get; set; }

        public string Host { get; set; }

        public int Port { get; set; }

        public MongoConfig(IMongoConnection mongoConfig)
        {
            Username = mongoConfig.Username;
            Password = mongoConfig.Password;
            AuthDatabase = mongoConfig.AuthDatabase;
            Host = mongoConfig.Host;
            Port = mongoConfig.Port;
        }
    }
}
