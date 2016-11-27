using Autofac;
using GoodBearMongoLogger.Services.Impl;
using GoodBearMongoLogger.Services.Interfaces;

namespace GoodBearMongoLogger.Autofac
{
    public class AutofacModule : Module
    {

        private IConfigService _configService;

        public AutofacModule()
        {
            _configService = new ConfigService();
        }

        protected override void Load(ContainerBuilder builder)
        {
             
        }
    }
}
