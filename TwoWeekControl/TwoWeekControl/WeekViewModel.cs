using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TwoWeekControl
{
    public class WeekViewModel : INotifyPropertyChanged
    {


        public string sixthDate;

        public WeekViewModel()
        {
            SixthDate = "6";
        }

        public string SixthDate
        {
            get { return sixthDate; }
            set
            {
                if (sixthDate == value)
                    return;

                sixthDate = value;

                //OnNotifyPropertyChanged(nameof(value));
                OnNotifyPropertyChanged(nameof(SixthDate));
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
