using System;
using System.Linq;
using XCalendar.Core.Interfaces;

namespace XCalendar.Core.Models
{
    public class DefaultCalendarDayResolver<T> : ICalendarDayResolver<T> where T : ICalendarDay, new()
    {
        #region Methods
        public T CreateDay(DateTime? DateTime, Calendar<T> Calendar)
        {
            T Day = new T();
            UpdateDay(Day, DateTime, Calendar);
            return Day;
        }
        public void UpdateDay(T Day, DateTime? NewDateTime, Calendar<T> Calendar)
        {
            Day.DateTime = NewDateTime;
            Day.IsCurrentMonth = IsDayCurrentMonth(Day, Calendar);
            Day.IsToday = IsDayToday(Day, Calendar);
            Day.IsSelected = IsDaySelected(Day, Calendar);
            Day.IsInvalid = IsDayInvalid(Day, Calendar);
        }
        public virtual bool IsDayCurrentMonth(T Day, Calendar<T> Calendar)
        {
            return Day.DateTime?.Month == Calendar?.NavigatedDate.Month && Day.DateTime?.Year == Calendar?.NavigatedDate.Year;
        }
        public virtual bool IsDayToday(T Day, Calendar<T> Calendar)
        {
            return Day.DateTime?.Date == Calendar?.TodayDate.Date;
        }
        public virtual bool IsDaySelected(T Day, Calendar<T> Calendar)
        {
            return Calendar?.SelectedDates.Any(x => x.Date == Day.DateTime?.Date) == true;
        }
        public virtual bool IsDayInvalid(T Day, Calendar<T> Calendar)
        {
            return Day.DateTime?.Date < Calendar?.NavigationLowerBound.Date || Day.DateTime?.Date > Calendar?.NavigationUpperBound.Date;
        }
        #endregion
    }
}
