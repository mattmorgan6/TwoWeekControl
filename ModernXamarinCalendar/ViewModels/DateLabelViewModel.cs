using System;

using Xamarin.Forms;

namespace ModernXamarinCalendar.ViewModels
{
    public class DateLabelViewModel : BaseViewModel
    {
        //* Private Properties
        private Color foregroundColor;

        private DateTime date;

        //* Public Properties
        public Color ForegroundColor
        {
            get => foregroundColor;
            set => setProperty(ref foregroundColor, value);
        }

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