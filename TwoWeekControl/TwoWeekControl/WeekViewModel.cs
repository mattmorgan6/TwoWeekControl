using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TwoWeekControl
{
    public class WeekViewModel : INotifyPropertyChanged
    {



        public WeekViewModel()
        {
            SixthDate = "6";
            Year = "2019";
            Month = "April";
        }

        public string year;
        public string Year
        {
            get { return year; }
            set
            {
                if(value != year)
                    year = value;
                    OnNotifyPropertyChanged(nameof(Year));

            }
        }

        public string month;
        public string Month
        {
            get { return month; }
            set
            {
                if (value != month)
                    month = value;
                    OnNotifyPropertyChanged(nameof(Month));
            }
        }





        public string sixthDate;
        public string SixthDate
        {
            get { return sixthDate; }
            set
            {
                if (sixthDate != value)
                    sixthDate = value;
                    //OnNotifyPropertyChanged(nameof(value));
                    OnNotifyPropertyChanged(nameof(SixthDate));
            }
        }







        private double date0Opacity;
        public double Date0Opacity
        {
            get { return date0Opacity; }
            set
            {
                if (value != date0Opacity)
                    date0Opacity = value;
                    OnNotifyPropertyChanged(nameof(Date0Opacity));
            }
        }

        private double date1Opacity;
        public double Date1Opacity
        {
            get { return date1Opacity; }
            set
            {
                if (value != date1Opacity)
                    date1Opacity = value;
                    OnNotifyPropertyChanged(nameof(Date1Opacity));
            }
        }

        private double date2Opacity;
        public double Date2Opacity
        {
            get { return date2Opacity; }
            set
            {
                if(value != date2Opacity)
                    date2Opacity = value;
                    OnNotifyPropertyChanged(nameof(Date2Opacity));
            }
        }

        private double date3Opacity;
        public double Date3Opacity
        {
            get { return date3Opacity; }
            set
            {
                if (value != date3Opacity)
                    date3Opacity = value;
                    OnNotifyPropertyChanged(nameof(Date3Opacity));
            }
        }

        private double date4Opacity;
        public double Date4Opacity
        {
            get { return date4Opacity; }
            set
            {
                if (value != date4Opacity)
                    date4Opacity = value;
                    OnNotifyPropertyChanged(nameof(Date4Opacity));
            }
        }

        private double date5Opacity;
        public double Date5Opacity
        {
            get { return date5Opacity; }
            set
            {
                if (value != date5Opacity)
                    date5Opacity = value;
                    OnNotifyPropertyChanged(nameof(Date5Opacity));
            }
        }

        private double date6Opacity;
        public double Date6Opacity
        {
            get { return date6Opacity; }
            set
            {
                if (value != date6Opacity)
                    date6Opacity = value;
                    OnNotifyPropertyChanged(nameof(Date6Opacity));
            }
        }









        public event PropertyChangedEventHandler PropertyChanged;

        //* Event Handlers
        public void OnNotifyPropertyChanged(string property)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
