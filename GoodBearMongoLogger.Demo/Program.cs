using GoodBearMongoLogger.Factory;
using Microsoft.Practices.ServiceLocation;

namespace GoodBearMongoLogger.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            IoCBootstraper.Init();

            var sample = ServiceLocator.Current.GetInstance<SampleLoggingClass>();

            sample.DoStuff();

            LoggerFactory.Init();

            var sample2 = new AnotherSampleLoggerClass();

            sample2.DoStuff();

        }
    }
}
