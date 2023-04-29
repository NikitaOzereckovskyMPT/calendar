using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace WpfCalendar
{
    public partial class DayControl : UserControl
    {
        public static readonly DependencyProperty DayProperty = DependencyProperty.Register("Day", typeof(int), typeof(DayControl), new PropertyMetadata(0, OnDayChanged));
        public static readonly DependencyProperty IconPathProperty = DependencyProperty.Register("IconPath", typeof(string), typeof(DayControl), new PropertyMetadata(null, OnIconPathChanged));

        public int Day
        {
            get { return (int)GetValue(DayProperty); }
            set { SetValue(DayProperty, value); }
        }

        public string IconPath
        {
            get { return (string)GetValue(IconPathProperty); }
            set { SetValue(IconPathProperty, value); }
        }

        public DayControl()
        {
            InitializeComponent();
        }

        private static void OnDayChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (DayControl)d;
            control.DayText.Text = e.NewValue.ToString();
        }

        private static void OnIconPathChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (DayControl)d;
            control.IconImage.Source = e.NewValue != null ? new BitmapImage(new Uri((string)e.NewValue, UriKind.Relative)) : null;
        }
    }
}