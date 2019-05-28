using System;
using System.Collections.Generic;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ModernXamarinCalendar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeekControl : ContentView, INotifyPropertyChanged
    {
        //* Static Properties
        public static readonly BindableProperty ShowDayNameProperty = BindableProperty.Create(
            propertyName: nameof(ShowDayName),
            returnType: typeof(bool),
            declaringType: typeof(WeekControl),
            defaultValue: false,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: ShowDayNameProperty_Changed);

        //* Private Properties

        /// <summary>
        /// Determines whether the SUN-SAT labels appear above the calendar days.
        /// </summary>
        private bool showDayName = false;

        /// <summary>
        /// DateTime object of the date selected on the calendar.
        /// </summary>
        private DateTime dateSelected;

        /// <summary>
        /// List of DayViewModel objects that represent calendar days.
        /// </summary>
        private List<DayViewModel> dataList = new List<DayViewModel>();

        //* Public Properties
        public bool ShowDayName
        {
            get => showDayName;
            set
            {
                if (value != showDayName)
                {
                    showDayName = value;
                    OnNotifyPropertyChanged(nameof(ShowDayName));
                }
            }
        }

        public DateTime DateSelected
        {
            get => dateSelected;
            private set
            {
                if (value != dateSelected)
                {
                    dateSelected = value;
                    OnNotifyPropertyChanged(nameof(DateSelected));
                    OnNotifyPropertyChanged(nameof(DateFormatted));
                }
            }
        }

        /// <summary>
        /// This sets the Title to the ListView with the DateSelected
        /// </summary>
        public string DateFormatted => DateSelected.ToString("dddd, MMMM dd");

        //* Public Events
        public event EventHandler DataSelectedChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        //* Constructors
        public WeekControl()
        {
            InitializeComponent();

            setUpDateElements();
            fillDatesWithToday();

            setUpDateLabels();
        }

        //* Public Methods
        public void ShiftDatesBackward()
        {
            DateTime firstDate = dataList[0].Date;

            for (int i = dataList.Count - 1; i >= 0; i--)
            {
                firstDate = firstDate.AddDays(-1);
                changeBindingDate(i, firstDate);
            }
        }

        public void ShiftDatesForward()
        {
            DateTime lastDate = dataList[dataList.Count - 1].Date;

            for (int i = 0; i < dataList.Count; i++)
            {
                lastDate = lastDate.AddDays(1);
                changeBindingDate(i, lastDate);
            }
        }

        // TODO: Put a little marker on today.

        //* Private Methods

        private void changeBindingDate(int i, DateTime date)
        {
            dataList[i].Date = date;

            if (date < DateTime.Today)
                dataList[i].NumOpacity = 0.6;
            else
                dataList[i].NumOpacity = 1;

            if (date == DateSelected)
                selectDay(i);
            else
                dataList[i].CircleOpacity = 0;
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
                    dataList[i].CircleOpacity = 0;
            }
            dataList[n].CircleOpacity = 1;
        }

        /// <summary>
        /// Populates the calendar with the week of today and selects today.
        /// </summary>
        private void fillDatesWithToday()
        {
            DateTime today = DateTime.Now;

            // 0 is Sunday ... 6 is Saturday
            int todayOfWeek = (int)today.DayOfWeek;

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

        /// <summary>
        /// Updates the DayViewModel bindings with new data.
        /// </summary>
        /// <param name="n">
        /// The index of the date on the calendar (0 is the first date, 13 is the last date)
        /// </param>
        private void selectDay(int n)
        {
            changeMonthYearBinding(n);
            circleDate(n);

            DateSelected = dataList[n].Date;
        }

        /// <summary>
        /// Sets up the DayViewModels and populates the datalist for the calendar.
        /// </summary>
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
                        LeftArrowImageButton.BindingContext = dataList[0];
                        RightArrowImageButton.BindingContext = dataList[0];
                    }

                    // Label for the date number
                    Label tempLabel = new Label();
                    tempLabel.SetValue(Grid.RowProperty, i + 3);
                    tempLabel.SetValue(Grid.ColumnProperty, j);
                    tempLabel.HorizontalOptions = LayoutOptions.Center;
                    tempLabel.VerticalOptions = LayoutOptions.Center;

                    tempLabel.BindingContext = dataList[i * 7 + j];
                    tempLabel.SetBinding(Label.TextProperty, new Binding(
                        string.Format("{0}.{1}", nameof(DayViewModel.Date),
                            nameof(DayViewModel.Date.Day))));
                    tempLabel.SetBinding(Label.TextColorProperty, new Binding(
                        nameof(DayViewModel.ColorTheme)));
                    tempLabel.SetBinding(OpacityProperty, new Binding(
                        nameof(DayViewModel.NumOpacity)));

                    MainGrid.Children.Add(tempLabel);

                    // Button behind the Label for the touch event when the number is clicked
                    Button tempButton = new Button();
                    tempButton.SetValue(Grid.RowProperty, i + 3);
                    tempButton.SetValue(Grid.ColumnProperty, j);
                    tempButton.VerticalOptions = LayoutOptions.Center;
                    tempButton.HorizontalOptions = LayoutOptions.Center;
                    tempButton.Margin = new Thickness(-1, 0, 0, 0);
                    tempButton.HeightRequest = 30;
                    tempButton.WidthRequest = 30;
                    tempButton.BackgroundColor = Color.Transparent;
                    tempButton.BorderWidth = 1;
                    tempButton.CornerRadius = 15;
                    tempButton.Clicked += DateButton_Clicked;

                    tempButton.BindingContext = dataList[i * 7 + j];
                    tempButton.SetBinding(Button.BorderColorProperty, new Binding(
                        nameof(DayViewModel.ColorTheme)));
                    tempButton.SetBinding(OpacityProperty, new Binding(
                        nameof(DayViewModel.CircleOpacity)));

                    MainGrid.Children.Add(tempButton);
                }
            }
        }

        /// <summary>
        /// The SUN - SAT Labels
        /// </summary>
        private void setUpDateLabels()
        {
            // Date chosen as 1 corresponds to Sunday
            for (DateTime d = new DateTime(2018, 7, 1); d.Day < 8; d = d.AddDays(1))
            {
                Label tempLabel = new Label();
                tempLabel.SetValue(Grid.RowProperty, 2);
                tempLabel.SetValue(Grid.ColumnProperty, d.Day - 1);
                tempLabel.Style = Resources["DateLabelStyle"] as Style;
                tempLabel.Text = d.ToString("ddd").ToUpper();

                tempLabel.BindingContext = this;
                tempLabel.SetBinding(IsVisibleProperty, new Binding(
                    nameof(ShowDayName)));

                MainGrid.Children.Add(tempLabel);
            }
        }

        //* Event Handlers
        private static void ShowDayNameProperty_Changed(BindableObject bindable, object oldValue,
            object newValue)
        {
            WeekControl control = (WeekControl)bindable;
            control.ShowDayName = (bool)newValue;
        }

        /// <summary>
        /// Handles the event when any of the numbered dates is pressed.
        /// </summary>
        private void DateButton_Clicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            int column = (int)button.GetValue(Grid.ColumnProperty);
            int row = (int)button.GetValue(Grid.RowProperty);

            selectDay((row - 3) * 7 + column);

            // Raise the event
            DataSelectedChanged?.Invoke(this, e);
        }

        private void LeftArrowImageButton_Clicked(object sender, EventArgs e) =>
            ShiftDatesBackward();

        public void OnNotifyPropertyChanged(string property) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));

        private void RightArrowImageButton_Clicked(object sender, EventArgs e) =>
            ShiftDatesForward();
    }
}