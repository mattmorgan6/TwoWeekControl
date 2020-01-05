using System;
using System.Collections.Generic;
using System.Windows.Input;

using Xamarin.Forms;

using ModernXamarinCalendar.Controls;
using ModernXamarinCalendar.Models;

namespace ModernXamarinCalendar.ViewModels
{
    public class WeekControlViewModel : BaseViewModel
    {
        //* Private Properties
        private bool showDayName = false;

        private Color foregroundColor;

        private DateTime shownDate;
        private DateTime selectedDate;

        //* Public Properties
        public bool ShowDayName
        {
            get => showDayName;
            set => setProperty(ref showDayName, value);
        }

        public Color ForegroundColor
        {
            get => foregroundColor;
            set => setProperty(ref foregroundColor, value);
        }

        public DateTime ShownDate
        {
            get => shownDate;
            set
            {
                setProperty(ref shownDate, value);
                OnPropertyChanged(nameof(MonthFormatted));
            }
        }
        /// <summary>
        /// DateTime object of the date selected on the calendar.
        /// </summary>
        public DateTime SelectedDate
        {
            get => selectedDate;
            set
            {
                setProperty(ref selectedDate, value);
                ShownDate = value;
                MessagingCenter.Send(this,
                   MessagingEvent.SelectedDateChanged.ToString(), value);
            } 
        }

        public ICommand ShiftDatesBackwardsCommand { get; }
        public ICommand ShiftDatesForwardsCommand { get; }

        public List<DayControl> DayControls;

        public string MonthFormatted => ShownDate.ToString("MMMM");

        //* Constructors
        public WeekControlViewModel()
        {
            SelectedDate = DateTime.Today;
            DayControls = new List<DayControl>();

            MessagingCenter.Subscribe<DayViewModel, DateTime>(this,
                MessagingEvent.DayButtonClicked.ToString(),
                (sender, args) => SelectedDate = args.Date);

            ShiftDatesBackwardsCommand = new Command(() => ExecuteShiftDatesCommand(false));
            ShiftDatesForwardsCommand = new Command(() => ExecuteShiftDatesCommand(true));
        }

        //* Public Methods
        public void ExecuteShiftDatesCommand(bool shiftForward)
        {
            int offset = shiftForward ? 14 : -14;

            MessagingCenter.Send(this,
                MessagingEvent.ShiftDays.ToString(),
                offset);

            ShownDate = DayControls[0].Date;
        }

        public void OverrideSelectedDate(DateTime newSelectedDate)
        {
            SelectedDate = newSelectedDate;

            while (SelectedDate < DayControls[0].Date || SelectedDate > DayControls[13].Date)
                ExecuteShiftDatesCommand(SelectedDate >= DayControls[0].Date);
        }
    }
}