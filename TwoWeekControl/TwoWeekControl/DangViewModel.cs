using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TwoWeekControl
{
    public class DangViewModel : INotifyPropertyChanged
    {
        public DangViewModel()
        {
            VOne = "Wehow";
        }

        private string vOne;
        public string VOne
        {
            get { return vOne; }
            set
            {
                if(value != vOne)
                {
                    vOne = value;
                    OnNotifyPropertyChanged(nameof(VOne));
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
