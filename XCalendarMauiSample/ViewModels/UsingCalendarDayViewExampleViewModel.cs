using System.Windows.Input;
using XCalendar.Core.Enums;
using XCalendar.Core.Models;

namespace XCalendarMauiSample.ViewModels
{
    public class UsingCalendarDayViewExampleViewModel : BaseViewModel
    {
        #region Properties
        public Calendar Calendar { get; set; } = new Calendar()
        {
            SelectedDates = new ObservableRangeCollection<DateTime>() { DateTime.Now },
            SelectionAction = SelectionAction.Replace,
            SelectionType = SelectionType.Single
        };
        public CalendarDay OutsideCalendarDay { get; set; } = new CalendarDay();
        #endregion

        #region Commands
        public ICommand NavigateForwardsCommand { get; set; }
        public ICommand NavigateBackwardsCommand { get; set; }
        #endregion

        #region Constructors
        public UsingCalendarDayViewExampleViewModel()
        {
            NavigateForwardsCommand = new Command(NavigateForwards);
            NavigateBackwardsCommand = new Command(NavigateBackwards);
        }
        #endregion

        #region Methods
        public void NavigateForwards()
        {
            Calendar?.NavigateCalendar(1);
        }
        public void NavigateBackwards()
        {
            Calendar?.NavigateCalendar(-1);
        }
        #endregion



    }
}
