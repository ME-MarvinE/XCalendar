using System;
using System.Windows.Input;
using XCalendar.Core.Enums;
using XCalendar.Core.Models;
using XCalendarMauiSample.Helpers;
using XCalendarMauiSample.ViewModels;

namespace XCalendarMauiSample.ViewModels
{
    public class PlaygroundViewModel : BaseViewModel
    {
        #region Properties
        public Calendar Calendar { get; set; } = new Calendar()
        {
            SelectedDates = new ObservableRangeCollection<DateTime>(),
            NavigatedDate = DateTime.Today,
            NavigationLowerBound = DateTime.Today.AddYears(-2),
            NavigationUpperBound = DateTime.Today.AddYears(2),
            StartOfWeek = DayOfWeek.Monday,
            CustomDayNamesOrder = new ObservableRangeCollection<DayOfWeek>()
            {
                DayOfWeek.Monday,
                DayOfWeek.Tuesday,
                DayOfWeek.Wednesday,
                DayOfWeek.Thursday,
                DayOfWeek.Friday,
                DayOfWeek.Saturday,
                DayOfWeek.Sunday
            },
            SelectionAction = SelectionAction.Modify,
            NavigationLoopMode = NavigationLoopMode.LoopMinimumAndMaximum,
            SelectionType = SelectionType.Single,
            NavigationTimeUnit = NavigationTimeUnit.Month,
            PageStartMode = PageStartMode.FirstDayOfMonth,
            Rows = 2,
            AutoRows = true,
            AutoRowsIsConsistent = true,
            UseCustomDayNamesOrder = false,
            TodayDate = DateTime.Today,
            ForwardsNavigationAmount = 1,
            BackwardsNavigationAmount = -1
        };
        public double DayHeightRequest { get; set; } = 45;
        public double DayWidthRequest { get; set; } = 45;
        public double MonthViewHeightRequest { get; set; } = 300;
        public double DayNamesHeightRequest { get; set; } = 25;
        public double NavigationHeightRequest { get; set; } = 40;
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
            Calendar.CustomDayNamesOrder.ReplaceRange(await PopupHelper.ShowCustomDayNamesOrderDialog(Calendar.CustomDayNamesOrder));
        }
        public async void ShowSelectionActionDialog()
        {
            Calendar.SelectionAction = await PopupHelper.ShowSelectionActionDialog(Calendar.SelectionAction);
        }
        public async void ShowNavigationTimeUnitDialog()
        {
            Calendar.NavigationTimeUnit = await PopupHelper.ShowNavigationTimeUnitDialog(Calendar.NavigationTimeUnit);
        }
        public async void ShowNavigationLoopModeDialog()
        {
            Calendar.NavigationLoopMode = await PopupHelper.ShowNavigationLoopModeDialog(Calendar.NavigationLoopMode);
        }
        public async void ShowPageStartModeDialog()
        {
            Calendar.PageStartMode = await PopupHelper.ShowPageStartModeDialog(Calendar.PageStartMode);
        }
        public async void ShowStartOfWeekDialog()
        {
            Calendar.StartOfWeek = await PopupHelper.ShowStartOfWeekDialog(Calendar.StartOfWeek);
        }
        public async void ShowSelectionTypeDialog()
        {
            Calendar.SelectionType = await PopupHelper.ShowSelectionTypeDialog(Calendar.SelectionType);
        }
        #endregion
    }
}