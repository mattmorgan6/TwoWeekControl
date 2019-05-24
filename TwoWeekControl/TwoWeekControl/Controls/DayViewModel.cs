using System;
using System.ComponentModel;

using Xamarin.Forms;

namespace TwoWeekControl.Controls
{
    public class DayViewModel : INotifyPropertyChanged
    {
        //* Private Properties
        private Color colorTheme;

        private DateTime date;

        private double circleOpacity;
        private double numOpacity;

        //* Public Properties

        /// <summary>
        /// The color of every item. White works best with dark theme!
        /// </summary>
        public Color ColorTheme
        {
            get => colorTheme;
            set => modifyProperty(ref value, ref colorTheme, nameof(ColorTheme));
        }

        /// <summary>The selected day.</summary>
        public DateTime Date
        {
            get => date;
            set
            {
                modifyProperty(ref value, ref date, nameof(Date));
                OnNotifyPropertyChanged(nameof(Month));
            }
               
        }

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

        /// <summary>The month of the selected day.</summary>
        public string Month => Date.ToString("MMMM");

        //* Events
        public event PropertyChangedEventHandler PropertyChanged;

        //* Constructors
        public DayViewModel() : this(new DateTime(2019, 5, 1), 0, 1, Color.Black) { }

        /// <param name="date">The selected day</param>
        /// <param name="circleOpacity">
        /// The opacity of the button, which has a circular outline. When a user
        /// selects a date, it becomes circled (Opacity = 1).
        /// </param>
        /// <param name="numOpacity">
        /// The opacity of the month number. Used to make the old dates faded.
        /// </param>
        /// <param name="colorTheme">
        /// The color of every item. White works best with dark theme!
        /// </param>
        public DayViewModel(DateTime date, double circleOpacity, double numOpacity, Color colorTheme)
        {
            Date = date;
            CircleOpacity = circleOpacity;
            NumOpacity = numOpacity;
            ColorTheme = colorTheme;
        }

        //* Event Handlers
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