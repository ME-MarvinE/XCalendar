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
        public static List<NavigationTimeUnit> AllNavigationTimeUnits { get; set; } = Enum.GetValues(typeof(NavigationTimeUnit)).Cast<NavigationTimeUnit>().ToList();
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
        public static async Task<IEnumerable<DayOfWeek>> ShowCustomDayNamesOrderDialog(IEnumerable<DayOfWeek> CustomDayNamesOrder)
        {
            return await ShowCustomDayNamesOrderDialog(CustomDayNamesOrder, AllDaysOfWeek);
        }
        public static async Task<IEnumerable<DayOfWeek>> ShowCustomDayNamesOrderDialog(IEnumerable<DayOfWeek> CustomDayNamesOrder, IEnumerable<DayOfWeek> DaysOfWeek)
        {
            List<object> Result = (List<object>)await Shell.Current.ShowPopupAsync(new ConstructListDialogPopup(CustomDayNamesOrder, DaysOfWeek));
            return Result.Cast<DayOfWeek>();
        }
        public static async Task<SelectionAction> ShowSelectionActionDialog(SelectionAction SelectionAction)
        {
            return await ShowSelectionActionDialog(SelectionAction, AllSelectionActions);
        }
        public static async Task<SelectionAction> ShowSelectionActionDialog(SelectionAction SelectionAction, IEnumerable<SelectionAction> SelectionActions)
        {
            return (SelectionAction)await Shell.Current.ShowPopupAsync(new SelectItemDialogPopup(SelectionAction, SelectionActions));
        }
        public static async Task<NavigationTimeUnit> ShowNavigationTimeUnitDialog(NavigationTimeUnit NavigationTimeUnit)
        {
            return await ShowNavigationTimeUnitDialog(NavigationTimeUnit, AllNavigationTimeUnits);
        }
        public static async Task<NavigationTimeUnit> ShowNavigationTimeUnitDialog(NavigationTimeUnit NavigationTimeUnit, IEnumerable<NavigationTimeUnit> NavigationTimeUnits)
        {
            return (NavigationTimeUnit)await Shell.Current.ShowPopupAsync(new SelectItemDialogPopup(NavigationTimeUnit, NavigationTimeUnits));
        }
        public static async Task<NavigationLoopMode> ShowNavigationLoopModeDialog(NavigationLoopMode NavigationLoopMode)
        {
            return await ShowNavigationLoopModeDialog(NavigationLoopMode, AllNavigationLoopModes);
        }
        public static async Task<NavigationLoopMode> ShowNavigationLoopModeDialog(NavigationLoopMode NavigationLoopMode, IEnumerable<NavigationLoopMode> NavigationLoopModes)
        {
            return (NavigationLoopMode)await Shell.Current.ShowPopupAsync(new SelectItemDialogPopup(NavigationLoopMode, NavigationLoopModes));
        }
        public static async Task<PageStartMode> ShowPageStartModeDialog(PageStartMode PageStartMode)
        {
            return await ShowPageStartModeDialog(PageStartMode, AllPageStartModes);
        }
        public static async Task<PageStartMode> ShowPageStartModeDialog(PageStartMode PageStartMode, IEnumerable<PageStartMode> PageStartModes)
        {
            return (PageStartMode)await Shell.Current.ShowPopupAsync(new SelectItemDialogPopup(PageStartMode, PageStartModes));
        }
        public static async Task<DayOfWeek> ShowStartOfWeekDialog(DayOfWeek DayOfWeek)
        {
            return await ShowStartOfWeekDialog(DayOfWeek, AllDaysOfWeek);
        }
        public static async Task<DayOfWeek> ShowStartOfWeekDialog(DayOfWeek DayOfWeek, IEnumerable<DayOfWeek> DaysOfWeek)
        {
            return (DayOfWeek)await Shell.Current.ShowPopupAsync(new SelectItemDialogPopup(DayOfWeek, DaysOfWeek));
        }
        public static async Task<SelectionType> ShowSelectionTypeDialog(SelectionType SelectionType)
        {
            return await ShowSelectionTypeDialog(SelectionType, AllSelectionTypes);
        }
        public static async Task<SelectionType> ShowSelectionTypeDialog(SelectionType SelectionType, IEnumerable<SelectionType> SelectionTypes)
        {
            return (SelectionType)await Shell.Current.ShowPopupAsync(new SelectItemDialogPopup(SelectionType, SelectionTypes));
        }
        public static async Task<Color> ShowColorDialog(Color Color)
        {
            return (Color)await Shell.Current.ShowPopupAsync(new ColorDialogPopup(Color));
        }
        #endregion
    }
}
