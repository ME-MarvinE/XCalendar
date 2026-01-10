using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Extensions;
using XCalendar.Core.Enums;
using XCalendar.Core.Extensions;
using XCalendarMauiSample.Popups;

namespace XCalendarMauiSample.Helpers
{
    public static class PopupHelper
    {
        #region Properties
        public static List<SelectionType> AllSelectionTypes { get; set; } = Enum.GetValues(typeof(SelectionType)).Cast<SelectionType>().ToList();
        public static List<SelectionAction> AllSelectionActions { get; set; } = Enum.GetValues(typeof(SelectionAction)).Cast<SelectionAction>().ToList();
        public static List<PageStartMode> AllPageStartModes { get; set; } = Enum.GetValues(typeof(PageStartMode)).Cast<PageStartMode>().ToList();
        public static List<NavigationLoopMode> AllNavigationLoopModes { get; set; } = Enum.GetValues(typeof(NavigationLoopMode)).Cast<NavigationLoopMode>().ToList();
        public static List<DayOfWeek> AllDaysOfWeek { get; set; } = DayOfWeek.Monday.GetWeekAsFirst();
        public static List<StackOrientation> AllStackOrientations { get; set; } = Enum.GetValues(typeof(StackOrientation)).Cast<StackOrientation>().ToList();
        public static List<SelectionDirection> AllSelectionDirections { get; set; } = Enum.GetValues(typeof(SelectionDirection)).Cast<SelectionDirection>().ToList();
        #endregion

        #region Methods
        public static async Task<T> ShowSelectItemDialogAsync<T>(T initialValue, IEnumerable<T> itemsSource, CancellationToken token = default)
        {
            IPopupResult<T> result = await Shell.Current.ShowPopupAsync<T>(new SelectItemDialogPopup(initialValue, itemsSource), token: token);

            if (result.WasDismissedByTappingOutsideOfPopup)
            {
                return initialValue;
            }

            return result.Result;
        }
        public static async Task<IEnumerable<T>> ShowConstructListDialogPopupAsync<T>(IEnumerable<T> initialValue, IEnumerable<T> daysOfWeek, CancellationToken token = default)
        {
            IPopupResult<List<object>> result = await Shell.Current.ShowPopupAsync<List<object>>(new ConstructListDialogPopup(initialValue, daysOfWeek), token: token);

            if (result.WasDismissedByTappingOutsideOfPopup)
            {
                return initialValue;
            }

            return result.Result.Cast<T>();
        }
        public static async Task<Color> ShowColorDialogAsync(Color color, CancellationToken token = default)
        {
            IPopupResult<Color> result = await Shell.Current.ShowPopupAsync<Color>(new ColorDialogPopup(color), token: token);

            if (result.WasDismissedByTappingOutsideOfPopup)
            {
                return color;
            }

            return result.Result;
        }
        public static async Task<DateTime> ShowDatePickerDialogAsync(DateTime dateTime, CancellationToken token = default)
        {
            IPopupResult<DateTime> result = await Shell.Current.ShowPopupAsync<DateTime>(new DatePickerDialogPopup(dateTime), token: token);

            if (result.WasDismissedByTappingOutsideOfPopup)
            {
                return dateTime;
            }

            return result.Result;
        }
        #endregion
    }
}
