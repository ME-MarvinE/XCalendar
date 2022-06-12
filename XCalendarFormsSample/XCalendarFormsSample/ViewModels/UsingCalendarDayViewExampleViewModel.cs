using System;
using XCalendar.Core.Enums;
using XCalendar.Core.Models;

namespace XCalendarFormsSample.ViewModels
{
    public class UsingCalendarDayViewExampleViewModel : BaseViewModel
    {
        public Calendar Calendar { get; set; } = new Calendar()
        {
            SelectedDates = new ObservableRangeCollection<DateTime>() { DateTime.Now },
            SelectionAction = SelectionAction.Replace,
            SelectionType = SelectionType.Single
        };
    }
}
