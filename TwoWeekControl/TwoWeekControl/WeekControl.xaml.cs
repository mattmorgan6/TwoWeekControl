using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public List<Action> UnSelections = new List<Action>();
        public List<Action> Selections = new List<Action>();


        public DateTime dateSelected;       
        //todo: update this variable to the date that is selected.
        //  steps:  1) parse the wvm strings for day, month, year
        //          2) set the DateTime to it.
        //          3) Make a getter


        public WeekViewModel wvm = new WeekViewModel();

		public WeekControl ()
		{
			InitializeComponent ();

            BindingContext = wvm;

            dateSelected = DateTime.Now;

            SetButtons();

            SelectButton(5);
		}

        private void SetButtons()
        {
            UnSelections.Add(() => wvm.Date0Opacity = 0);
            UnSelections.Add(() => wvm.Date1Opacity = 0);
            UnSelections.Add(() => wvm.Date2Opacity = 0);
            UnSelections.Add(() => wvm.Date3Opacity = 0);
            UnSelections.Add(() => wvm.Date4Opacity = 0);
            UnSelections.Add(() => wvm.Date5Opacity = 0);
            UnSelections.Add(() => wvm.Date6Opacity = 0);

            Selections.Add(() => wvm.Date0Opacity = 1);
            Selections.Add(() => wvm.Date1Opacity = 1);
            Selections.Add(() => wvm.Date2Opacity = 1);
            Selections.Add(() => wvm.Date3Opacity = 1);
            Selections.Add(() => wvm.Date4Opacity = 1);
            Selections.Add(() => wvm.Date5Opacity = 1);
            Selections.Add(() => wvm.Date6Opacity = 1);
        }

        public void Add()
        {
            YearLabel.Text += "h";
            int temp = int.Parse(wvm.SixthDate);
            temp++;
            wvm.SixthDate = temp.ToString();
            wvm.Date2Opacity = 1.0;
        }


            // @Param: n is the button selected (0 is top left, 13 if bottom right).
        public void SelectButton(int n)
        {
            for (int i = 0; i < Selections.Count(); i++)
            {
                if (i == n)         //if the button is the selected one
                {
                    Selections[i].Invoke();   //show
                }
                else
                {
                    UnSelections[i].Invoke();   //hide
                }
            }
        }






        //Event Handlers:

        private void Date0Button_Clicked(object sender, EventArgs e)
        {
            //var button = sender as Button;
            //var theValue = button.Id;
            //YearLabel.Text = theValue.ToString(); //todo: know which date is pressed.

            SelectButton(0);
        }

        private void Date1Button_Clicked(object sender, EventArgs e)
        {
            SelectButton(1);
            Debug.WriteLine("button 1 pressed!");
            Debug.WriteLine("wvm Value: " + wvm.Date1Opacity);
        }

        private void Date2Button_Clicked(object sender, EventArgs e)
        {
            SelectButton(2);
            wvm.Date2Opacity = 1;
        }

        private void Date3Button_Clicked(object sender, EventArgs e)
        {
            //buttons.ElementAt(3);
            //Debug.WriteLine("button 3 pressed!");
            //Debug.WriteLine("b3 Value: " + buttons[3]);
            //Debug.WriteLine("wvm Value: " + wvm.Date3Opacity);
            SelectButton(3);
            Debug.WriteLine("opc: " + wvm.Date3Opacity);

        }

        private void Date4Button_Clicked(object sender, EventArgs e)
        {
            SelectButton(4);
        }

        private void Date5Button_Clicked(object sender, EventArgs e)
        {
            SelectButton(5);
        }

        private void Date6Button_Clicked(object sender, EventArgs e)
        {
            SelectButton(6);
        }
    }
}