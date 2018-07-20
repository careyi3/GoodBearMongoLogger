using GoodBearMongoLogger.Config.Interfaces;
using System;

namespace GoodBearMongoLogger.COnfig.Impl
{
    public class MongoConfig : IMongoConfig
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string AuthDatabase { get; set; }

        public string Host { get; set; }

        public int Port { get; set; }
    }
}
