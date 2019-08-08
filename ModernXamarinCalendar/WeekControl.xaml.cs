using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ModernXamarinCalendar.Controls;
using ModernXamarinCalendar.Models;
using ModernXamarinCalendar.ViewModels;

namespace ModernXamarinCalendar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeekControl : ContentView
    {
        //* Static Properties
        public static readonly BindableProperty ForegroundColorProperty = BindableProperty.Create(
            propertyName: nameof(ForegroundColor),
            returnType: typeof(Color),
            declaringType: typeof(WeekControl),
            defaultValue: Color.Black,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: ForegroundColorProperty_Changed);
        public static readonly BindableProperty ShowDayNameProperty = BindableProperty.Create(
            propertyName: nameof(ShowDayName),
            returnType: typeof(bool),
            declaringType: typeof(WeekControl),
            defaultValue: false,
            defaultBindingMode: BindingMode.TwoWay);

        //* Public Properties
        public bool ShowDayName
        {
            get => ViewModel.ShowDayName;
            set => ViewModel.ShowDayName = value;
        }

        public Color ForegroundColor
        {
            get => ViewModel.ForegroundColor;
            set => ViewModel.ForegroundColor = value;
        }

        public DateTime SelectedDate => ViewModel.SelectedDate;

        //* Public Events
        public delegate void SelectedDateChangedEventHandler(SelectedDateChangedEventArgs args);
        public event SelectedDateChangedEventHandler SelectedDateChanged;

        //* Constructors
        public WeekControl()
        {
            InitializeComponent();

            setUpDayControls();

            ViewModel.PropertyChanged += (sender, args) => OnPropertyChanged(args.PropertyName);

            foreach (var control in ViewModel.DayControls)
                MainGrid.Children.Add(control);

            MessagingCenter.Subscribe<DayViewModel, DateTime>(this,
                MessagingEvent.DayButtonClicked.ToString(),
                (sender, args) => SelectedDateChanged?
                    .Invoke(new SelectedDateChangedEventArgs(args)));

            setUpDateLabels();
        }

        // TODO: Put a little marker on today.

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

        private void setUpDayControls()
        {
            DateTime date = DateTime.Today;
            int dayOfWeek = (int) date.DayOfWeek;
            date = date.AddDays(-1 * dayOfWeek);

            for (int row = 3; row < 5; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    var control = new DayControl(date, DateTime.Today, row, col);

                    control.SetBinding(DayControl.ForegroundColorProperty,
                        new Binding(nameof(ForegroundColor)));

                    ViewModel.DayControls.Add(control);

                    date = date.AddDays(1);
                }
            }
        }

        //* Event Handlers
        private static void ForegroundColorProperty_Changed(BindableObject bindable, object oldValue,
            object newValue)
        {
            WeekControl control = (WeekControl) bindable;
            control.OnPropertyChanged(nameof(ForegroundColor));
            control.ForegroundColor = (Color) newValue;
        }

        private static void ShowDayNameProperty_Changed(BindableObject bindable, object oldValue,
            object newValue)
        {
            WeekControl control = (WeekControl) bindable;
            control.ShowDayName = (bool) newValue;
        }
    }
}