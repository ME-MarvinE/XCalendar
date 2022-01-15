using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.CommunityToolkit.ObjectModel;
using XCalendar.Enums;

namespace XCalendarSample.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public DateTime? SelectedDate { get; set; } = DateTime.Today;
        public ObservableRangeCollection<DateTime> SelectedDates { get; set; } = new ObservableRangeCollection<DateTime>() { DateTime.Today };
        public List<CalendarSelectionMode> SelectionModes { get; set; } = Enum.GetValues(typeof(CalendarSelectionMode)).Cast<CalendarSelectionMode>().ToList();
        public List<CalendarPageStartMode> PageStartModes { get; set; } = Enum.GetValues(typeof(CalendarPageStartMode)).Cast<CalendarPageStartMode>().ToList();
        public List<CalendarNavigationMode> NavigationModes { get; set; } = Enum.GetValues(typeof(CalendarNavigationMode)).Cast<CalendarNavigationMode>().ToList();
        public List<CalendarNavigationLimitMode> NavigationLimitModes { get; set; } = Enum.GetValues(typeof(CalendarNavigationLimitMode)).Cast<CalendarNavigationLimitMode>().ToList();
        public List<DayOfWeek> DaysOfWeek { get; set; } = Enum.GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>().ToList();
        public DateTime NavigatedDate { get; set; } = DateTime.Today;
    }
}
