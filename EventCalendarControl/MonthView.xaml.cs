using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace EventCalendarControl
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class MonthView : UserControl
    {
        private DayOfWeek weekStart = DayOfWeek.Monday;
        private DayOfWeek weekEnd = DayOfWeek.Sunday;
        private List<CalendarDay> DayList = new List<CalendarDay>();
        private CalendarEventManager CalendarManager = CalendarEventManager.Instance;

        private DateTime currentMonth;

        private string activeYear = "";
        public string ActiveYear
        {
            get { return activeYear; }
            set
            {
                activeYear = value;
                Yeartxt.Text = activeYear;
            }
        }
        private string activeMonth = "";
        public string ActiveMonth
        {
            get { return activeMonth; }
            set
            {
                activeMonth = value;
                Monthtxt.Text = activeMonth;
            }
        }

        public MonthView()
        {
            currentMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            InitializeComponent();
            this.DataContext = this;
            Trace.WriteLine("Initialised");
            BuildCalendar(currentMonth);
            Trace.WriteLine("Calendar build Complete");
        }

        void BuildCalendar(DateTime date)
        {
            ClearCalendar();
            ActiveYear = date.Year.ToString();
            ActiveMonth = date.ToString("MMMM");
            DateTime monthStart = new DateTime(date.Year, date.Month, 1);
            DateTime monthEnd = monthStart.AddMonths(1).AddDays(-1);
            AddDays(FindFirstWeekStart(monthStart), FindLastWeekEnd(monthEnd));
            AssignEvents();
        }
        void AssignEvents()
        {
            foreach (CalendarDay day in DayList)
            {
                foreach (ICalendarEvent calendarEvent in CalendarManager.Events)
                {
                    if (calendarEvent.EventStart.Date == day.Date.Date)
                    {
                        day.AddEvent(calendarEvent);
                    }
                }
            }
        }
        DateTime FindFirstWeekStart(DateTime monthStart)
        {
            while (monthStart.DayOfWeek != weekStart)
            {
                monthStart = monthStart.AddDays(-1);
            }
            return monthStart;
        }
        DateTime FindLastWeekEnd(DateTime monthEnd)
        {
            while (monthEnd.DayOfWeek != weekEnd)
            {
                monthEnd = monthEnd.AddDays(1);
            }
            return monthEnd;
        }
        void AddDays(DateTime startDay, DateTime endDay)
        {
            //start from monday before - continue to sunday after beginning/end of month respectively
            DateTime dayIterate = startDay;
            int dayAxis = 0;
            int weekAxis = 0;
            while (dayIterate != endDay.AddDays(1))
            {
                Trace.WriteLine("calendar day iteration " + dayIterate.ToString());
                CalendarDay iDay = new CalendarDay(dayIterate);
                MonthViewGrid.Children.Add(iDay);
                DayList.Add(iDay);
                Grid.SetColumn(iDay, dayAxis);
                Grid.SetRow(iDay, weekAxis);
                dayIterate = dayIterate.AddDays(1);
                dayAxis++;
                if (dayAxis == 7)
                {
                    Trace.WriteLine("7th day");
                    MonthViewGrid.RowDefinitions.Add(new RowDefinition());
                    dayAxis = 0;
                    weekAxis++;
                }
            }
        }
        void ClearCalendar()
        {
            MonthViewGrid.Children.Clear();
            MonthViewGrid.RowDefinitions.Clear();
        }
        private void YearBack_Click(object sender, RoutedEventArgs e)
        {
            currentMonth = currentMonth.AddYears(-1);
            BuildCalendar(currentMonth);
        }
        private void YearForward_Click(object sender, RoutedEventArgs e)
        {
            currentMonth = currentMonth.AddYears(1);
            BuildCalendar(currentMonth);
        }
        private void MonthBack_Click(object sender, RoutedEventArgs e)
        {
            currentMonth = currentMonth.AddMonths(-1);
            BuildCalendar(currentMonth);
        }
        private void MonthForward_Click(object sender, RoutedEventArgs e)
        {
            currentMonth = currentMonth.AddMonths(1);
            BuildCalendar(currentMonth);
        }
    }
}