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
        public int SelectedDay;

        public List<Action> UnSelections = new List<Action>();
        public List<Action> Selections = new List<Action>();


        public DateTime dateSelected;       
        //todo: update this variable to the date that is selected.
        //  steps:  1) correct the month if it i selects 31 or lower, or higher than the last month.
        //          2) correct the year if the month clicked is december or january
        //          2) parse the wvm strings for day, month, year     <-- done
        //          3) set the DateTime to it.
        //          4) Make a getter


        public WeekViewModel wvm = new WeekViewModel();
        public DangViewModel dvm = new DangViewModel();

		public WeekControl ()
		{
			InitializeComponent ();

            BindingContext = wvm;

            dateSelected = DateTime.Now;

            SetButtons();

            SelectButton(5);

            SelectedDay = 0;

            YearLabel.BindingContext = dvm;

            
		}

        public void UpdateTime()    //sets dateSelected to the correct DateTime
        {
            string year = wvm.Year;
            string month = wvm.Month;
            string day = SelectedDay.ToString();            

            string sum = year + "-" + month + "-" + day;

            Debug.WriteLine("Sum "+sum);
            Debug.WriteLine("Parse: " + DateTime.TryParseExact(sum, "yyyy-MMMM-d", null, System.Globalization.DateTimeStyles.None, out dateSelected));
            Debug.WriteLine("Date selected: " + dateSelected.ToShortDateString());
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
            UnSelections.Add(() => wvm.Date7Opacity = 0);
            UnSelections.Add(() => wvm.Date8Opacity = 0);
            UnSelections.Add(() => wvm.Date9Opacity = 0);
            UnSelections.Add(() => wvm.Date10Opacity = 0);
            UnSelections.Add(() => wvm.Date11Opacity = 0);
            UnSelections.Add(() => wvm.Date12Opacity = 0);
            UnSelections.Add(() => wvm.Date13Opacity = 0);

            Selections.Add(() => wvm.Date0Opacity = 1);
            Selections.Add(() => wvm.Date1Opacity = 1);
            Selections.Add(() => wvm.Date2Opacity = 1);
            Selections.Add(() => wvm.Date3Opacity = 1);
            Selections.Add(() => wvm.Date4Opacity = 1);
            Selections.Add(() => wvm.Date5Opacity = 1);
            Selections.Add(() => wvm.Date6Opacity = 1);
            Selections.Add(() => wvm.Date7Opacity = 1);
            Selections.Add(() => wvm.Date8Opacity = 1);
            Selections.Add(() => wvm.Date9Opacity = 1);
            Selections.Add(() => wvm.Date10Opacity = 1);
            Selections.Add(() => wvm.Date11Opacity = 1);
            Selections.Add(() => wvm.Date12Opacity = 1);
            Selections.Add(() => wvm.Date13Opacity = 1);
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
            
            UpdateTime();
        }      
        


        //Event Handlers:

        private void Date0Button_Clicked(object sender, EventArgs e)
        {
            //var button = sender as Button;
            //var theValue = button.Id;
            //YearLabel.Text = theValue.ToString(); //todo: know which date is pressed.

            SelectedDay = wvm.Date0Num;
            if(wvm.Date0Num > wvm.Date1Num)
            {
                wvm.Month = DateTime.ParseExact(wvm.Month, "MMMM", null).AddMonths(-1).ToString("MMMM");
            }

            //Debug.WriteLine(DateTime.ParseExact(wvm.Month, "MMMM", null).AddMonths(-1).ToString("MMMM"));

            SelectButton(0);
            
        }

        private void Date1Button_Clicked(object sender, EventArgs e)
        {
            SelectedDay = wvm.Date1Num;
            if (wvm.Date1Num > wvm.Date2Num)
            {
                wvm.Month = DateTime.ParseExact(wvm.Month, "MMMM", null).AddMonths(-1).ToString("MMMM");
            }
            else if (wvm.Date1Num < wvm.Date0Num)
            {
                wvm.Month = DateTime.ParseExact(wvm.Month, "MMMM", null).AddMonths(1).ToString("MMMM");
            }
            SelectButton(1);
            Debug.WriteLine("button 1 pressed!");
            Debug.WriteLine("wvm Value: " + wvm.Date1Opacity);
        }

        private void Date2Button_Clicked(object sender, EventArgs e)
        {
            SelectedDay = wvm.Date2Num;
            if (wvm.Date2Num > wvm.Date3Num)
            {
                wvm.Month = DateTime.ParseExact(wvm.Month, "MMMM", null).AddMonths(-1).ToString("MMMM");
            }
            else if (wvm.Date2Num < wvm.Date1Num)
            {
                wvm.Month = DateTime.ParseExact(wvm.Month, "MMMM", null).AddMonths(1).ToString("MMMM");
            }
            SelectButton(2);
            wvm.Date2Opacity = 1;
        }

        private void Date3Button_Clicked(object sender, EventArgs e)
        {
            SelectedDay = wvm.Date3Num;
            if (wvm.Date3Num > wvm.Date4Num)
            {
                wvm.Month = DateTime.ParseExact(wvm.Month, "MMMM", null).AddMonths(-1).ToString("MMMM");
            }
            else if (wvm.Date3Num < wvm.Date2Num)
            {
                wvm.Month = DateTime.ParseExact(wvm.Month, "MMMM", null).AddMonths(1).ToString("MMMM");
            }
            SelectButton(3);
            Debug.WriteLine("opc: " + wvm.Date3Opacity);

        }

        private void Date4Button_Clicked(object sender, EventArgs e)
        {
            SelectedDay = wvm.Date4Num;
            if (wvm.Date4Num > wvm.Date5Num)
            {
                wvm.Month = DateTime.ParseExact(wvm.Month, "MMMM", null).AddMonths(-1).ToString("MMMM");
            }
            else if (wvm.Date4Num < wvm.Date3Num)
            {
                wvm.Month = DateTime.ParseExact(wvm.Month, "MMMM", null).AddMonths(1).ToString("MMMM");
            }
            SelectButton(4);
        }

        private void Date5Button_Clicked(object sender, EventArgs e)
        {
            SelectedDay = wvm.Date5Num;
            if (wvm.Date5Num > wvm.Date6Num)
            {
                wvm.Month = DateTime.ParseExact(wvm.Month, "MMMM", null).AddMonths(-1).ToString("MMMM");
            }
            else if (wvm.Date5Num < wvm.Date4Num)
            {
                wvm.Month = DateTime.ParseExact(wvm.Month, "MMMM", null).AddMonths(1).ToString("MMMM");
            }
            SelectButton(5);
        }

        private void Date6Button_Clicked(object sender, EventArgs e)
        {
            SelectedDay = wvm.Date6Num;
            if (wvm.Date6Num > wvm.Date7Num)
            {
                wvm.Month = DateTime.ParseExact(wvm.Month, "MMMM", null).AddMonths(-1).ToString("MMMM");
            }
            else if (wvm.Date6Num < wvm.Date5Num)
            {
                wvm.Month = DateTime.ParseExact(wvm.Month, "MMMM", null).AddMonths(1).ToString("MMMM");
            }
            SelectButton(6);
        }

        private void Date7Button_Clicked(object sender, EventArgs e)
        {
            SelectedDay = wvm.Date7Num;
            if (wvm.Date7Num > wvm.Date8Num)
            {
                wvm.Month = DateTime.ParseExact(wvm.Month, "MMMM", null).AddMonths(-1).ToString("MMMM");
            }
            else if (wvm.Date7Num < wvm.Date6Num)
            {
                wvm.Month = DateTime.ParseExact(wvm.Month, "MMMM", null).AddMonths(1).ToString("MMMM");
            }
            SelectButton(7);
        }

        private void Date8Button_Clicked(object sender, EventArgs e)
        {
            SelectedDay = wvm.Date8Num;
            if (wvm.Date8Num > wvm.Date9Num)
            {
                wvm.Month = DateTime.ParseExact(wvm.Month, "MMMM", null).AddMonths(-1).ToString("MMMM");
            }
            else if (wvm.Date8Num < wvm.Date7Num)
            {
                wvm.Month = DateTime.ParseExact(wvm.Month, "MMMM", null).AddMonths(1).ToString("MMMM");
            }
            SelectButton(8);
        }

        private void Date9Button_Clicked(object sender, EventArgs e)
        {
            SelectedDay = wvm.Date9Num;
            if (wvm.Date9Num > wvm.Date10Num)
            {
                wvm.Month = DateTime.ParseExact(wvm.Month, "MMMM", null).AddMonths(-1).ToString("MMMM");
            }
            else if (wvm.Date9Num < wvm.Date8Num)
            {
                wvm.Month = DateTime.ParseExact(wvm.Month, "MMMM", null).AddMonths(1).ToString("MMMM");
            }
            SelectButton(9);
        }

        private void Date10Button_Clicked(object sender, EventArgs e)
        {
            SelectedDay = wvm.Date10Num;
            if (wvm.Date10Num > wvm.Date11Num)
            {
                wvm.Month = DateTime.ParseExact(wvm.Month, "MMMM", null).AddMonths(-1).ToString("MMMM");
            }
            else if (wvm.Date10Num < wvm.Date9Num)
            {
                wvm.Month = DateTime.ParseExact(wvm.Month, "MMMM", null).AddMonths(1).ToString("MMMM");
            }
            SelectButton(10);
        }

        private void Date11Button_Clicked(object sender, EventArgs e)
        {
            SelectedDay = wvm.Date11Num;
            if (wvm.Date11Num > wvm.Date12Num)
            {
                wvm.Month = DateTime.ParseExact(wvm.Month, "MMMM", null).AddMonths(-1).ToString("MMMM");
            }
            else if (wvm.Date11Num < wvm.Date10Num)
            {
                wvm.Month = DateTime.ParseExact(wvm.Month, "MMMM", null).AddMonths(1).ToString("MMMM");
            }
            SelectButton(11);
        }

        private void Date12Button_Clicked(object sender, EventArgs e)
        {
            SelectedDay = wvm.Date12Num;
            if (wvm.Date12Num > wvm.Date13Num)
            {
                wvm.Month = DateTime.ParseExact(wvm.Month, "MMMM", null).AddMonths(-1).ToString("MMMM");
            }
            else if (wvm.Date12Num < wvm.Date11Num)
            {
                wvm.Month = DateTime.ParseExact(wvm.Month, "MMMM", null).AddMonths(1).ToString("MMMM");
            }
            SelectButton(12);
        }

        private void Date13Button_Clicked(object sender, EventArgs e)
        {
            SelectedDay = wvm.Date13Num;
            if (wvm.Date13Num < wvm.Date12Num)
            {
                wvm.Month = DateTime.ParseExact(wvm.Month, "MMMM", null).AddMonths(1).ToString("MMMM");
            }
            SelectButton(13);
        }
    }
}