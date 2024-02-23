using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventCalendarControl
{
    public class BasicEvent : ICalendarEvent
    {
        public BasicEvent(string eventname, DateTime eventstart, string eventdesc = "", DateTime? eventend = null)
        {
            EventName = eventname;
            EventStart = eventstart;
            EventDescription = eventdesc;
            EventEnd = eventend;
        }
        public string EventName { get; set; }
        public string? EventDescription { get; set; }
        public DateTime EventStart { get; set; }
        public DateTime? EventEnd { get; set; }
    }
}
