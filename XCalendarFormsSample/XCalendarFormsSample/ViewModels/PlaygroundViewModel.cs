using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;
using XCalendar.Core;
using XCalendar.Core.Enums;
using XCalendarFormsSample.Popups;

namespace XCalendarFormsSample.ViewModels
{
    public class PlaygroundViewModel : BaseViewModel
    {
        #region Properties
        public ObservableRangeCollection<DateTime> SelectedDates { get; } = new ObservableRangeCollection<DateTime>();
        public List<SelectionType> SelectionTypes { get; set; } = Enum.GetValues(typeof(SelectionType)).Cast<SelectionType>().ToList();
        public List<SelectionAction> SelectionActions { get; set; } = Enum.GetValues(typeof(SelectionAction)).Cast<SelectionAction>().ToList();
        public List<PageStartMode> PageStartModes { get; set; } = Enum.GetValues(typeof(PageStartMode)).Cast<PageStartMode>().ToList();
        public List<NavigationTimeUnit> NavigationTimeUnits { get; set; } = Enum.GetValues(typeof(NavigationTimeUnit)).Cast<NavigationTimeUnit>().ToList();
        public List<NavigationLoopMode> NavigationLoopModes { get; set; } = Enum.GetValues(typeof(NavigationLoopMode)).Cast<NavigationLoopMode>().ToList();
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
        public DateTime DayRangeMinimumDate { get; set; } = DateTime.Today.AddYears(-2);
        public DateTime DayRangeMaximumDate { get; set; } = DateTime.Today.AddYears(2);
        public DayOfWeek StartOfWeek { get; set; } = DayOfWeek.Monday;
        public ObservableRangeCollection<DayOfWeek> CustomDayNamesOrder { get; } = new ObservableRangeCollection<DayOfWeek>()
        {
            DayOfWeek.Monday,
            DayOfWeek.Tuesday,
            DayOfWeek.Wednesday,
            DayOfWeek.Thursday,
            DayOfWeek.Friday,
            DayOfWeek.Saturday,
            DayOfWeek.Sunday
        };
        public SelectionAction SelectionAction { get; set; } = SelectionAction.Modify;
        public NavigationLoopMode NavigationLoopMode { get; set; } = NavigationLoopMode.LoopMinimumAndMaximum;
        public SelectionType SelectionType { get; set; } = SelectionType.Single;
        public NavigationTimeUnit NavigationTimeUnit { get; set; } = NavigationTimeUnit.Month;
        public PageStartMode PageStartMode { get; set; } = PageStartMode.FirstDayOfMonth;
        public int Rows { get; set; } = 2;
        public bool AutoRows { get; set; } = true;
        public bool AutoRowsIsConsistent { get; set; } = true;
        public double DayHeightRequest { get; set; } = 45;
        public double DayWidthRequest { get; set; } = 45;
        public double MonthViewHeightRequest { get; set; } = 300;
        public double DayNamesHeightRequest { get; set; } = 25;
        public bool UseCustomDayNamesOrder { get; set; } = false;
        public DateTime TodayDate { get; set; } = DateTime.Today;
        public double NavigationHeightRequest { get; set; } = 40;
        public int ForwardsNavigationAmount { get; set; } = 1;
        public int BackwardsNavigationAmount { get; set; } = -1;
        public DefaultCalendarDayResolver DayResolver { get; } = new DefaultCalendarDayResolver();
        #endregion

        #region Commands
        public ICommand ShowCustomDayNamesOrderDialogCommand { get; set; }
        public ICommand ShowSelectionActionDialogCommand { get; set; }
        public ICommand ShowNavigationLoopModeDialogCommand { get; set; }
        public ICommand ShowNavigationTimeUnitDialogCommand { get; set; }
        public ICommand ShowPageStartModeDialogCommand { get; set; }
        public ICommand ShowStartOfWeekDialogCommand { get; set; }
        public ICommand ShowSelectionTypeDialogCommand { get; set; }
        #endregion

        #region Constructors
        public PlaygroundViewModel()
        {
            ShowCustomDayNamesOrderDialogCommand = new Command(ShowCustomDayNamesOrderDialog);
            ShowSelectionActionDialogCommand = new Command(ShowSelectionActionDialog);
            ShowNavigationLoopModeDialogCommand = new Command(ShowNavigationLoopModeDialog);
            ShowNavigationTimeUnitDialogCommand = new Command(ShowNavigationTimeUnitDialog);
            ShowPageStartModeDialogCommand = new Command(ShowPageStartModeDialog);
            ShowStartOfWeekDialogCommand = new Command(ShowStartOfWeekDialog);
            ShowSelectionTypeDialogCommand = new Command(ShowSelectionTypeDialog);
        }
        #endregion

        #region Methods
        public async void ShowCustomDayNamesOrderDialog()
        {
            IEnumerable<DayOfWeek> NewCustomDayNamesOrder = (await Shell.Current.ShowPopupAsync(new ConstructListDialogPopup(CustomDayNamesOrder, DaysOfWeek))).Cast<DayOfWeek>();
            CustomDayNamesOrder.ReplaceRange(NewCustomDayNamesOrder);
        }
        public async void ShowSelectionActionDialog()
        {
            SelectionAction = (SelectionAction)await Shell.Current.ShowPopupAsync(new SelectItemDialogPopup(SelectionAction, SelectionActions));
        }
        public async void ShowNavigationTimeUnitDialog()
        {
            NavigationTimeUnit = (NavigationTimeUnit)await Shell.Current.ShowPopupAsync(new SelectItemDialogPopup(NavigationTimeUnit, NavigationTimeUnits));
        }
        public async void ShowNavigationLoopModeDialog()
        {
            NavigationLoopMode = (NavigationLoopMode)await Shell.Current.ShowPopupAsync(new SelectItemDialogPopup(NavigationLoopMode, NavigationLoopModes));
        }
        public async void ShowPageStartModeDialog()
        {
            PageStartMode = (PageStartMode)await Shell.Current.ShowPopupAsync(new SelectItemDialogPopup(PageStartMode, PageStartModes));
        }
        public async void ShowStartOfWeekDialog()
        {
            StartOfWeek = (DayOfWeek)await Shell.Current.ShowPopupAsync(new SelectItemDialogPopup(StartOfWeek, DaysOfWeek));
        }
        public async void ShowSelectionTypeDialog()
        {
            SelectionType = (SelectionType)await Shell.Current.ShowPopupAsync(new SelectItemDialogPopup(SelectionType, SelectionTypes));
        }
        #endregion
    }
}