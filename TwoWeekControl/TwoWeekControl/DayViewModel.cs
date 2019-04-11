using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TwoWeekControl
{
    public class DayViewModel : INotifyPropertyChanged
    {

        //@Params:
        //    dayNumber: The number of the month Range: 1-31
        //    numOpacity: The opacity of the month number.Used to make the old dates faded.
        //    colorTheme: The color of every item.White works best with dark theme!
        //    circleOpacity: The opacity of the button, which has a circular outline.When a user selects a date, it becomes circled (Opacity = 1).
        //    month: Month of the selected day. 
        //    year: Year of the selected day.
            
        public DayViewModel()
        {
            DayNumber = 1;
            CircleOpacity = 0;
            Month = "May";
            Year = 2019;
            NumOpacity = 1;
            ColorTheme = "Black";
        }

        public DayViewModel(int dayNumber, double circleOpacity, string month, int year, double numOpacity, string colorTheme)
        {
            DayNumber = dayNumber;
            CircleOpacity = circleOpacity;
            Month = month;
            Year = year;
            NumOpacity = numOpacity;
            ColorTheme = colorTheme;
        }

        private int dayNumber;
        public int DayNumber
        {
            get { return dayNumber; }
            set
            {
                if (value != dayNumber)
                {
                    dayNumber = value;
                    OnNotifyPropertyChanged(nameof(DayNumber));
                }
            }
        }

        private double circleOpacity;
        public double CircleOpacity
        {
            get { return circleOpacity; }
            set
            {
                if (value != circleOpacity)
                {
                    circleOpacity = value;
                    OnNotifyPropertyChanged(nameof(CircleOpacity));
                }
            }
        }

        private string month;
        public string Month
        {
            get { return month; }
            set
            {
                if (value != month)
                {
                    month = value;
                    OnNotifyPropertyChanged(nameof(Month));
                }
            }
        }

        private int year;
        public int Year
        {
            get { return year; }
            set
            {
                if (value != year)
                {
                    year = value;
                    OnNotifyPropertyChanged(nameof(Year));
                }
            }
        }

        private double numOpacity;
        public double NumOpacity
        {
            get { return numOpacity; }
            set
            {
                if (value != numOpacity)
                {
                    numOpacity = value;
                    OnNotifyPropertyChanged(nameof(NumOpacity));
                }
            }
        }

        private string colorTheme;
        public string ColorTheme
        {
            get { return colorTheme; }
            set
            {
                if(value != colorTheme)
                {
                    colorTheme = value;
                    OnNotifyPropertyChanged(nameof(ColorTheme));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnNotifyPropertyChanged(string property)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}