using System.Windows.Input;
using XCalendar.Core.Enums;
using XCalendar.Core.Models;

namespace XCalendarMauiSample.ViewModels
{
    public class UsingDayViewExampleViewModel : BaseViewModel
    {
        #region Properties
        public Calendar<CalendarDay> Calendar { get; set; } = new Calendar<CalendarDay>()
        {
            SelectionAction = SelectionAction.Replace,
            SelectionType = SelectionType.Single
        };
        public CalendarDay OutsideCalendarDay { get; set; } = new CalendarDay();
        #endregion

        #region Commands
        public ICommand NavigateCalendarCommand { get; set; }
        public ICommand ChangeDateSelectionCommand { get; set; }
        #endregion

        #region Constructors
        public UsingDayViewExampleViewModel()
        {
            NavigateCalendarCommand = new Command<int>(NavigateCalendar);
            ChangeDateSelectionCommand = new Command<DateTime>(ChangeDateSelection);

            Calendar.DaysUpdated += Calendar_DaysUpdated;
            Calendar.UpdateDay(OutsideCalendarDay, Calendar.NavigatedDate);
        }
        #endregion

        #region Methods
        public void NavigateCalendar(int Amount)
        {
            Calendar?.NavigateCalendar(Amount);
        }
        public void ChangeDateSelection(DateTime DateTime)
        {
            Calendar?.ChangeDateSelection(DateTime);
        }
        private void Calendar_DaysUpdated(object sender, EventArgs e)
        {
            Calendar.UpdateDay(OutsideCalendarDay, Calendar.NavigatedDate);
        }
        #endregion
    }
}
