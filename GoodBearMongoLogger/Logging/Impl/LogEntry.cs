﻿using GoodBearMongoLogger.Logging.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodBearMongoLogger.Logging.Impl
{
    internal class LogEntry : LogEntryBase
    {
        public LogLevel Level {get; set;}
        public Exception Exception { get; set; }
        public string Message { get; set; }
    }
}
