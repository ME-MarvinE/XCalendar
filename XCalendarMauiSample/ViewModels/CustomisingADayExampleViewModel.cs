using System.Windows.Input;
using XCalendar.Core.Enums;
using XCalendar.Core.Extensions;
using XCalendar.Core.Models;

namespace XCalendarMauiSample.ViewModels
{
    public class CustomisingADayExampleViewModel : BaseViewModel
    {
        #region Properties
        public Calendar<CalendarDay> Calendar { get; set; } = new Calendar<CalendarDay>()
        {
            SelectionAction = SelectionAction.Replace,
            SelectionType = SelectionType.Single
        };
        #endregion

        #region Commands
        public ICommand NavigateCalendarCommand { get; set; }
        public ICommand ChangeDateSelectionCommand { get; set; }
        #endregion

        #region Constructors
        public CustomisingADayExampleViewModel()
        {
            NavigateCalendarCommand = new Command<int>(NavigateCalendar);
            ChangeDateSelectionCommand = new Command<DateTime>(ChangeDateSelection);
        }
        #endregion

        #region Methods
        public void NavigateCalendar(int amount)
        {
            if (Calendar.NavigatedDate.TryAddMonths(amount, out DateTime targetDate))
            {
                Calendar.Navigate(targetDate - Calendar.NavigatedDate);
            }
            else
            {
                Calendar.Navigate(amount > 0 ? TimeSpan.MaxValue : TimeSpan.MinValue);
            }
        }
        public void ChangeDateSelection(DateTime dateTime)
        {
            Calendar?.ChangeDateSelection(dateTime);
        }
        #endregion
    }
}
