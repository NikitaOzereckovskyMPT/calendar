using System;
using System.Collections.Generic;

namespace WpfCalendar
{
    public class SelectableItem
    {
        public string Title { get; set; }
        public string IconPath { get; set; }
        public bool IsSelected { get; set; }
    }

    public class UserSelection
    {
        public DateTime Date { get; set; }
        public List<SelectableItem> SelectedItems { get; set; }
    }
}
