using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using GoodBearMongoLogger.Autofac;
using Microsoft.Practices.ServiceLocation;
using Autofac.Extras.CommonServiceLocator;

namespace GoodBearMongoLogger.Demo
{
    class IoCBootstraper
    {
        public static void Init()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new AutofacModule());

            builder.RegisterType<SampleLoggingClass>().AsSelf();

            var container = builder.Build();
            var cls = new AutofacServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => cls);
        }
    }
}
