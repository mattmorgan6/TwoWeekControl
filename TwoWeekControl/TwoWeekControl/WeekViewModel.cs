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
            Year = "2019";
            Month = "April";
            Date0Num = 31;
            Date1Num = 1;
            Date2Num = 2;
            Date3Num = 3;
            Date4Num = 4;
            Date5Num = 5;
            Date6Num = 6;
            Date7Num = 7;
            Date8Num = 8;
            Date9Num = 9;
            Date10Num = 10;
            Date11Num = 11;
            Date12Num = 12;
            Date13Num = 13;
            /*Lily.Add(new DayModel("wow")); */
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

        private int date0Num;
        public int Date0Num
        {
            get { return date0Num; }
            set
            {
                if(value != date0Num)
                {
                    date0Num = value;
                    OnNotifyPropertyChanged(nameof(Date0Num));
                }
            }
        }

        private int date1Num;
        public int Date1Num
        {
            get { return date1Num; }
            set
            {
                if (value != date1Num)
                {
                    date1Num = value;
                    OnNotifyPropertyChanged(nameof(Date1Num));
                }
            }
        }

        private int date2Num;
        public int Date2Num
        {
            get { return date2Num; }
            set
            {
                if (value != date2Num)
                {
                    date2Num = value;
                    OnNotifyPropertyChanged(nameof(Date2Num));
                }
            }
        }

        private int date3Num;
        public int Date3Num
        {
            get { return date3Num; }
            set
            {
                if (value != date3Num)
                {
                    date3Num = value;
                    OnNotifyPropertyChanged(nameof(Date3Num));
                }
            }
        }

        private int date4Num;
        public int Date4Num
        {
            get { return date4Num; }
            set
            {
                if (value != date4Num)
                {
                    date4Num = value;
                    OnNotifyPropertyChanged(nameof(Date4Num));
                }
            }
        }

        private int date5Num;
        public int Date5Num
        {
            get { return date5Num; }
            set
            {
                if (value != date5Num)
                {
                    date5Num = value;
                    OnNotifyPropertyChanged(nameof(Date5Num));
                }
            }
        }


        private int date6Num;
        public int Date6Num
        {
            get { return date6Num; }
            set
            {
                if (value != date6Num)
                {
                    date6Num = value;
                    OnNotifyPropertyChanged(nameof(Date6Num));
                }
            }
        }


        private int date7num;
        public int Date7Num
        {
            get { return date7num; }
            set
            {
                if (value != date7num)
                {
                    date7num = value;
                    OnNotifyPropertyChanged(nameof(Date7Num));
                }
            }
        }

        private int date8Num;
        public int Date8Num
        {
            get { return date8Num; }
            set
            {
                if (value != date8Num)
                {
                    date8Num = value;
                    OnNotifyPropertyChanged(nameof(Date8Num));
                }
            }
        }

        private int date9Num;
        public int Date9Num
        {
            get { return date9Num; }
            set
            {
                if (value != date9Num)
                {
                    date9Num = value;
                    OnNotifyPropertyChanged(nameof(Date9Num));
                }
            }
        }

        private int date10Num;
        public int Date10Num
        {
            get { return date10Num; }
            set
            {
                if (value != date10Num)
                {
                    date10Num = value;
                    OnNotifyPropertyChanged(nameof(Date10Num));
                }
            }
        }

        private int date11Num;
        public int Date11Num
        {
            get { return date11Num; }
            set
            {
                if (value != date11Num)
                {
                    date11Num = value;
                    OnNotifyPropertyChanged(nameof(Date11Num));
                }
            }
        }

        private int date12Num;
        public int Date12Num
        {
            get { return date12Num; }
            set
            {
                if (value != date12Num)
                {
                    date12Num = value;
                    OnNotifyPropertyChanged(nameof(Date12Num));
                }
            }
        }

        private int date13Num;
        public int Date13Num
        {
            get { return date13Num; }
            set
            {
                if (value != date13Num)
                {
                    date13Num = value;
                    OnNotifyPropertyChanged(nameof(Date13Num));
                }
            }
        }






        public string sixthDate;


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
