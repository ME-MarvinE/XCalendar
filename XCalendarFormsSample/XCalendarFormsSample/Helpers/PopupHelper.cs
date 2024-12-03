using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using XCalendar.Core.Enums;
using XCalendarFormsSample.Popups;
using XCalendar.Core.Extensions;

namespace XCalendarFormsSample.Helpers
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
        public static async Task<T> ShowSelectItemDialogAsync<T>(T initialValue, IEnumerable<T> itemsSource)
        {
            return (T)await Shell.Current.ShowPopupAsync(new SelectItemDialogPopup(initialValue, itemsSource));
        }
        public static async Task<IEnumerable<T>> ShowConstructListDialogAsync<T>(IEnumerable<T> initialValue, IEnumerable<T> itemsSource)
        {
            return (await Shell.Current.ShowPopupAsync(new ConstructListDialogPopup(initialValue, itemsSource))).Cast<T>();
        }
        public static async Task<Color> ShowColorDialogAsync(Color color)
        {
            return await Shell.Current.ShowPopupAsync(new ColorDialogPopup(color));
        }
        #endregion
    }
}
