using System;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;
using XCalendar.Core;
using XCalendar.Forms.Enums;
using XCalendarFormsSample.Helpers;

namespace XCalendarFormsSample.ViewModels
{
    public class PlaygroundViewModel : BaseViewModel
    {
        #region Properties
        public ObservableRangeCollection<DateTime> SelectedDates { get; } = new ObservableRangeCollection<DateTime>();
        public DateTime NavigatedDate { get; set; } = DateTime.Today;
        public DateTime NavigationLowerBound { get; set; } = DateTime.Today.AddYears(-2);
        public DateTime NavigationUpperBound { get; set; } = DateTime.Today.AddYears(2);
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
            CustomDayNamesOrder.ReplaceRange(await PopupHelper.ShowCustomDayNamesOrderDialog(CustomDayNamesOrder));
        }
        public async void ShowSelectionActionDialog()
        {
            SelectionAction = await PopupHelper.ShowSelectionActionDialog(SelectionAction);
        }
        public async void ShowNavigationTimeUnitDialog()
        {
            NavigationTimeUnit = await PopupHelper.ShowNavigationTimeUnitDialog(NavigationTimeUnit);
        }
        public async void ShowNavigationLoopModeDialog()
        {
            NavigationLoopMode = await PopupHelper.ShowNavigationLoopModeDialog(NavigationLoopMode);
        }
        public async void ShowPageStartModeDialog()
        {
            PageStartMode = await PopupHelper.ShowPageStartModeDialog(PageStartMode);
        }
        public async void ShowStartOfWeekDialog()
        {
            StartOfWeek = await PopupHelper.ShowStartOfWeekDialog(StartOfWeek);
        }
        public async void ShowSelectionTypeDialog()
        {
            SelectionType = await PopupHelper.ShowSelectionTypeDialog(SelectionType);
        }
        #endregion
    }
}