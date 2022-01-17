using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;
using XCalendar.Enums;
using XCalendarSample.Popups;

namespace XCalendarSample.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        #region Properties
        public DateTime? SelectedDate { get; set; } = DateTime.Today;
        public ObservableRangeCollection<DateTime> SelectedDates { get; } = new ObservableRangeCollection<DateTime>() { DateTime.Today };
        public List<XCalendar.Enums.SelectionMode> SelectionModes { get; set; } = Enum.GetValues(typeof(XCalendar.Enums.SelectionMode)).Cast<XCalendar.Enums.SelectionMode>().ToList();
        public List<PageStartMode> PageStartModes { get; set; } = Enum.GetValues(typeof(PageStartMode)).Cast<PageStartMode>().ToList();
        public List<NavigationMode> NavigationModes { get; set; } = Enum.GetValues(typeof(NavigationMode)).Cast<NavigationMode>().ToList();
        public List<NavigationLimitMode> NavigationLimitModes { get; set; } = Enum.GetValues(typeof(NavigationLimitMode)).Cast<NavigationLimitMode>().ToList();
        public List<DayOfWeek> DaysOfWeek { get; set; } = new List<DayOfWeek>()
        {
            DayOfWeek.Monday,
            DayOfWeek.Tuesday,
            DayOfWeek.Wednesday,
            DayOfWeek.Thursday,
            DayOfWeek.Friday,
            DayOfWeek.Saturday,
            DayOfWeek.Sunday
        };
        public DateTime NavigatedDate { get; set; } = DateTime.Today;
        public DateTime DayRangeMinimumDate { get; set; } = DateTime.Today.AddYears(-5);
        public DateTime DayRangeMaximumDate { get; set; } = DateTime.Today.AddYears(5);
        public DayOfWeek StartOfWeek { get; set; } = DayOfWeek.Monday;
        public ObservableRangeCollection<DayOfWeek> DayNamesOrder { get; } = new ObservableRangeCollection<DayOfWeek>()
        {
            DayOfWeek.Monday,
            DayOfWeek.Tuesday,
            DayOfWeek.Wednesday,
            DayOfWeek.Thursday,
            DayOfWeek.Friday,
            DayOfWeek.Saturday,
            DayOfWeek.Sunday
        };
        public XCalendar.Enums.SelectionMode SelectionMode { get; set; } = XCalendar.Enums.SelectionMode.Multiple;
        public NavigationLimitMode NavigationLimitMode { get; set; } = NavigationLimitMode.LoopMinimumAndMaximumAndScopeToDayRange;
        public NavigationMode NavigationMode { get; set; } = NavigationMode.ByMonth;
        public PageStartMode PageStartMode { get; set; } = PageStartMode.NavigatedMonth;
        #endregion

        #region Commands
        public ICommand ShowDayNamesOrderDialogCommand { get; set; }
        #endregion

        #region Constructors
        public MainPageViewModel()
        {
            ShowDayNamesOrderDialogCommand = new Command(ShowDayNamesOrderDialog);
        }
        #endregion

        #region Methods
        public async void ShowDayNamesOrderDialog()
        {
            IEnumerable<DayOfWeek> NewDayNamesOrder = (await Application.Current.MainPage.ShowPopupAsync(new ConstructListDialogPopup(DayNamesOrder, DaysOfWeek))).Cast<DayOfWeek>();
            DayNamesOrder.ReplaceRange(NewDayNamesOrder);
        }
        #endregion
    }
}
