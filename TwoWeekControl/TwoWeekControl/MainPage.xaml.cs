using System.Diagnostics;

using Xamarin.Forms;

using ModernXamarinCalendar.Models;

namespace TwoWeekControl
{
    public partial class MainPage : ContentPage
	{
        public MainPage()
        {
            InitializeComponent();

            // Subscribe to the event - This sets up the DateSelectedMethod to
            // run when a new date is clicked in the TwoWeekControl.
            CalendarWeekControl.SelectedDateChanged += DateSelectedChanged;
        }

        /// <summary>
        /// Event Handler that responds to the DateSelectedChanged event being
        /// fired
        /// </summary>
        /// <param name="sender">
        /// The WeekControl instance that fired the event.
        /// </param>
        /// <param name="e">
        /// Any additional EventArgs passed with the firing of the event, none
        /// added on by the WeekControl instance.
        /// </param>
        public void DateSelectedChanged(SelectedDateChangedEventArgs args)
        {
            // Insert code here that you want to use the date selected for ...
            Debug.WriteLine(args.SelectedDate.ToString());
        }
    }
}