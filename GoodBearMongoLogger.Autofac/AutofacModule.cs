using Autofac;
using Autofac.Core;
using GoodBearMongoLogger.Config.Interfaces;
using GoodBearMongoLogger.Config.Impl;
using GoodBearMongoLogger.DataAccess;
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
        private IMongoClient _mongoClient;
        private ICollection<LoggerConfig> _loggerConfigs;
        private IMongoConfig _mongoConfig;

        public AutofacModule(IMongoConfig mongoConfig, ICollection<LoggerConfig> loggerConfigs)
        {
            try
            {
                _loggerConfigs = loggerConfigs;
                _mongoConfig = mongoConfig;
            }
            catch(Exception e)
            {
                throw new FailedToCreateLoggerAutofacModuleException("Failed to create instance of logger Autofac Module : " + e.Message,e);
            }
        }

        public AutofacModule(IMongoClient mongoClient, ICollection<LoggerConfig> loggerConfigs)
        {
            try
            {
                _loggerConfigs = loggerConfigs;
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
                builder.Register(x => _mongoConfig).As<IMongoConfig>();
                if (_mongoClient != null)
                {
                    builder.Register(x => new ConnectionManager(_mongoClient)).As<IConnectionManager>().SingleInstance();
                }
                else
                {
                    builder.RegisterType<ConnectionManager>().As<IConnectionManager>().SingleInstance();
                }
                builder.RegisterType<BsonDocumentBuilderService>().As<IBsonDocumentBuilderService>().InstancePerLifetimeScope();
                builder.RegisterType<DataAccessService>().As<IDataAccessService>().InstancePerLifetimeScope();

                foreach (var logger in _loggerConfigs)
                {
                    IList<Parameter> parameters = new List<Parameter>
                    {
                        new NamedParameter("databaseName", logger.DatabaseName),
                        new NamedParameter("loggerName", logger.LoggerName),
                    };
                    builder.RegisterType<Logger>().As<ILogger>().Keyed<ILogger>(logger.LoggerName).WithParameters(parameters).InstancePerLifetimeScope();
                }
                builder.RegisterType<LoggerWrapper>().As<ILoggerWrapper>().InstancePerLifetimeScope();
            }
            catch(Exception e)
            {
                throw new FailedToBuildLoggerAutofacModuleException("Failed to register Logger Autofac module : " + e.Message, e);
            }
        }
    }
}
