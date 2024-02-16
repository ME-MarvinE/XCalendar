using XCalendar.Core.Collections;
using XCalendar.Core.Models;
using XCalendar.Forms.Interfaces;

namespace XCalendar.Forms.Models
{
    public class ComplexCalendarDay : CalendarDay, IComplexCalendarDay
    {
        #region Fields
        private ObservableRangeCollection<IEvent> _events = new ObservableRangeCollection<IEvent>();
        #endregion

        #region Properties
        public ObservableRangeCollection<IEvent> Events
        {
            get
            {
                return _events;
            }
            set
            {
                if (_events != value)
                {
                    _events = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion
    }
}
