using System;
using System.Windows.Input;

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
        public static readonly BindableProperty CommandProperty = BindableProperty.Create(
            propertyName: nameof(Command),
            returnType: typeof(ICommand),
            declaringType: typeof(WeekControl),
            defaultValue: null);

        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(
            propertyName: nameof(CommandParameter),
            returnType: typeof(object),
            declaringType: typeof(WeekControl),
            defaultValue: null);

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
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: ShowDayNameProperty_Changed);

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

        public ICommand Command
        {
            get => (ICommand) GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public object CommandParameter
        {
            get => GetValue(CommandParameterProperty);
            set => SetValue(CommandParameterProperty, value);
        }

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

            SelectedDateChanged += (sender, args) =>
            {
                if (Command?.CanExecute(CommandParameter) ?? false)
                    Command.Execute(CommandParameter);
            };
        }

        // TODO: Put a little marker on today.

        //* Public Methods
        public void OverrideSelectedDate(DateTime newSelectedDate) =>
            ViewModel.OverrideSelectedDate(newSelectedDate);

        //* Private Methods

        /// <summary>
        /// The SUN - SAT Labels
        /// </summary>
        private void setUpDateLabels()
        {
            // Date chosen as 1 corresponds to Sunday
            for (DateTime date = new DateTime(2018, 7, 1); date.Day < 8; date = date.AddDays(1))
            {
                var control = new DateLabelControl(date, 2, date.Day - 1);

                control.SetBinding(DateLabelControl.ForegroundColorProperty, 
                    new Binding(nameof(ForegroundColor), source: this));
                control.SetBinding(IsVisibleProperty,
                    new Binding(nameof(ShowDayName), source: this));

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
                    control.SetBinding(DayControl.ForegroundColorProperty,
                        new Binding(nameof(ForegroundColor), source: this));

                    ViewModel.DayControls.Add(control);
                    MainGrid.Children.Add(control);

                    date = date.AddDays(1);
                }
            }
        }

        //* Event Handlers
        private static void ForegroundColorProperty_Changed(BindableObject bindable, object oldvalue, 
            object newValue)
        {
            WeekControl control = (WeekControl) bindable;
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