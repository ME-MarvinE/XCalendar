using CommunityToolkit.Maui.Views;
using XCalendar.Core.Enums;
using XCalendarMauiSample.Popups;

namespace XCalendarMauiSample.Helpers
{
    public class PopupHelper
    {
        #region Properties
        public static List<SelectionType> AllSelectionTypes { get; set; } = Enum.GetValues(typeof(SelectionType)).Cast<SelectionType>().ToList();
        public static List<SelectionAction> AllSelectionActions { get; set; } = Enum.GetValues(typeof(SelectionAction)).Cast<SelectionAction>().ToList();
        public static List<PageStartMode> AllPageStartModes { get; set; } = Enum.GetValues(typeof(PageStartMode)).Cast<PageStartMode>().ToList();
        public static List<NavigationLoopMode> AllNavigationLoopModes { get; set; } = Enum.GetValues(typeof(NavigationLoopMode)).Cast<NavigationLoopMode>().ToList();
        public static List<DayOfWeek> AllDaysOfWeek { get; set; } = new List<DayOfWeek>()
        {
            DayOfWeek.Monday,
            DayOfWeek.Tuesday,
            DayOfWeek.Wednesday,
            DayOfWeek.Thursday,
            DayOfWeek.Friday,
            DayOfWeek.Saturday,
            DayOfWeek.Sunday
        };
        #endregion

        #region Methods
        public static async Task<T> ShowSelectItemDialog<T>(T initialValue, IEnumerable<T> itemsSource)
        {
            return (T)await Shell.Current.ShowPopupAsync(new SelectItemDialogPopup(initialValue, itemsSource));
        }
        public static async Task<IEnumerable<DayOfWeek>> ShowCustomDayNamesOrderDialog(IEnumerable<DayOfWeek> customDayNamesOrder)
        {
            return await ShowCustomDayNamesOrderDialog(customDayNamesOrder, AllDaysOfWeek);
        }
        public static async Task<IEnumerable<DayOfWeek>> ShowCustomDayNamesOrderDialog(IEnumerable<DayOfWeek> customDayNamesOrder, IEnumerable<DayOfWeek> daysOfWeek)
        {
            List<object> result = (List<object>)await Shell.Current.ShowPopupAsync(new ConstructListDialogPopup(customDayNamesOrder, daysOfWeek));
            return result.Cast<DayOfWeek>();
        }
        public static async Task<SelectionAction> ShowSelectionActionDialog(SelectionAction selectionAction)
        {
            return await ShowSelectionActionDialog(selectionAction, AllSelectionActions);
        }
        public static async Task<SelectionAction> ShowSelectionActionDialog(SelectionAction selectionAction, IEnumerable<SelectionAction> selectionActions)
        {
            return (SelectionAction)await Shell.Current.ShowPopupAsync(new SelectItemDialogPopup(selectionAction, selectionActions));
        }
        public static async Task<NavigationLoopMode> ShowNavigationLoopModeDialog(NavigationLoopMode navigationLoopMode)
        {
            return await ShowNavigationLoopModeDialog(navigationLoopMode, AllNavigationLoopModes);
        }
        public static async Task<NavigationLoopMode> ShowNavigationLoopModeDialog(NavigationLoopMode navigationLoopMode, IEnumerable<NavigationLoopMode> navigationLoopModes)
        {
            return (NavigationLoopMode)await Shell.Current.ShowPopupAsync(new SelectItemDialogPopup(navigationLoopMode, navigationLoopModes));
        }
        public static async Task<PageStartMode> ShowPageStartModeDialog(PageStartMode pageStartMode)
        {
            return await ShowPageStartModeDialog(pageStartMode, AllPageStartModes);
        }
        public static async Task<PageStartMode> ShowPageStartModeDialog(PageStartMode pageStartMode, IEnumerable<PageStartMode> pageStartModes)
        {
            return (PageStartMode)await Shell.Current.ShowPopupAsync(new SelectItemDialogPopup(pageStartMode, pageStartModes));
        }
        public static async Task<DayOfWeek> ShowStartOfWeekDialog(DayOfWeek dayOfWeek)
        {
            return await ShowStartOfWeekDialog(dayOfWeek, AllDaysOfWeek);
        }
        public static async Task<DayOfWeek> ShowStartOfWeekDialog(DayOfWeek dayOfWeek, IEnumerable<DayOfWeek> daysOfWeek)
        {
            return (DayOfWeek)await Shell.Current.ShowPopupAsync(new SelectItemDialogPopup(dayOfWeek, daysOfWeek));
        }
        public static async Task<SelectionType> ShowSelectionTypeDialog(SelectionType selectionType)
        {
            return await ShowSelectionTypeDialog(selectionType, AllSelectionTypes);
        }
        public static async Task<SelectionType> ShowSelectionTypeDialog(SelectionType selectionType, IEnumerable<SelectionType> selectionTypes)
        {
            return (SelectionType)await Shell.Current.ShowPopupAsync(new SelectItemDialogPopup(selectionType, selectionTypes));
        }
        public static async Task<Color> ShowColorDialog(Color color)
        {
            return (Color)await Shell.Current.ShowPopupAsync(new ColorDialogPopup(color));
        }
        #endregion
    }
}
