using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TwoWeekControl
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WeekControl : ContentView
	{
        public int SelectedDate = 0;

        public WeekViewModel wvm = new WeekViewModel();

		public WeekControl ()
		{
			InitializeComponent ();

            BindingContext = wvm;
		}

        private void Date0Button_Clicked(object sender, EventArgs e)
        {
            //var button = sender as Button;
            //var theValue = button.Id;
            //YearLabel.Text = theValue.ToString(); //todo: know which date is pressed.

            YearLabel.Text += "h";
            int temp = int.Parse(wvm.SixthDate);
            temp++;
            wvm.SixthDate = temp.ToString();
        }

        public void add()
        {
            SelectedDate++;
        }
    }
}