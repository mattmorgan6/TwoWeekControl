using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TwoWeekControl
{
    public class DayViewModel : INotifyPropertyChanged
    {
        public DayViewModel()
        {
            DayNumber = 1;
            CircleOpacity = 0;
            Month = "May";
            Year = 2019;
            NumOpacity = 1;
            ColorTheme = "Black";
        }

        public DayViewModel(int dayNumber, double CircleOpacity, string month, int year, double numOpacity, string colorTheme)
        {
            DayNumber = dayNumber;
            CircleOpacity = CircleOpacity;
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