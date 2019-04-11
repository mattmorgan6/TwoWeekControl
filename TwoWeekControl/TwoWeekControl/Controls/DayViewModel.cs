using System.ComponentModel;

namespace TwoWeekControl.Controls
{
    public class DayViewModel : INotifyPropertyChanged
    {
        //* Private Properties
        private double circleOpacity;
        private double numOpacity;

        private int dayNumber;
        private int year;

        private string colorTheme;
        private string month;

        //* Public Properties

        /// <summary>
        /// The opacity of the button, which has a circular outline. When a user
        /// selects a date, it becomes circled (Opacity = 1).
        /// </summary>
        public double CircleOpacity
        {
            get => circleOpacity;
            set => modifyProperty(ref value, ref circleOpacity, nameof(CircleOpacity));
        }
        ///  <summary>
        /// The opacity of the month number.Used to make the old dates faded.
        /// </summary>
        /// <value></value>
        public double NumOpacity
        {
            get => numOpacity;
            set => modifyProperty(ref value, ref numOpacity, nameof(NumOpacity));
        }

        /// <summary>The number of the month (Range: 1-31)</summary>
        public int DayNumber
        {
            get => dayNumber;
            set => modifyProperty(ref value, ref dayNumber, nameof(DayNumber));
        }
        /// <summary>Year of the selected day.</summary>
        public int Year
        {
            get => year;
            set => modifyProperty(ref value, ref year, nameof(Year));
        }

        /// <summary>
        /// The color of every item.White works best with dark theme!
        /// </summary>
        public string ColorTheme
        {
            get => colorTheme;
            set => modifyProperty(ref value, ref colorTheme, nameof(ColorTheme));
        }
        /// <summary>Month of the selected day.</summary>
        public string Month
        {
            get => month;
            set => modifyProperty(ref value, ref month, nameof(Month));
        }

        //* Constructors
        public DayViewModel() : this(1, 0, "May", 2019, 1, "Black") { }

        /// <param name="dayNumber">The number of the month (Range: 1-31)</param>
        /// <param name="circleOpacity">
        /// The opacity of the button, which has a circular outline. When a user
        /// selects a date, it becomes circled (Opacity = 1).
        /// </param>
        /// <param name="month">Month of the selected day.</param>
        /// <param name="year">Year of the selected day.</param>
        /// <param name="numOpacity">
        /// The opacity of the month number. Used to make the old dates faded.
        /// </param>
        /// <param name="colorTheme">
        /// The color of every item.White works best with dark theme!
        /// </param>
        public DayViewModel(int dayNumber, double circleOpacity, string month, int year,
            double numOpacity, string colorTheme)
        {
            DayNumber = dayNumber;
            CircleOpacity = circleOpacity;
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