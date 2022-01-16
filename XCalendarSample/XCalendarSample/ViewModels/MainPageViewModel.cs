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
        public List<SelectionMode> SelectionModes { get; set; } = Enum.GetValues(typeof(SelectionMode)).Cast<SelectionMode>().ToList();
        public List<PageStartMode> PageStartModes { get; set; } = Enum.GetValues(typeof(PageStartMode)).Cast<PageStartMode>().ToList();
        public List<NavigationMode> NavigationModes { get; set; } = Enum.GetValues(typeof(NavigationMode)).Cast<NavigationMode>().ToList();
        public List<NavigationLimitMode> NavigationLimitModes { get; set; } = Enum.GetValues(typeof(NavigationLimitMode)).Cast<NavigationLimitMode>().ToList();
        public List<DayOfWeek> DaysOfWeek { get; set; } = Enum.GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>().ToList();
        public DateTime NavigatedDate { get; set; } = DateTime.Today;
        public DateTime DayRangeMinimumDate { get; set; } = DateTime.Today.AddYears(-5);
        public DateTime DayRangeMaximumDate { get; set; } = DateTime.Today.AddYears(5);
        public DayOfWeek StartOfWeek { get; set; } = DayOfWeek.Monday;
        public SelectionMode SelectionMode { get; set; } = SelectionMode.Multiple;
        public NavigationLimitMode NavigationLimitMode { get; set; } = NavigationLimitMode.LoopMinimumAndMaximumAndScopeToDayRange;
        public NavigationMode NavigationMode { get; set; } = NavigationMode.ByPage;
        public PageStartMode PageStartMode { get; set; } = PageStartMode.NavigatedMonth;
    }
}
