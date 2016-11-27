using GoodBearMongoLogger.Factory;
using GoodBearMongoLogger.Logging.Enum;
using GoodBearMongoLogger.Logging.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodBearMongoLogger.Demo
{
    class AnotherSampleLoggerClass
    {
        private ILogger _logger = LoggerFactory.GetLogger("Test");

        public void DoStuff()
        {
            _logger.Log(LogLevel.INFO,"Another Test");
        }
    }
}
