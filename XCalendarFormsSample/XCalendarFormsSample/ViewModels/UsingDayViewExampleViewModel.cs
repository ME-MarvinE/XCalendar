using System;
using System.Windows.Input;
using Xamarin.Forms;
using XCalendar.Core.Enums;
using XCalendar.Core.Extensions;
using XCalendar.Core.Models;

namespace XCalendarFormsSample.ViewModels
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
            if (Calendar.NavigatedDate.TryAddMonths(Amount, out DateTime TargetDate))
            {
                Calendar.Navigate(TargetDate - Calendar.NavigatedDate);
            }
            else
            {
                Calendar.Navigate(Amount > 0 ? TimeSpan.MaxValue : TimeSpan.MinValue);
            }
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
