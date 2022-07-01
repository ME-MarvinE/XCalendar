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
        public ICommand NavigateCalendarCommand { get; set; }
        #endregion

        #region Constructors
        public UsingCalendarDayViewExampleViewModel()
        {
            NavigateCalendarCommand = new Command<int>(NavigateCalendar);
        }
        #endregion

        #region Methods
        public void NavigateCalendar(int Amount)
        {
            Calendar?.NavigateCalendar(Amount);
        }
        #endregion
    }
}
