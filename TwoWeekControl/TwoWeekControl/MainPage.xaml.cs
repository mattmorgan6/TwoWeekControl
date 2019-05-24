using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace TwoWeekControl
{
    public partial class MainPage : ContentPage
	{
        public MainPage()
        {
            InitializeComponent();

            ///Docs
            // Subscrible to the event  -this sets up the DateSelectedMethod to run when a new date is clicked in the TwoWeekControl.
            CalendarWeekControl.DataSelectedChanged += DateSelectedChanged;
        }

        ///Docs
        public void DateSelectedChanged(object sender, EventArgs e)
        {
            Controls.WeekControl control = sender as Controls.WeekControl;

            // insert code here that you want to use the date selected for...
            // control.DateSelected gives a DateTime for the selected day.
            Debug.WriteLine(control.DateSelected.ToString());
        }
    }
}