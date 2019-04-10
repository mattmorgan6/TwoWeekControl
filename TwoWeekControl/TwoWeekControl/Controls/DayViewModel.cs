using System.ComponentModel;

namespace TwoWeekControl.Controls
{
    public class DayViewModel : INotifyPropertyChanged
    {
        //* Private Properties
        private double dayOpacity;
        private double numOpacity;

        private int dayNumber;
        private int year;

        private string colorTheme;
        private string month;

        //* Public Properties
        public double DayOpacity
        {
            get => dayOpacity;
            set => modifyProperty(ref value, ref dayOpacity, nameof(DayOpacity));
        }
        public double NumOpacity
        {
            get => numOpacity;
            set => modifyProperty(ref value, ref numOpacity, nameof(NumOpacity));
        }

        public int DayNumber
        {
            get => dayNumber;
            set => modifyProperty(ref value, ref dayNumber, nameof(DayNumber));
        }
        public int Year
        {
            get => year;
            set => modifyProperty(ref value, ref year, nameof(Year));
        }

        public string ColorTheme
        {
            get => colorTheme;
            set => modifyProperty(ref value, ref colorTheme, nameof(ColorTheme));
        }
        public string Month
        {
            get => month;
            set => modifyProperty(ref value, ref month, nameof(Month));
        }

        //* Constructors
        public DayViewModel() : this(1, 0, "May", 2019, 1, "Black") { }

        public DayViewModel(int dayNumber, double dayOpacity, string month, int year,
            double numOpacity, string colorTheme)
        {
            DayNumber = dayNumber;
            DayOpacity = dayOpacity;
            Month = month;
            Year = year;
            NumOpacity = numOpacity;
            ColorTheme = colorTheme;
        }

        //* Events and Event Handlers
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnNotifyPropertyChanged(string property) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));

        //* Private Methods
        private void modifyProperty<T>(ref T value, ref T privateProperty, string nameOfProperty)
        {
            if (!value.Equals(privateProperty))
            {
                privateProperty = value;
                OnNotifyPropertyChanged(nameOfProperty);
            }
        }
    }
}