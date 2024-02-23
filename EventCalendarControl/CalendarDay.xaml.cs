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
using System.Diagnostics;

namespace EventCalendarControl
{
    /// <summary>
    /// Interaction logic for CalendarDay.xaml
    /// </summary>
    public partial class CalendarDay : UserControl
    {
        
        public DateTime Date { get; set; }
        private string daynum;
        private int activeRow = 0;

        public string Daynum
        {
            get { return daynum; }
            set 
            { 
                daynum = value;
            }
        }
        public CalendarDay(DateTime date)
        {
            this.Date = date;
            daynum = date.Day.ToString();
            DataContext = this;
            InitializeComponent();
        }
        public void AddEvent(ICalendarEvent calendarEvent)
        {
            EventGrid.RowDefinitions.Add(new RowDefinition() { });
            var eventcontrol = new EventControl(calendarEvent);
            EventGrid.Children.Add(eventcontrol);
            Grid.SetRow(eventcontrol, EventGrid.RowDefinitions.Count - 1);
        }
    }
}
