using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TwoWeekControl.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeekControl : ContentView
    {
        //* Public Properties
        public DateTime DateSelected { get; private set; }

        //* Private Properties
        private List<DayViewModel> dataList { get; set; }

        //* Constructors
        public WeekControl()
        {
            InitializeComponent();

            // Initialises the data list with data, needs to be full for
            // FillDatesWithToday() to work
            setDataList();
            FillDatesWithToday();
        }

        //* Public Methods

        /// <summary>
        /// Populates the calendar with the week of today and selects today.
        /// </summary>
        public void FillDatesWithToday()
        {
            DateTime today = DateTime.Now;

            // 0 is sunday ... 6 is saturday
            int todayOfWeek = (int) today.DayOfWeek;
             
            changeBindingDate(todayOfWeek, today);

            DateTime temp = today.AddDays(1);

            // Populates days after today
            for (int i = todayOfWeek + 1; i < dataList.Count; i++)
            {
                changeBindingDate(i, temp);
                temp = temp.AddDays(1);
            }

            temp = today;

            // Populates days before today
            for (int i = todayOfWeek - 1; i >= 0; i--)
            {
                temp = temp.AddDays(-1);
                changeBindingDate(i, temp);
            }

            selectDay(todayOfWeek);
        }

        //* Private Methods

        private void changeBindingDate(int i, DateTime newDateTime)
        {
            dataList[i].DayNumber = newDateTime.Day;
            dataList[i].Month = newDateTime.ToString("MMMM");
            dataList[i].Year = newDateTime.Year;

            if (newDateTime < DateTime.Today)
                dataList[i].NumOpacity = 0.6;
            else
                dataList[i].NumOpacity = 1;

            if (newDateTime == DateSelected)
                selectDay(i);
            else
                dataList[i].DayOpacity = 0;
        }

        private void changeMonthYearBinding(int n)
        {
            MonthLabel.BindingContext = dataList[n];
            YearLabel.BindingContext = dataList[n];
        }

        private void circleDate(int n)
        {
            for (int i = 0; i < dataList.Count; i++)
            {
                if (i != n)
                    dataList[i].DayOpacity = 0;
            }

            dataList[n].DayOpacity = 1;
        }

        private void selectDay(int n)
        {
            changeMonthYearBinding(n);
            circleDate(n);
        }

        private void setDataList()
        {
            dataList = new List<DayViewModel>();
            dataList.Add(new DayViewModel(28, 0, "April", 2019, 1, "White"));

            Date0.BindingContext = dataList[0];
            Date0Button.BindingContext = dataList[0];
            YearLabel.BindingContext = dataList[0];
            MonthLabel.BindingContext = dataList[0];
            LeftArrow.BindingContext = dataList[0];
            RightArrow.BindingContext = dataList[0];
            AddNewEvent.BindingContext = dataList[0];

            dataList.Add(new DayViewModel(29, 0, "April", 2019, 1, "White"));
            Date1.BindingContext = dataList[1];
            Date1Button.BindingContext = dataList[1];

            dataList.Add(new DayViewModel(30, 0, "April", 2019, 1, "White"));
            Date2.BindingContext = dataList[2];
            Date2Button.BindingContext = dataList[2];

            dataList.Add(new DayViewModel(1, 0, "May", 2019, 1, "White"));
            Date3.BindingContext = dataList[3];
            Date3Button.BindingContext = dataList[3];

            dataList.Add(new DayViewModel(2, 1, "May", 2019, 1, "White"));
            Date4.BindingContext = dataList[4];
            Date4Button.BindingContext = dataList[4];

            dataList.Add(new DayViewModel(3, 0, "May", 2019, 1, "White"));
            Date5.BindingContext = dataList[5];
            Date5Button.BindingContext = dataList[5];

            dataList.Add(new DayViewModel(4, 0, "May", 2019, 1, "White"));
            Date6.BindingContext = dataList[6];
            Date6Button.BindingContext = dataList[6];

            dataList.Add(new DayViewModel(5, 0, "May", 2019, 1, "White"));
            Date7.BindingContext = dataList[7];
            Date7Button.BindingContext = dataList[7];

            dataList.Add(new DayViewModel(6, 0, "May", 2019, 1, "White"));
            Date8.BindingContext = dataList[8];
            Date8Button.BindingContext = dataList[8];

            dataList.Add(new DayViewModel(7, 0, "May", 2019, 1, "White"));
            Date9.BindingContext = dataList[9];
            Date9Button.BindingContext = dataList[9];

            dataList.Add(new DayViewModel(8, 0, "May", 2019, 1, "White"));
            Date10.BindingContext = dataList[10];
            Date10Button.BindingContext = dataList[10];

            dataList.Add(new DayViewModel(9, 0, "May", 2019, 1, "White"));
            Date11.BindingContext = dataList[11];
            Date11Button.BindingContext = dataList[11];

            dataList.Add(new DayViewModel(10, 0, "May", 2019, 1, "White"));
            Date12.BindingContext = dataList[12];
            Date12Button.BindingContext = dataList[12];

            dataList.Add(new DayViewModel(11, 0, "May", 2019, 1, "White"));
            Date13.BindingContext = dataList[13];
            Date13Button.BindingContext = dataList[13];
        }

        private void shiftDatesForward()
        {
            DateTime lastDate = DateTime.Today;
            string day = dataList[dataList.Count - 1].DayNumber.ToString();
            string month = dataList[dataList.Count - 1].Month;
            string year = dataList[dataList.Count - 1].Year.ToString();
            string sum = year + "-" + month + "-" + day;

            for(int i = 0; i < dataList.Count; i++)
            {
                lastDate = lastDate.AddDays(1);
                changeBindingDate(i, lastDate);
            }
        }

        private void shiftDatesBackward()
        {
            DateTime firstDate = DateTime.Today;
            string day = dataList[0].DayNumber.ToString();
            string month = dataList[0].Month;
            string year = dataList[0].Year.ToString();
            string sum = year + "-" + month + "-" + day;

            for (int i = dataList.Count - 1; i >= 0; i--)
            {
                firstDate = firstDate.AddDays(-1);
                changeBindingDate(i, firstDate);
            }
        }







        //* Event Handlers
        private void AddNewEvent_Clicked(object sender, EventArgs e)
        {
            // TODO: Link this with the Controller
        }

        private void Date0Button_Clicked(object sender, EventArgs e) => selectDay(0);
        private void Date1Button_Clicked(object sender, EventArgs e) => selectDay(1);
        private void Date2Button_Clicked(object sender, EventArgs e) => selectDay(2);
        private void Date3Button_Clicked(object sender, EventArgs e) => selectDay(3);
        private void Date4Button_Clicked(object sender, EventArgs e) => selectDay(4);
        private void Date5Button_Clicked(object sender, EventArgs e) => selectDay(5);
        private void Date6Button_Clicked(object sender, EventArgs e) => selectDay(6);
        private void Date7Button_Clicked(object sender, EventArgs e) => selectDay(7);
        private void Date8Button_Clicked(object sender, EventArgs e) => selectDay(8);
        private void Date9Button_Clicked(object sender, EventArgs e) => selectDay(9);
        private void Date10Button_Clicked(object sender, EventArgs e) => selectDay(10);
        private void Date11Button_Clicked(object sender, EventArgs e) => selectDay(11);
        private void Date12Button_Clicked(object sender, EventArgs e) => selectDay(12);
        private void Date13Button_Clicked(object sender, EventArgs e) => selectDay(13);

        private void LeftArrow_Clicked(object sender, EventArgs e) => shiftDatesBackward();
        private void RightArrow_Clicked(object sender, EventArgs e) => shiftDatesForward();
    }
}