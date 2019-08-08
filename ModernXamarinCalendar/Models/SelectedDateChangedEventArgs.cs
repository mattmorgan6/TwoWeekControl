using System;

namespace ModernXamarinCalendar.Models
{
    public class SelectedDateChangedEventArgs : EventArgs
    {
        //* Public Properties
        public DateTime SelectedDate { get; set; }

        //* Constructors
        public SelectedDateChangedEventArgs(DateTime selectedDate) =>
            SelectedDate = selectedDate;
    }
}