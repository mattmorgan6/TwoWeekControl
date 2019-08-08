using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ModernXamarinCalendar.ViewModels;

namespace ModernXamarinCalendar.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DayControl : ContentView
    {
        //* Static Properties
        public static readonly BindableProperty ForegroundColorProperty = BindableProperty.Create(
            propertyName: nameof(ForegroundColor),
            returnType: typeof(Color),
            declaringType: typeof(DayControl),
            defaultValue: Color.Black,
            defaultBindingMode: BindingMode.TwoWay);

        //* Private Properties
        private readonly DayViewModel viewModel;

        //* Public Properties
        public Color ForegroundColor
        {
            get => viewModel.ForegroundColor;
            set => viewModel.ForegroundColor = value;
        }

        public DateTime Date => viewModel.Date;

        //* Constructors
        public DayControl(DateTime date, DateTime selectedDate, int row, int col)
        {
            InitializeComponent();

            BindingContext = viewModel = new DayViewModel(date, selectedDate);

            viewModel.PropertyChanged += (sender, args) => OnPropertyChanged(args.PropertyName);

            SetValue(Grid.RowProperty, row);
            SetValue(Grid.ColumnProperty, col);
        }
    }
}