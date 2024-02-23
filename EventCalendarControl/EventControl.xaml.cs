using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EventCalendarControl
{
    /// <summary>
    /// Interaction logic for EventControl.xaml
    /// </summary>
    public partial class EventControl : UserControl
    {
        private ICalendarEvent calendarEvent;
        public EventControl(ICalendarEvent calendarEvent)
        {
            InitializeComponent();
            DataContext = this;
            this.calendarEvent = calendarEvent;
            TimeBox.Text = calendarEvent.EventStart.TimeOfDay.ToString();
            NameBox.Text = calendarEvent.EventName;
        }
    }
}
