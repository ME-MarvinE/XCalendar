using System;
using Xamarin.CommunityToolkit.ObjectModel;

namespace XCalendarFormsSample.ViewModels
{
    public class UsingCalendarDayViewExampleViewModel : BaseViewModel
    {
        public DateTime NavigatedDate { get; set; } = DateTime.Now;
        public ObservableRangeCollection<DateTime> SelectedDates { get; } = new ObservableRangeCollection<DateTime>() { DateTime.Now };
    }
}
