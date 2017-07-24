using System;

namespace BeerBeaconLibrary.Models
{
    public class LogEntry
    {
        public LogEntry(Exception e)
        {
            EventTime = DateTime.Now;
            Source = e.Source;
            if(e.InnerException != null)
            {
                InnerMessage = e.InnerException.Message;
            }
            StackTrace = e.StackTrace;
            Message = e.Message;
        }

        public int LogEntryId { get; set; }
        public DateTime EventTime { get; set; }
        public string Source { get; set; }
        public string InnerMessage { get; set; }
        public string StackTrace { get; set; }
        public string Message { get; set; }
    }
}
