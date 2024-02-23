using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventCalendarControl
{
    public class CalendarEventManager
    {
        private static CalendarEventManager? instance;
        private static readonly object padlock = new();
        public static CalendarEventManager Instance
        {
            get 
            { 
                lock(padlock)
                {
                    instance ??= new CalendarEventManager();
                    return instance;
                }
            }
        }
        private CalendarEventManager() { }
        public List<ICalendarEvent> Events { get; set; } = new List<ICalendarEvent>();
        public void AddEvent(ICalendarEvent ievent)
        {
            Events.Add(ievent);
        }
    }
}
