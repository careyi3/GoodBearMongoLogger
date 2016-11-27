using GoodBearMongoLogger.Services.Impl;
using Microsoft.Practices.ServiceLocation;

namespace GoodBearMongoLogger.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            IoCBootstraper.Init();

            var sample = ServiceLocator.Current.GetInstance<SampleLoggingClass>();

        }
    }
}
