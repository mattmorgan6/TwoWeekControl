using System;
using System.Collections.Generic;
using System.Diagnostics;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TwoWeekControl.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeekControl : ContentView
    {
        public DateTime dateSelected;


        public List<DayViewModel> dataList = new List<DayViewModel>();


        public WeekControl()
        {
            InitializeComponent();

            setUpDateElements();
            //SetDataList();  //fills up the data list with data, 
                            //  the list needs to be full for fillDatesWithToday() to work

            FillDatesWithToday();
        }

        private void setUpDateElements()
        {
            DateTime date = new DateTime(2019, 4, 28);

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    dataList.Add(new DayViewModel(date, 0, 1, Color.White));
                    date.AddDays(1);

                    if (i == 0 & j == 0)
                    {
                        YearLabel.BindingContext = dataList[0];
                        MonthLabel.BindingContext = dataList[0];
                        LeftArrowButton.BindingContext = dataList[0];
                        RightArrowButton.BindingContext = dataList[0];
                        PlusButton.BindingContext = dataList[0];
                    }

                    // Label for the date number
                    Label tempLabel = new Label();
                    tempLabel.SetValue(Grid.RowProperty, i + 2);
                    tempLabel.SetValue(Grid.ColumnProperty, j);
                    tempLabel.HorizontalOptions = LayoutOptions.Center;

                    tempLabel.BindingContext = dataList[i * 7 + j];
                    tempLabel.SetBinding(Label.TextProperty, new Binding("Date.Day"));
                    tempLabel.SetBinding(Label.TextColorProperty, new Binding("ColorTheme"));
                    tempLabel.SetBinding(OpacityProperty, new Binding("NumOpacity"));

                    MainGrid.Children.Add(tempLabel);

                    // Button behind the Label for the touch event when the number is clicked
                    Button tempButton = new Button();
                    tempButton.SetValue(Grid.RowProperty, i + 2);
                    tempButton.SetValue(Grid.ColumnProperty, j);
                    tempButton.BackgroundColor = Color.Transparent;
                    tempButton.CornerRadius = 10;
                    tempButton.BorderWidth = 1;
                    tempButton.Clicked += DateButton_Clicked;

                    tempButton.BindingContext = dataList[i * 7 + j];
                    tempButton.SetBinding(Button.BorderColorProperty, new Binding("ColorTheme"));
                    tempButton.SetBinding(OpacityProperty, new Binding("CircleOpacity"));

                    MainGrid.Children.Add(tempButton);
                }
            }
        }

        public void SetDateSelected(int n)
        {
            string year = dataList[n].Date.Year.ToString();
            string month = dataList[n].Month;
            string day = dataList[n].Date.Day.ToString();

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

        //TODO: >put a little marker on today.
        //      >put in a color option. :)

        //populates the calendar with the week of today and selects today.
        public void FillDatesWithToday()
        {
            DateTime today = DateTime.Now;

            int todayOfWeek = (int)today.DayOfWeek;  //0 is sunday ... 6 is saturday

            ChangeBindingDate(todayOfWeek, today);

            DateTime temp = today.AddDays(1);

            for (int i = todayOfWeek + 1; i < dataList.Count; i++)     //populates days after today
            {
                ChangeBindingDate(i, temp);
                temp = temp.AddDays(1);
            }

            temp = today;
            for (int i = todayOfWeek - 1; i >= 0; i--)       //populates days before today
            {
                temp = temp.AddDays(-1);
                ChangeBindingDate(i, temp);
            }

            SelectDay(todayOfWeek);
            //FadeOldDates();
        }

        private void ChangeBindingDate(int i, DateTime temp)
        {
            dataList[i].Date = temp;

            if (temp < DateTime.Today)
            {
                dataList[i].NumOpacity = 0.6;
            }
            else
            {
                dataList[i].NumOpacity = 1;
            }

            if (temp == dateSelected)
            {
                SelectDay(i);
            }
            else
            {
                dataList[i].CircleOpacity = 0;
            }
        }


        private void FadeOldDates()
        {
            int todayOfWeek = (int)DateTime.Now.DayOfWeek;

            for (int i = todayOfWeek - 1; i >= 0; i--)
            {
                dataList[i].NumOpacity = 0.6;
            }
        }

        private void CircleDate(int n)
        {
            for (int i = 0; i < dataList.Count; i++)
            {
                if (i != n)
                {
                    dataList[i].CircleOpacity = 0;
                }
            }
            dataList[n].CircleOpacity = 1;
        }

        private void ChangeMonthYearBinding(int n)
        {
            MonthLabel.BindingContext = dataList[n];
            YearLabel.BindingContext = dataList[n];
            //Debug.WriteLine("Changed month and year binding for box: " + n);
        }

        public void SelectDay(int n)
        {
            ChangeMonthYearBinding(n);
            CircleDate(n);
            SetDateSelected(n);
        }

        public void ShiftDatesForward()
        {
            DateTime lastDate = DateTime.Today;
            string day = dataList[dataList.Count - 1].Date.Day.ToString();
            string month = dataList[dataList.Count - 1].Month;
            string year = dataList[dataList.Count - 1].Date.Year.ToString();
            string sum = year + "-" + month + "-" + day;

            Debug.WriteLine("Parse: " + DateTime.TryParseExact(sum, "yyyy-MMMM-d", null, System.Globalization.DateTimeStyles.None, out lastDate));

            for (int i = 0; i < dataList.Count; i++)
            {
                lastDate = lastDate.AddDays(1);
                ChangeBindingDate(i, lastDate);
                Debug.WriteLine(lastDate.Date);
            }
        }

        public void ShiftDatesBackward()
        {
            DateTime firstDate = DateTime.Today;
            string day = dataList[0].Date.Day.ToString();
            string month = dataList[0].Month;
            string year = dataList[0].Date.Year.ToString();
            string sum = year + "-" + month + "-" + day;

            Debug.WriteLine("Parse: " + DateTime.TryParseExact(sum, "yyyy-MMMM-d", null, System.Globalization.DateTimeStyles.None, out firstDate));

            for (int i = dataList.Count - 1; i >= 0; i--)
            {
                firstDate = firstDate.AddDays(-1);
                ChangeBindingDate(i, firstDate);
                Debug.WriteLine(firstDate.Date);
            }
        }


        //Event Handlers:

        private void DateButton_Clicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            int column = (int) button.GetValue(Grid.ColumnProperty);
            int row = (int)button.GetValue(Grid.RowProperty);

            SelectDay((row - 2) * 7 + column);
        }

        //This is for the "+" button in the top left
        private void PlusButton_Clicked(object sender, EventArgs e)
        {
            //todo: link this with the controller class 
        }

        private void LeftArrowButton_Clicked(object sender, EventArgs e)
        {
            ShiftDatesBackward();
        }

        private void RightArrowButton_Clicked(object sender, EventArgs e)
        {
            ShiftDatesForward();
        }
    }
}