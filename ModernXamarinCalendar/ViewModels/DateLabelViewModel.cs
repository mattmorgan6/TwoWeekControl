using System;

namespace ModernXamarinCalendar.ViewModels
{
    public class DateLabelViewModel : BaseViewModel
    {
        //* Private Properties
        private DateTime date;

        //* Public Properties
        public DateTime Date
        {
            get => date;
            set
            {
                setProperty(ref date, value);
                OnPropertyChanged(nameof(ShortDayName));
            }
        }

        public string ShortDayName => Date.ToString("ddd").ToUpper();

        //* Constructors
        public DateLabelViewModel(DateTime date) => Date = date;
    }
}