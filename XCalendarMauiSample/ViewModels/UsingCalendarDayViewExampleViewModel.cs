using XCalendar.Maui;

namespace XCalendarMauiSample.ViewModels
{
    public class UsingCalendarDayViewExampleViewModel : BaseViewModel
    {
        public DateTime NavigatedDate { get; set; } = DateTime.Now;
        public ObservableRangeCollection<DateTime> SelectedDates { get; } = new ObservableRangeCollection<DateTime>() { DateTime.Now };
    }
}
