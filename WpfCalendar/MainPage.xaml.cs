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

namespace WpfCalendar
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private DateTime _currentMonth;
        public MainPage()
        {
            InitializeComponent();
            _currentMonth = DateTime.Now;
            UpdateCalendar();
        }

        private void UpdateCalendar()
        {
            CurrentMonthText.Text = _currentMonth.ToString("MMMM yyyy");
            CalendarItemsControl.ItemsSource = GetCalendarDays();
        }

        private List<DayInfo> GetCalendarDays()
        {
            var days = new List<DayInfo>();

            DateTime firstDayOfMonth = new DateTime(_currentMonth.Year, _currentMonth.Month, 1);
            int offset = (int)firstDayOfMonth.DayOfWeek - 1;
            if (offset < 0) offset += 7;

            for (int i = 0; i < offset; i++)
            {
                days.Add(new DayInfo { Day = 0, IconPath = null });
            }

            int daysInMonth = DateTime.DaysInMonth(_currentMonth.Year, _currentMonth.Month);
            for (int i = 1; i <= daysInMonth; i++)
            {
                days.Add(new DayInfo { Day = i, IconPath = null }); // Замените null на путь к иконке, если нужно
            }

            return days;
        }

        private void PreviousMonthButton_Click(object sender, RoutedEventArgs e)
        {
            _currentMonth = _currentMonth.AddMonths(-1);
            UpdateCalendar();
        }

        private void NextMonthButton_Click(object sender, RoutedEventArgs e)
        {
            _currentMonth = _currentMonth.AddMonths(1);
            UpdateCalendar();
        }
    }

    public class DayInfo
    {
        public int Day { get; set; }
        public string IconPath { get; set; }
    }
}
