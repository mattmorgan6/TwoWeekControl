using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ModernXamarinCalendar.Controls
{
    /// <summary>
    /// This class is responsible for displaying a day name in
    /// the day names row above the TwoWeekControl.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DateLabelControl : ContentView
    {
        //* Static Properties
        public static readonly BindableProperty ForegroundColorProperty = BindableProperty.Create(
            propertyName: nameof(ForegroundColor),
            returnType: typeof(Color),
            declaringType: typeof(DateLabelControl),
            defaultValue: Color.Black);

        //* Public Properties
        public Color ForegroundColor
        {
            get => (Color) GetValue(ForegroundColorProperty);
            set => SetValue(ForegroundColorProperty, value);
        }

        /// <summary>
        /// The 3 letter abbreviation of the day shown by this control.
        /// </summary>
        public string ShortDayName { get; private set; }

        //* Constructors
        public DateLabelControl(DateTime date, int row, int col)
        {
            ShortDayName = date.ToString("ddd").ToUpper();

            InitializeComponent();
            BindingContext = this;

            SetValue(Grid.RowProperty, row);
            SetValue(Grid.ColumnProperty, col);
        }
    }
}