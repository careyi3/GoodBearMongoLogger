using GoodBearMongoLogger.Logging.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodBearMongoLogger.Logging.Impl
{
    internal class EventLogEntry
    {
        public string Message { get; set; }

        public IEventEntry EventEntry { get; set; }
    }
}
