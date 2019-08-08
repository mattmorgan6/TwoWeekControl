using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ModernXamarinCalendar.ViewModels;

namespace ModernXamarinCalendar.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DayControl : ContentView
    {
        //* Private Properties
        private readonly DayViewModel viewModel;

        //* Public Properties
        public DateTime Date => viewModel.Date;

        //* Constructors
        public DayControl(DateTime date, DateTime selectedDate, int row, int col)
        {
            InitializeComponent();

            SetValue(Grid.RowProperty, row);
            SetValue(Grid.ColumnProperty, col);

            BindingContext = viewModel = new DayViewModel(date, selectedDate);

            viewModel.PropertyChanged += (sender, args) => OnPropertyChanged(args.PropertyName);
        }
    }
}