using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ModernXamarinCalendar.ViewModels;

namespace ModernXamarinCalendar.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DateLabelControl : ContentView
    {
        //* Static Properties
        public static readonly BindableProperty ForegroundColorProperty = BindableProperty.Create(
            propertyName: nameof(ForegroundColor),
            returnType: typeof(Color),
            declaringType: typeof(DateLabelControl),
            defaultValue: Color.Black,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: ForegroundColorProperty_Changed);

        //* Private Properties
        private readonly DateLabelViewModel viewModel;

        //* Public Properties
        public Color ForegroundColor
        {
            get => viewModel.ForegroundColor;
            set => viewModel.ForegroundColor = value;
        }

        //* Constructors
        public DateLabelControl(DateTime date, int row, int col)
        {
            InitializeComponent();

            BindingContext = viewModel = new DateLabelViewModel(date);

            SetValue(Grid.RowProperty, row);
            SetValue(Grid.ColumnProperty, col);
        }

        //* Event Handlers
        private static void ForegroundColorProperty_Changed(BindableObject bindable, object oldValue, 
            object newValue)
        {
            DateLabelControl control = (DateLabelControl) bindable;
            control.ForegroundColor = (Color) newValue;
        }
    }
}