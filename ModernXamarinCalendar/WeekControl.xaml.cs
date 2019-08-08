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
        public static readonly BindableProperty ShowDayNameProperty = BindableProperty.Create(
            propertyName: nameof(ShowDayName),
            returnType: typeof(bool),
            declaringType: typeof(WeekControl),
            defaultValue: false,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: ShowDayNameProperty_Changed);

        //* Public Properties
        public bool ShowDayName
        {
            get => ViewModel.ShowDayName;
            set => ViewModel.ShowDayName = value;
        }

        public DateTime SelectedDate => ViewModel.SelectedDate;

        //* Public Events
        public event EventHandler<SelectedDateChangedEventArgs> SelectedDateChanged;

        //* Constructors
        public WeekControl()
        {
            InitializeComponent();

            setUpDayControls();
            setUpDateLabels();

            ViewModel.PropertyChanged += (sender, args) => OnPropertyChanged(args.PropertyName);

            MessagingCenter.Subscribe<DayViewModel, DateTime>(this,
                MessagingEvent.DayButtonClicked.ToString(),
                (sender, args) => SelectedDateChanged?
                    .Invoke(this, new SelectedDateChangedEventArgs(args)));
        }

        // TODO: Put a little marker on today.

        /// <summary>
        /// The SUN - SAT Labels
        /// </summary>
        private void setUpDateLabels()
        {
            // Date chosen as 1 corresponds to Sunday
            for (DateTime date = new DateTime(2018, 7, 1); date.Day < 8; date = date.AddDays(1))
            {
                var control = new DateLabelControl(date, 2, date.Day - 1);
                control.SetBinding(IsVisibleProperty, 
                    new Binding(nameof(ShowDayName)));

                MainGrid.Children.Add(control);
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
                    ViewModel.DayControls.Add(control);
                    MainGrid.Children.Add(control);

                    date = date.AddDays(1);
                }
            }
        }

        //* Event Handlers
        private static void ShowDayNameProperty_Changed(BindableObject bindable, object oldValue,
            object newValue)
        {
            WeekControl control = (WeekControl) bindable;
            control.ShowDayName = (bool) newValue;
        }
    }
}