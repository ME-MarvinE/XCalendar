using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using XCalendar.Core.Collections;
using XCalendar.Core.Enums;
using XCalendar.Core.Extensions;
using XCalendar.Core.Models;
using XCalendar.Forms.Models;
using XCalendarFormsSample.Helpers;
using XCalendarFormsSample.Models;

namespace XCalendarFormsSample.ViewModels
{
    public class PlaygroundViewModel : BaseViewModel
    {
        #region Fields
        private static readonly Random _random = new Random();
        #endregion

        #region Properties
        public Calendar<ColoredEventsDay,ColoredEvent> Calendar { get; set; } = new Calendar<ColoredEventsDay, ColoredEvent>()
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
        public List<Color> EventColors { get; } = new List<Color>() { Color.Red, Color.Orange, Color.Yellow, Color.FromHex("#00A000"), Color.Blue, Color.FromHex("#8010E0") };
        public List<string> NavigationTimeUnits { get; } = new List<string>()
        {
            "Day",
            "Week",
            "Month",
            "Year"
        };
        public string NavigationTimeUnit { get; set; } = "Month";
        public bool CalendarIsVisible { get; set; } = true;
        public double DaysViewHeightRequest { get; set; } = 320;
        public double DayNamesHeightRequest { get; set; } = 25;
        public double NavigationHeightRequest { get; set; } = 50;
        public double DayHeightRequest { get; set; } = 45;
        public double DayWidthRequest { get; set; } = -1;
        public bool DayAutoSetStyleBasedOnDayState { get; set; } = true;
        public int ForwardsNavigationAmount { get; set; } = 1;
        public int BackwardsNavigationAmount { get; set; } = -1;
        public string TargetCultureCode { get; set; } = CultureInfo.CurrentCulture?.Name ?? CultureInfo.DefaultThreadCurrentCulture?.Name ?? CultureInfo.CurrentUICulture?.Name ?? CultureInfo.DefaultThreadCurrentUICulture?.Name ?? "en";
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
        public ICommand UpdateCurrentCultureCommand { get; set; }
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
            UpdateCurrentCultureCommand = new Command(UpdateCurrentCulture);

            List<ColoredEvent> events = new List<ColoredEvent>()
            {
                new ColoredEvent() { Title = "Bowling", Description = "Bowling with friends" },
                new ColoredEvent() { Title = "Swimming", Description = "Swimming with friends" },
                new ColoredEvent() { Title = "Kayaking", Description = "Kayaking with friends" },
                new ColoredEvent() { Title = "Shopping", Description = "Shopping with friends" },
                new ColoredEvent() { Title = "Hiking", Description = "Hiking with friends" },
                new ColoredEvent() { Title = "Kareoke", Description = "Kareoke with friends" },
                new ColoredEvent() { Title = "Dining", Description = "Dining with friends" },
                new ColoredEvent() { Title = "Running", Description = "Running with friends" },
                new ColoredEvent() { Title = "Traveling", Description = "Traveling with friends" },
                new ColoredEvent() { Title = "Clubbing", Description = "Clubbing with friends" },
                new ColoredEvent() { Title = "Learning", Description = "Learning with friends" },
                new ColoredEvent() { Title = "Driving", Description = "Driving with friends" },
                new ColoredEvent() { Title = "Skydiving", Description = "Skydiving with friends" },
                new ColoredEvent() { Title = "Bungee Jumping", Description = "Bungee Jumping with friends" },
                new ColoredEvent() { Title = "Trampolining", Description = "Trampolining with friends" },
                new ColoredEvent() { Title = "Adventuring", Description = "Adventuring with friends" },
                new ColoredEvent() { Title = "Roller Skating", Description = "Rollerskating with friends" },
                new ColoredEvent() { Title = "Ice Skating", Description = "Ice Skating with friends" },
                new ColoredEvent() { Title = "Skateboarding", Description = "Skateboarding with friends" },
                new ColoredEvent() { Title = "Crafting", Description = "Crafting with friends" },
                new ColoredEvent() { Title = "Drinking", Description = "Drinking with friends" },
                new ColoredEvent() { Title = "Playing Games", Description = "Playing Games with friends" },
                new ColoredEvent() { Title = "Canoeing", Description = "Canoeing with friends" },
                new ColoredEvent() { Title = "Climbing", Description = "Climbing with friends" },
                new ColoredEvent() { Title = "Partying", Description = "Partying with friends" },
                new ColoredEvent() { Title = "Relaxing", Description = "Relaxing with friends" },
                new ColoredEvent() { Title = "Exercising", Description = "Exercising with friends" },
                new ColoredEvent() { Title = "Baking", Description = "Baking with friends" },
                new ColoredEvent() { Title = "Skiing", Description = "Skiing with friends" },
                new ColoredEvent() { Title = "Snowboarding", Description = "Snowboarding with friends" },
                new ColoredEvent() { Title = "Surfing", Description = "Surfing with friends" },
                new ColoredEvent() { Title = "Paragliding", Description = "Paragliding with friends" },
                new ColoredEvent() { Title = "Sailing", Description = "Sailing with friends" },
                new ColoredEvent() { Title = "Cooking", Description = "Cooking with friends" }
            };

            foreach (var @event in events)
            {
                @event.DateTime = DateTime.Today.AddDays(_random.Next(-20, 21)).AddDays(_random.NextDouble());
                @event.Color = EventColors[_random.Next(EventColors.Count)];
            }

            Calendar.Events.ReplaceRange(events);
            Calendar.UpdateDays(Calendar.NavigatedDate);
            UpdateCurrentCulture();
        }
        #endregion

        #region Methods
        public void NavigateCalendar(int amount)
        {
            TimeSpan timeSpanToNavigateBy;

            switch (NavigationTimeUnit)
            {
                case "Day":
                    if (Calendar.NavigatedDate.TryAddDays(amount, out DateTime addDaysDateTime))
                    {
                        timeSpanToNavigateBy = addDaysDateTime - Calendar.NavigatedDate;
                    }
                    else
                    {
                        timeSpanToNavigateBy = amount > 0 ? TimeSpan.MaxValue : TimeSpan.MinValue;
                    }
                    break;

                case "Week":
                    if (Calendar.NavigatedDate.TryAddWeeks(amount, out DateTime addWeeksDateTime))
                    {
                        timeSpanToNavigateBy = addWeeksDateTime - Calendar.NavigatedDate;
                    }
                    else
                    {
                        timeSpanToNavigateBy = amount > 0 ? TimeSpan.MaxValue : TimeSpan.MinValue;
                    }
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
                    throw new NotImplementedException($"{nameof(NavigationTimeUnit)} '{NavigationTimeUnit}' is not implemented.");
            }

            Calendar.Navigate(timeSpanToNavigateBy);
        }
        public void ChangeDateSelection(DateTime dateTime)
        {
            Calendar?.ChangeDateSelection(dateTime);
        }
        public void ChangeCalendarVisibility(bool isVisible)
        {
            CalendarIsVisible = isVisible;
        }
        public async void UpdateCurrentCulture()
        {
            try
            {
                //Set DefaultThreadCurrentCulture because CurrentCulture gets automatically reset when changed.
                CultureInfo.DefaultThreadCurrentCulture = new CultureInfo(TargetCultureCode);
                CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo(TargetCultureCode);

                //This causes the binding converters (which use the current culture) to update.
                //Day Names
                var oldDayNamesOlder = Calendar.DayNamesOrder.ToList();
                Calendar.DayNamesOrder.ReplaceRange(new List<DayOfWeek>() { DayOfWeek.Monday });
                Calendar.DayNamesOrder.ReplaceRange(oldDayNamesOlder);

                //NavigationView Title
                NavigateCalendar(1);
                NavigateCalendar(-1);
            }
            catch
            {
                await Shell.Current.DisplayAlert("Invalid Culture Code", "The specified culture code was invalid.", "OK");
            }
        }
        public async void ShowCustomDayNamesOrderDialog()
        {
            IEnumerable<DayOfWeek> newCustomDayNamesOrder = await PopupHelper.ShowConstructListDialogAsync(Calendar.CustomDayNamesOrder ?? new ObservableRangeCollection<DayOfWeek>(), Calendar.StartOfWeek.GetWeekAsFirst());

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
            Calendar.SelectionAction = await PopupHelper.ShowSelectItemDialogAsync(Calendar.SelectionAction, PopupHelper.AllSelectionActions);
        }
        public async void ShowNavigationTimeUnitDialog()
        {
            NavigationTimeUnit = await PopupHelper.ShowSelectItemDialogAsync(NavigationTimeUnit, NavigationTimeUnits);
        }
        public async void ShowNavigationLoopModeDialog()
        {
            Calendar.NavigationLoopMode = await PopupHelper.ShowSelectItemDialogAsync(Calendar.NavigationLoopMode, PopupHelper.AllNavigationLoopModes);
        }
        public async void ShowPageStartModeDialog()
        {
            Calendar.PageStartMode = await PopupHelper.ShowSelectItemDialogAsync(Calendar.PageStartMode, PopupHelper.AllPageStartModes);
        }
        public async void ShowStartOfWeekDialog()
        {
            Calendar.StartOfWeek = await PopupHelper.ShowSelectItemDialogAsync(Calendar.StartOfWeek, Calendar.StartOfWeek.GetWeekAsFirst());
        }
        public async void ShowSelectionTypeDialog()
        {
            Calendar.SelectionType = await PopupHelper.ShowSelectItemDialogAsync(Calendar.SelectionType, PopupHelper.AllSelectionTypes);
        }
        public async void ShowCalendarBackgroundColorDialog()
        {
            CalendarBackgroundColor = await PopupHelper.ShowColorDialogAsync(CalendarBackgroundColor);
        }
        public async void ShowNavigationBackgroundColorDialog()
        {
            NavigationBackgroundColor = await PopupHelper.ShowColorDialogAsync(NavigationBackgroundColor);
        }
        public async void ShowNavigationTextColorDialog()
        {
            NavigationTextColor = await PopupHelper.ShowColorDialogAsync(NavigationTextColor);
        }
        public async void ShowNavigationArrowColorDialog()
        {
            NavigationArrowColor = await PopupHelper.ShowColorDialogAsync(NavigationArrowColor);
        }
        public async void ShowNavigationArrowBackgroundColorDialog()
        {
            NavigationArrowBackgroundColor = await PopupHelper.ShowColorDialogAsync(NavigationArrowBackgroundColor);
        }
        public async void ShowDayCurrentMonthBackgroundColorDialog()
        {
            DayCurrentMonthBackgroundColor = await PopupHelper.ShowColorDialogAsync(DayCurrentMonthBackgroundColor);
        }
        public async void ShowDayCurrentMonthTextColorDialog()
        {
            DayCurrentMonthTextColor = await PopupHelper.ShowColorDialogAsync(DayCurrentMonthTextColor);
        }
        public async void ShowDayOtherMonthBackgroundColorDialog()
        {
            DayOtherMonthBackgroundColor = await PopupHelper.ShowColorDialogAsync(DayOtherMonthBackgroundColor);
        }
        public async void ShowDayOtherMonthTextColorDialog()
        {
            DayOtherMonthTextColor = await PopupHelper.ShowColorDialogAsync(DayOtherMonthTextColor);
        }
        public async void ShowDayTodayBackgroundColorDialog()
        {
            DayTodayBackgroundColor = await PopupHelper.ShowColorDialogAsync(DayTodayBackgroundColor);
        }
        public async void ShowDayTodayTextColorDialog()
        {
            DayTodayTextColor = await PopupHelper.ShowColorDialogAsync(DayTodayTextColor);
        }
        public async void ShowDaySelectedBackgroundColorDialog()
        {
            DaySelectedBackgroundColor = await PopupHelper.ShowColorDialogAsync(DaySelectedBackgroundColor);
        }
        public async void ShowDaySelectedTextColorDialog()
        {
            DaySelectedTextColor = await PopupHelper.ShowColorDialogAsync(DaySelectedTextColor);
        }
        public async void ShowDayInvalidBackgroundColorDialog()
        {
            DayInvalidBackgroundColor = await PopupHelper.ShowColorDialogAsync(DayInvalidBackgroundColor);
        }
        public async void ShowDayInvalidTextColorDialog()
        {
            DayInvalidTextColor = await PopupHelper.ShowColorDialogAsync(DayInvalidTextColor);
        }
        #endregion
    }
}