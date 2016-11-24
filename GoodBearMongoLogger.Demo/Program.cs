using GoodBearMongoLogger.Services.Impl;

namespace GoodBearMongoLogger.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var configService = new ConfigService();
            var config = configService.MongoLoggerConfig;
        }
    }
}
