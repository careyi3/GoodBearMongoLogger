using GoodBearMongoLogger.Logging.Interfaces;

namespace GoodBearMongoLogger.Logging.Impl
{
    internal class EventLogEntry : AbstractLogEntryBase
    {
        public string Message { get; set; }

        public IEventEntry EventEntry { get; set; }
    }
}
