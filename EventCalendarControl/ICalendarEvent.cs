using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventCalendarControl
{
    public interface ICalendarEvent
    {
        public string EventName { get; set; }
        public DateTime EventStart { get; set; }
        public DateTime? EventEnd { get; set; }
        public string? EventDescription { get; set; }
    }
}
