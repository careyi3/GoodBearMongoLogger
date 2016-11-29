using Autofac;
using Autofac.Core;
using GoodBearMongoLogger.Config.Interfaces;
using GoodBearMongoLogger.DataAccess;
using GoodBearMongoLogger.DataAccess.Impl;
using GoodBearMongoLogger.DataAccess.Interfaces;
using GoodBearMongoLogger.Logging.Impl;
using GoodBearMongoLogger.Logging.Interfaces;
using GoodBearMongoLogger.Services.Impl;
using GoodBearMongoLogger.Services.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;
using System;
using GoodBearMongoLogger.Autofac.Exceptions;

namespace GoodBearMongoLogger.Autofac
{
    public class AutofacModule : Module
    {

        private IConfigService _configService;
        private IMongoClient _mongoClient;

        public AutofacModule()
        {
            try
            {
                _configService = new ConfigService();
            }
            catch(Exception e)
            {
                throw new FailedToCreateLoggerAutofacModuleException("Failed to create instance of logger Autofac Module : " + e.Message,e);
            }
        }

        public AutofacModule(IMongoClient mongoClient)
        {
            try
            {
                _configService = new ConfigService();
                _mongoClient = mongoClient;
            }
            catch(Exception e)
            {
                throw new FailedToCreateLoggerAutofacModuleException("Failed to create instance of logger Autofac Module : " + e.Message, e);
            }
        }

        protected override void Load(ContainerBuilder builder)
        {
            try
            {
                builder.Register(x => _configService.MongoLoggerConfig.MongoConnection).As<IMongoConnection>();
                builder.RegisterType<MongoConfig>().As<IMongoConfig>();
                if (_mongoClient != null)
                {
                    builder.Register(x => new ConnectionManager(_mongoClient)).As<IConnectionManager>().SingleInstance();
                }
                else
                {
                    builder.RegisterType<ConnectionManager>().As<IConnectionManager>().SingleInstance();
                }
                builder.RegisterType<BsonDocumentBuilderService>().As<IBsonDocumentBuilderService>();
                builder.RegisterType<DataAccessService>().As<IDataAccessService>();

                foreach (var logger in _configService.MongoLoggerConfig.Loggers.GetLoggers())
                {
                    IList<Parameter> parameters = new List<Parameter>
                {
                    new NamedParameter("databaseName",logger.DatabaseName),
                    new NamedParameter("loggerName",logger.LoggerName),
                };
                    builder.RegisterType<Logger>().As<ILogger>().Keyed<ILogger>(logger.LoggerName).WithParameters(parameters);
                }
                builder.RegisterType<LoggerWrapper>().As<ILoggerWrapper>();
            }
            catch(Exception e)
            {
                throw new FailedToBuildLoggerAutofacModuleException("Failed to register Logger Autofac module : " + e.Message, e);
            }
        }
    }
}
