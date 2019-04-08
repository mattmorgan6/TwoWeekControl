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
        public DateTime dateSelected;       


        public List<DayViewModel> dataList = new List<DayViewModel>();


		public WeekControl ()
		{
			InitializeComponent ();

            SetDataList();

            SelectDay(6);
		}

        public void SetDateSelected(int n)
        {
            string year = dataList[n].Year.ToString();
            string month = dataList[n].Month;
            string day = dataList[n].DayNumber.ToString();

            string sum = year + "-" + month + "-" + day;

            Debug.WriteLine("Sum " + sum);
            //If successful parse, this line prints true 
            Debug.WriteLine("Parse: " + DateTime.TryParseExact(sum, "yyyy-MMMM-d", null, System.Globalization.DateTimeStyles.None, out dateSelected));
            //If successful parse, this line prints the selected date, if failed, the line prints 1/1/2001
            Debug.WriteLine("Date selected: " + dateSelected.ToShortDateString());
        }

        public DateTime GetDateSelected()
        {
            return dateSelected;
        }

        //TODO: auto fill the calendar! 
        //Then allow to shift dates
        //Then make it look pretty

        private void SetDataList()
        {     //daynumber, opacity, month, year
            dataList.Add(new DayViewModel(28, 0, "April", 2019)); 
            Date0.BindingContext = dataList[0];
            Date0Button.BindingContext = dataList[0];
            YearLabel.BindingContext = dataList[0];
            MonthLabel.BindingContext = dataList[0];

            dataList.Add(new DayViewModel(29, 0, "April", 2019));
            Date1.BindingContext = dataList[1];
            Date1Button.BindingContext = dataList[1];

            dataList.Add(new DayViewModel(30, 0, "April", 2019));
            Date2.BindingContext = dataList[2];
            Date2Button.BindingContext = dataList[2];

            dataList.Add(new DayViewModel(1, 0, "May", 2019));
            Date3.BindingContext = dataList[3];
            Date3Button.BindingContext = dataList[3];

            dataList.Add(new DayViewModel(2, 1, "May", 2019));
            Date4.BindingContext = dataList[4];
            Date4Button.BindingContext = dataList[4];

            dataList.Add(new DayViewModel(3, 0, "May", 2019));
            Date5.BindingContext = dataList[5];
            Date5Button.BindingContext = dataList[5];

            dataList.Add(new DayViewModel(4, 0, "May", 2019));
            Date6.BindingContext = dataList[6];
            Date6Button.BindingContext = dataList[6];

            dataList.Add(new DayViewModel(5, 0, "May", 2019));
            Date7.BindingContext = dataList[7];
            Date7Button.BindingContext = dataList[7];

            dataList.Add(new DayViewModel(6, 0, "May", 2019));
            Date8.BindingContext = dataList[8];
            Date8Button.BindingContext = dataList[8];

            dataList.Add(new DayViewModel(7, 0, "May", 2019));
            Date9.BindingContext = dataList[9];
            Date9Button.BindingContext = dataList[9];

            dataList.Add(new DayViewModel(8, 0, "May", 2019));
            Date10.BindingContext = dataList[10];
            Date10Button.BindingContext = dataList[10];

            dataList.Add(new DayViewModel(9, 0, "May", 2019));
            Date11.BindingContext = dataList[11];
            Date11Button.BindingContext = dataList[11];

            dataList.Add(new DayViewModel(10, 0, "May", 2019));
            Date12.BindingContext = dataList[12];
            Date12Button.BindingContext = dataList[12];

            dataList.Add(new DayViewModel(11, 0, "May", 2019));
            Date13.BindingContext = dataList[13];
            Date13Button.BindingContext = dataList[13];
        }

        
        
        private void CircleDate(int n)
        {
            for(int i=0; i<dataList.Count; i++)
            {
                if(i != n)
                {
                    dataList[i].DayOpacity = 0;
                }
            }
            dataList[n].DayOpacity = 1;
        }

        private void ChangeBinding(int n)
        {
            MonthLabel.BindingContext = dataList[n];
            YearLabel.BindingContext = dataList[n];
            //Debug.WriteLine("Changed month and year binding for box: " + n);
        }

        public void SelectDay(int n)
        {
            ChangeBinding(n);
            CircleDate(n);
            SetDateSelected(n);
        }




        //Event Handlers:
  
        private void Date0Button_Clicked(object sender, EventArgs e)
        {
            //var button = sender as Button;
            //var theValue = button.Id;
            //YearLabel.Text = theValue.ToString(); //todo: know which date is pressed.

            SelectDay(0);            
        }

        private void Date1Button_Clicked(object sender, EventArgs e)
        {
            SelectDay(1);
        }

        private void Date2Button_Clicked(object sender, EventArgs e)
        {
            SelectDay(2);
        }

        private void Date3Button_Clicked(object sender, EventArgs e)
        {
            SelectDay(3);

        }

        private void Date4Button_Clicked(object sender, EventArgs e)
        {
            SelectDay(4);
        }

        private void Date5Button_Clicked(object sender, EventArgs e)
        {
            SelectDay(5);
        }

        private void Date6Button_Clicked(object sender, EventArgs e)
        {
            SelectDay(6);
        }

        private void Date7Button_Clicked(object sender, EventArgs e)
        {
            SelectDay(7);
        }

        private void Date8Button_Clicked(object sender, EventArgs e)
        {
            SelectDay(8);
        }

        private void Date9Button_Clicked(object sender, EventArgs e)
        {
            SelectDay(9);
        }

        private void Date10Button_Clicked(object sender, EventArgs e)
        {
            SelectDay(10);
        }

        private void Date11Button_Clicked(object sender, EventArgs e)
        {
            SelectDay(11);
        }

        private void Date12Button_Clicked(object sender, EventArgs e)
        {
            SelectDay(12);
        }

        private void Date13Button_Clicked(object sender, EventArgs e)
        {
            SelectDay(13);
        }
    }
}