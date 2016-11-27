using Autofac;
using GoodBearMongoLogger.Config.Interfaces;
using GoodBearMongoLogger.DataAccess;
using GoodBearMongoLogger.DataAccess.Impl;
using GoodBearMongoLogger.DataAccess.Interfaces;
using GoodBearMongoLogger.Services.Impl;
using GoodBearMongoLogger.Services.Interfaces;
using MongoDB.Driver;

namespace GoodBearMongoLogger.Autofac
{
    public class AutofacModule : Module
    {

        private IConfigService _configService;
        private IMongoClient _mongoClient;

        public AutofacModule()
        {
            _configService = new ConfigService();
        }

        public AutofacModule(IMongoClient mongoClient)
        {
            _configService = new ConfigService();
            _mongoClient = mongoClient;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(x => _configService.MongoLoggerConfig.MongoConnection).As<IMongoConnection>();
            builder.RegisterType<MongoConfig>().As<IMongoConfig>();
            if(_mongoClient != null)
            {
                builder.Register(x => new ConnectionManager(_mongoClient)).As<IConnectionManager>();
            }
            else
            {
                builder.RegisterType<ConnectionManager>().As<IConnectionManager>();
            }
            builder.RegisterType<BsonDocumentBuilderService>().As<IBsonDocumentBuilderService>();
            builder.RegisterType<DataAccessService>().As<IDataAccessService>();

            foreach(var logger in _configService.MongoLoggerConfig.Loggers)
            {
                logger
            }
        }
    }
}
