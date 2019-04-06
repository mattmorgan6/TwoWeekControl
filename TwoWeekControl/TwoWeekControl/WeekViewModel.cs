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

        private double date7Opacity;
        public double Date7Opacity
        {
            get { return date7Opacity; }
            set
            {
                if (value != date7Opacity)
                    date7Opacity = value;
                OnNotifyPropertyChanged(nameof(Date7Opacity));
            }
        }

        private double date8Opacity;
        public double Date8Opacity
        {
            get { return date8Opacity; }
            set
            {
                if (value != date8Opacity)
                    date8Opacity = value;
                OnNotifyPropertyChanged(nameof(Date8Opacity));
            }
        }

        private double date9Opacity;
        public double Date9Opacity
        {
            get { return date9Opacity; }
            set
            {
                if (value != date9Opacity)
                    date9Opacity = value;
                OnNotifyPropertyChanged(nameof(Date9Opacity));
            }
        }

        private double date10Opacity;
        public double Date10Opacity
        {
            get { return date10Opacity; }
            set
            {
                if (value != date10Opacity)
                    date10Opacity = value;
                OnNotifyPropertyChanged(nameof(Date10Opacity));
            }
        }

        private double date11Opacity;
        public double Date11Opacity
        {
            get { return date11Opacity; }
            set
            {
                if (value != date11Opacity)
                    date11Opacity = value;
                OnNotifyPropertyChanged(nameof(Date11Opacity));
            }
        }

        private double date12Opacity;
        public double Date12Opacity
        {
            get { return date12Opacity; }
            set
            {
                if (value != date12Opacity)
                    date12Opacity = value;
                OnNotifyPropertyChanged(nameof(Date12Opacity));
            }
        }

        private double date13Opacity;
        public double Date13Opacity
        {
            get { return date13Opacity; }
            set
            {
                if (value != date13Opacity)
                    date13Opacity = value;
                OnNotifyPropertyChanged(nameof(Date13Opacity));
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
