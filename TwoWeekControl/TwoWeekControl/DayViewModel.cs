using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TwoWeekControl
{
    class DayViewModel : INotifyPropertyChanged
    {
        public DayViewModel()
        {
            DayNumber = 1;
            DayOpacity = 1;
            Month = "May";
            Year = 2019;
        }

        public DayViewModel(int dayNumber, double dayOpacity, string month, int year)
        {
            DayNumber = dayNumber;
            DayOpacity = dayOpacity;
            Month = month;
            Year = year;
        }

        private int dayNumber;
        public int DayNumber
        {
            get { return dayNumber; }
            set
            {
                if(value != dayNumber)
                {
                    dayNumber = value;
                    OnNotifyPropertyChanged(nameof(DayNumber));
                }
            }
        }

        private double dayOpacity;
        public double DayOpacity
        {
            get { return dayOpacity; }
            set
            {
                if (value != dayOpacity)
                {
                    dayOpacity = value;
                    OnNotifyPropertyChanged(nameof(DayOpacity));
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
