namespace ModernXamarinCalendar.Models
{
    internal static class MessagingEvent
    {
        //* Static Properties
        internal static string DayButtonClicked => nameof(DayButtonClicked);
        internal static string SelectedDateChanged => nameof(SelectedDateChanged);
        internal static string ShiftDays => nameof(ShiftDays);
    }
}