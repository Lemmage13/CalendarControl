using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for TimePicker.xaml
    /// </summary>
    public partial class TimePicker : UserControl
    {
#nullable enable
        public TimeSpan? Time { get; set; }
        public TimePicker()
        {
            InitializeComponent();
        }
        private void Time_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string? hour = (Hour.SelectedItem as ComboBoxItem)?.Content.ToString();
            string? min = (Minute.SelectedItem as ComboBoxItem)?.Content.ToString();

            Time = UpdateTime(hour, min);
        }
        public TimeSpan GetTime()
        {
            return Time ?? new TimeSpan(0, 0, 0);
        }
        private TimeSpan? UpdateTime(string? hr, string? min)
        {
            int h;
            int m;
            if (hr != null && min != null)
            {
                if (hr == "00") { h = 0; }
                else { h = Convert.ToInt32(hr.TrimStart('0')); }
                if (min == "00") { m = 0; }
                else { m = Convert.ToInt32(min.TrimStart('0')); }
                return new TimeSpan(h, m, 0);
            }
            return null;
        }
    }
}
