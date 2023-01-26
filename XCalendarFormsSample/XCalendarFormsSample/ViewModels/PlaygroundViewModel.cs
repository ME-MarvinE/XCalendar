using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using XCalendar.Core.Enums;
using XCalendar.Core.Extensions;
using XCalendar.Core.Models;
using XCalendarFormsSample.Helpers;

namespace XCalendarFormsSample.ViewModels
{
    public class PlaygroundViewModel : BaseViewModel
    {
        #region Properties
        public Calendar<CalendarDay> Calendar { get; set; } = new Calendar<CalendarDay>()
        {
            NavigatedDate = DateTime.Today,
            NavigationLowerBound = DateTime.Today.AddYears(-2),
            NavigationUpperBound = DateTime.Today.AddYears(2),
            StartOfWeek = DayOfWeek.Monday,
            SelectionAction = SelectionAction.Modify,
            NavigationLoopMode = NavigationLoopMode.LoopMinimumAndMaximum,
            SelectionType = SelectionType.Single,
            PageStartMode = PageStartMode.FirstDayOfMonth,
            Rows = 2,
            AutoRows = true,
            AutoRowsIsConsistent = true,
            TodayDate = DateTime.Today
        };
        public List<string> NavigationTimeUnits { get; } = new List<string>()
        {
            "Day",
            "Week",
            "Month",
            "Year"
        };
        public string NavigationTimeUnit { get; set; } = "Month";
        public bool CalendarIsVisible { get; set; } = true;
        public double DaysViewHeightRequest { get; set; } = 300;
        public double DayNamesHeightRequest { get; set; } = 25;
        public double NavigationHeightRequest { get; set; } = 50;
        public double DayHeightRequest { get; set; } = 45;
        public double DayWidthRequest { get; set; } = 45;
        public int ForwardsNavigationAmount { get; set; } = 1;
        public int BackwardsNavigationAmount { get; set; } = -1;
        public Color CalendarBackgroundColor { get; set; } = (Color)Application.Current.Resources["CalendarBackgroundColor"];
        public Color NavigationBackgroundColor { get; set; } = (Color)Application.Current.Resources["CalendarPrimaryColor"];
        public Color NavigationTextColor { get; set; } = (Color)Application.Current.Resources["CalendarPrimaryTextColor"];
        public Color NavigationArrowColor { get; set; } = (Color)Application.Current.Resources["CalendarPrimaryTextColor"];
        public Color NavigationArrowBackgroundColor { get; set; } = (Color)Application.Current.Resources["CalendarPrimaryColor"];
        public Color DayCurrentMonthBackgroundColor { get; set; } = (Color)Application.Current.Resources["CalendarBackgroundColor"];
        public Color DayCurrentMonthTextColor { get; set; } = (Color)Application.Current.Resources["CalendarBackgroundTextColor"];
        public Color DayOtherMonthBackgroundColor { get; set; } = (Color)Application.Current.Resources["CalendarBackgroundColor"];
        public Color DayOtherMonthTextColor { get; set; } = Color.FromHex("#A0A0A0");
        public Color DayTodayBackgroundColor { get; set; } = (Color)Application.Current.Resources["CalendarBackgroundColor"];
        public Color DayTodayTextColor { get; set; } = (Color)Application.Current.Resources["CalendarPrimaryColor"];
        public Color DaySelectedBackgroundColor { get; set; } = (Color)Application.Current.Resources["CalendarPrimaryColor"];
        public Color DaySelectedTextColor { get; set; } = (Color)Application.Current.Resources["CalendarPrimaryTextColor"];
        public Color DayInvalidBackgroundColor { get; set; } = (Color)Application.Current.Resources["CalendarBackgroundColor"];
        public Color DayInvalidTextColor { get; set; } = (Color)Application.Current.Resources["CalendarTertiaryColor"];
        #endregion

        #region Commands
        public ICommand ShowCustomDayNamesOrderDialogCommand { get; set; }
        public ICommand ShowSelectionActionDialogCommand { get; set; }
        public ICommand ShowNavigationLoopModeDialogCommand { get; set; }
        public ICommand ShowNavigationTimeUnitDialogCommand { get; set; }
        public ICommand ShowPageStartModeDialogCommand { get; set; }
        public ICommand ShowStartOfWeekDialogCommand { get; set; }
        public ICommand ShowSelectionTypeDialogCommand { get; set; }
        public ICommand ShowCalendarBackgroundColorDialogCommand { get; set; }
        public ICommand ShowNavigationBackgroundColorDialogCommand { get; set; }
        public ICommand ShowNavigationTextColorDialogCommand { get; set; }
        public ICommand ShowNavigationArrowColorDialogCommand { get; set; }
        public ICommand ShowNavigationArrowBackgroundColorDialogCommand { get; set; }
        public ICommand ShowDayCurrentMonthBackgroundColorDialogCommand { get; set; }
        public ICommand ShowDayCurrentMonthTextColorDialogCommand { get; set; }
        public ICommand ShowDayOtherMonthBackgroundColorDialogCommand { get; set; }
        public ICommand ShowDayOtherMonthTextColorDialogCommand { get; set; }
        public ICommand ShowDayTodayBackgroundColorDialogCommand { get; set; }
        public ICommand ShowDayTodayTextColorDialogCommand { get; set; }
        public ICommand ShowDaySelectedBackgroundColorDialogCommand { get; set; }
        public ICommand ShowDaySelectedTextColorDialogCommand { get; set; }
        public ICommand ShowDayInvalidBackgroundColorDialogCommand { get; set; }
        public ICommand ShowDayInvalidTextColorDialogCommand { get; set; }
        public ICommand NavigateCalendarCommand { get; set; }
        public ICommand ChangeDateSelectionCommand { get; set; }
        public ICommand ChangeCalendarVisibilityCommand { get; set; }
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
            ShowCalendarBackgroundColorDialogCommand = new Command(ShowCalendarBackgroundColorDialog);
            ShowNavigationBackgroundColorDialogCommand = new Command(ShowNavigationBackgroundColorDialog);
            ShowNavigationTextColorDialogCommand = new Command(ShowNavigationTextColorDialog);
            ShowNavigationArrowColorDialogCommand = new Command(ShowNavigationArrowColorDialog);
            ShowNavigationArrowBackgroundColorDialogCommand = new Command(ShowNavigationArrowBackgroundColorDialog);
            ShowDayCurrentMonthBackgroundColorDialogCommand = new Command(ShowDayCurrentMonthBackgroundColorDialog);
            ShowDayCurrentMonthTextColorDialogCommand = new Command(ShowDayCurrentMonthTextColorDialog);
            ShowDayOtherMonthBackgroundColorDialogCommand = new Command(ShowDayOtherMonthBackgroundColorDialog);
            ShowDayOtherMonthTextColorDialogCommand = new Command(ShowDayOtherMonthTextColorDialog);
            ShowDayTodayBackgroundColorDialogCommand = new Command(ShowDayTodayBackgroundColorDialog);
            ShowDayTodayTextColorDialogCommand = new Command(ShowDayTodayTextColorDialog);
            ShowDaySelectedBackgroundColorDialogCommand = new Command(ShowDaySelectedBackgroundColorDialog);
            ShowDaySelectedTextColorDialogCommand = new Command(ShowDaySelectedTextColorDialog);
            ShowDayInvalidBackgroundColorDialogCommand = new Command(ShowDayInvalidBackgroundColorDialog);
            ShowDayInvalidTextColorDialogCommand = new Command(ShowDayInvalidTextColorDialog);
            NavigateCalendarCommand = new Command<int>(NavigateCalendar);
            ChangeDateSelectionCommand = new Command<DateTime>(ChangeDateSelection);
            ChangeCalendarVisibilityCommand = new Command<bool>(ChangeCalendarVisibility);
        }
        #endregion

        #region Methods
        public void NavigateCalendar(int amount)
        {
            TimeSpan timeSpanToNavigateBy;

            switch (NavigationTimeUnit)
            {
                case "Day":
                    timeSpanToNavigateBy = TimeSpan.FromDays(amount);
                    break;

                case "Week":
                    timeSpanToNavigateBy = TimeSpan.FromDays(amount * 7);
                    break;

                case "Month":
                    if (Calendar.NavigatedDate.TryAddMonths(amount, out DateTime addMonthsDateTime))
                    {
                        timeSpanToNavigateBy = addMonthsDateTime - Calendar.NavigatedDate;
                    }
                    else
                    {
                        timeSpanToNavigateBy = amount > 0 ? TimeSpan.MaxValue : TimeSpan.MinValue;
                    }
                    break;

                case "Year":
                    if (Calendar.NavigatedDate.TryAddYears(amount, out DateTime addYearsDateTime))
                    {
                        timeSpanToNavigateBy = addYearsDateTime - Calendar.NavigatedDate;
                    }
                    else
                    {
                        timeSpanToNavigateBy = amount > 0 ? TimeSpan.MaxValue : TimeSpan.MinValue;
                    }
                    break;

                default:
                    throw new NotImplementedException();
            }

            Calendar.Navigate(timeSpanToNavigateBy);

            //DateTime TimeSpanToNavigateBy;

            //try
            //{
            //    switch (NavigationTimeUnit)
            //    {
            //        case "Day":
            //            TimeSpanToNavigateBy = Calendar.NavigatedDate.AddDays(Amount);
            //            break;

            //        case "Week":
            //            TimeSpanToNavigateBy = Calendar.NavigatedDate.AddWeeks(Amount);
            //            break;

            //        case "Month":
            //            TimeSpanToNavigateBy = Calendar.NavigatedDate.AddMonths(Amount);
            //            break;

            //        case "Year":
            //            TimeSpanToNavigateBy = Calendar.NavigatedDate.AddYears(Amount);
            //            break;

            //        case "Page":
            //            TimeSpanToNavigateBy = Calendar.NavigatedDate.AddWeeks(Calendar.Rows * Amount);
            //            break;

            //        default: 
            //            throw new NotImplementedException();
            //    }
            //}
            //catch (ArgumentOutOfRangeException Ex) when (Ex.TargetSite.DeclaringType == typeof(DateTime))
            //{
            //    if (Amount > 0)
            //    {
            //        TimeSpanToNavigateBy = DateTime.MaxValue;
            //    }
            //    else
            //    {
            //        TimeSpanToNavigateBy = DateTime.MinValue;
            //    }
            //}

            //Calendar.Navigate(TimeSpanToNavigateBy);
        }
        public void ChangeDateSelection(DateTime dateTime)
        {
            Calendar?.ChangeDateSelection(dateTime);
        }
        public void ChangeCalendarVisibility(bool isVisible)
        {
            CalendarIsVisible = isVisible;
        }
        public async void ShowCustomDayNamesOrderDialog()
        {
            IEnumerable<DayOfWeek> newCustomDayNamesOrder = await PopupHelper.ShowCustomDayNamesOrderDialog(Calendar.CustomDayNamesOrder ?? new ObservableRangeCollection<DayOfWeek>());

            if (newCustomDayNamesOrder.Any())
            {
                if (Calendar.CustomDayNamesOrder == null)
                {
                    Calendar.CustomDayNamesOrder = new ObservableRangeCollection<DayOfWeek>(newCustomDayNamesOrder);
                }
                else
                {
                    Calendar.CustomDayNamesOrder.ReplaceRange(newCustomDayNamesOrder);
                }
            }
            else
            {
                Calendar.CustomDayNamesOrder = null;
            }
        }
        public async void ShowSelectionActionDialog()
        {
            Calendar.SelectionAction = await PopupHelper.ShowSelectionActionDialog(Calendar.SelectionAction);
        }
        public async void ShowNavigationTimeUnitDialog()
        {
            NavigationTimeUnit = await PopupHelper.ShowSelectItemDialog(NavigationTimeUnit, NavigationTimeUnits);
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
        public async void ShowCalendarBackgroundColorDialog()
        {
            CalendarBackgroundColor = await PopupHelper.ShowColorDialog(CalendarBackgroundColor);
        }
        public async void ShowNavigationBackgroundColorDialog()
        {
            NavigationBackgroundColor = await PopupHelper.ShowColorDialog(NavigationBackgroundColor);
        }
        public async void ShowNavigationTextColorDialog()
        {
            NavigationTextColor = await PopupHelper.ShowColorDialog(NavigationTextColor);
        }
        public async void ShowNavigationArrowColorDialog()
        {
            NavigationArrowColor = await PopupHelper.ShowColorDialog(NavigationArrowColor);
        }
        public async void ShowNavigationArrowBackgroundColorDialog()
        {
            NavigationArrowBackgroundColor = await PopupHelper.ShowColorDialog(NavigationArrowBackgroundColor);
        }
        public async void ShowDayCurrentMonthBackgroundColorDialog()
        {
            DayCurrentMonthBackgroundColor = await PopupHelper.ShowColorDialog(DayCurrentMonthBackgroundColor);
        }
        public async void ShowDayCurrentMonthTextColorDialog()
        {
            DayCurrentMonthTextColor = await PopupHelper.ShowColorDialog(DayCurrentMonthTextColor);
        }
        public async void ShowDayOtherMonthBackgroundColorDialog()
        {
            DayOtherMonthBackgroundColor = await PopupHelper.ShowColorDialog(DayOtherMonthBackgroundColor);
        }
        public async void ShowDayOtherMonthTextColorDialog()
        {
            DayOtherMonthTextColor = await PopupHelper.ShowColorDialog(DayOtherMonthTextColor);
        }
        public async void ShowDayTodayBackgroundColorDialog()
        {
            DayTodayBackgroundColor = await PopupHelper.ShowColorDialog(DayTodayBackgroundColor);
        }
        public async void ShowDayTodayTextColorDialog()
        {
            DayTodayTextColor = await PopupHelper.ShowColorDialog(DayTodayTextColor);
        }
        public async void ShowDaySelectedBackgroundColorDialog()
        {
            DaySelectedBackgroundColor = await PopupHelper.ShowColorDialog(DaySelectedBackgroundColor);
        }
        public async void ShowDaySelectedTextColorDialog()
        {
            DaySelectedTextColor = await PopupHelper.ShowColorDialog(DaySelectedTextColor);
        }
        public async void ShowDayInvalidBackgroundColorDialog()
        {
            DayInvalidBackgroundColor = await PopupHelper.ShowColorDialog(DayInvalidBackgroundColor);
        }
        public async void ShowDayInvalidTextColorDialog()
        {
            DayInvalidTextColor = await PopupHelper.ShowColorDialog(DayInvalidTextColor);
        }
        #endregion
    }
}