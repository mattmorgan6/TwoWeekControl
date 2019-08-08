using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ModernXamarinCalendar.ViewModels;

namespace ModernXamarinCalendar.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DateLabelControl : ContentView
    {
        //* Constructors
        public DateLabelControl(DateTime date, int row, int col)
        {
            InitializeComponent();

            BindingContext = new DateLabelViewModel(date);

            SetValue(Grid.RowProperty, row);
            SetValue(Grid.ColumnProperty, col);
        }
    }
}