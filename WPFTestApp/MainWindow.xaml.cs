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
using EventCalendarControl;

namespace WPFTestApp
{
    public partial class MainWindow : Window
    {
        CalendarEventManager CalendarManager = CalendarEventManager.Instance;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MakeEvent_Click(object sender, RoutedEventArgs e)
        {
            BasicEvent calendarEvent;
            DateTime dateS;
            TimeSpan timeS = this.StartTime.GetTime();

            if (this.StartDate.SelectedDate != null) { dateS = this.StartDate.SelectedDate.Value; }
            else { dateS = this.StartDate.DisplayDate; }

            DateTime eventStart = dateS + timeS;

            if (this.EndTime.Time != null)
            {
                DateTime eventEnd = this.EndDate.DisplayDate + this.EndTime.GetTime();
                calendarEvent = new BasicEvent(this.EventName.Text, eventStart, this.EventDescription.Text, eventEnd);
            }
            else
            {
                calendarEvent = new BasicEvent(this.EventName.Text, eventStart, this.EventDescription.Text);
            }
            CalendarManager.AddEvent(calendarEvent);
        }
        private void Calendar_Click(object sender, RoutedEventArgs e)
        {
            CalendarWindow calendarWindow = new CalendarWindow();
            calendarWindow.Show();
        }
    }
}
