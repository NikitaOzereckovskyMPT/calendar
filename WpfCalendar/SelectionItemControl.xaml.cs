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
    public partial class SelectionItemControl : UserControl
    {
        public static readonly DependencyProperty ItemNameProperty =
            DependencyProperty.Register("ItemName", typeof(string), typeof(SelectionItemControl), new PropertyMetadata(null, OnItemNameChanged));

        public static readonly DependencyProperty IconPathProperty =
            DependencyProperty.Register("IconPath", typeof(string), typeof(SelectionItemControl), new PropertyMetadata(null, OnIconPathChanged));

        public string ItemName
        {
            get { return (string)GetValue(ItemNameProperty); }
            set { SetValue(ItemNameProperty, value); }
        }

        public string IconPath
        {
            get { return (string)GetValue(IconPathProperty); }
            set { SetValue(IconPathProperty, value); }
        }

        public SelectionItemControl()
        {
            InitializeComponent();
        }

        private static void OnItemNameChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is SelectionItemControl control)
            {
                control.ItemNameText.Text = control.ItemName;
            }
        }

        private static void OnIconPathChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is SelectionItemControl control)
            {
                control.IconImage.Source = new BitmapImage(new Uri(control.IconPath, UriKind.Relative));
            }
        }
    }
}
