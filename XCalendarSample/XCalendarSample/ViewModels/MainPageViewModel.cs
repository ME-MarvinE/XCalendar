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
        public ICommand ShowSelectionModeDialogCommand { get; set; }
        public ICommand ShowNavigationLimitModeDialogCommand { get; set; }
        public ICommand ShowNavigationModeDialogCommand { get; set; }
        public ICommand ShowPageStartModeDialogCommand { get; set; }
        public ICommand ShowStartOfWeekDialogCommand { get; set; }
        #endregion

        #region Constructors
        public MainPageViewModel()
        {
            ShowDayNamesOrderDialogCommand = new Command(ShowDayNamesOrderDialog);
            ShowSelectionModeDialogCommand = new Command(ShowSelectionModeDialog);
            ShowNavigationLimitModeDialogCommand = new Command(ShowNavigationLimitModeDialog);
            ShowNavigationModeDialogCommand = new Command(ShowNavigationModeDialog);
            ShowPageStartModeDialogCommand = new Command(ShowPageStartModeDialog);
            ShowStartOfWeekDialogCommand = new Command(ShowStartOfWeekDialog);
        }
        #endregion

        #region Methods
        public async void ShowDayNamesOrderDialog()
        {
            IEnumerable<DayOfWeek> NewDayNamesOrder = (await Application.Current.MainPage.ShowPopupAsync(new ConstructListDialogPopup(DayNamesOrder, DaysOfWeek))).Cast<DayOfWeek>();
            DayNamesOrder.ReplaceRange(NewDayNamesOrder);
        }
        public async void ShowSelectionModeDialog()
        {
            SelectionMode = (XCalendar.Enums.SelectionMode)await Application.Current.MainPage.ShowPopupAsync(new SelectItemDialogPopup(SelectionMode, SelectionModes));
        }
        public async void ShowNavigationModeDialog()
        {
            NavigationMode = (NavigationMode)await Application.Current.MainPage.ShowPopupAsync(new SelectItemDialogPopup(NavigationMode, NavigationModes));
        }
        public async void ShowNavigationLimitModeDialog()
        {
            NavigationLimitMode = (NavigationLimitMode)await Application.Current.MainPage.ShowPopupAsync(new SelectItemDialogPopup(NavigationLimitMode, NavigationLimitModes));
        }
        public async void ShowPageStartModeDialog()
        {
            PageStartMode = (PageStartMode)await Application.Current.MainPage.ShowPopupAsync(new SelectItemDialogPopup(PageStartMode, PageStartModes));
        }
        public async void ShowStartOfWeekDialog()
        {
            StartOfWeek = (DayOfWeek)await Application.Current.MainPage.ShowPopupAsync(new SelectItemDialogPopup(StartOfWeek, DaysOfWeek));
        }
        #endregion
    }
}