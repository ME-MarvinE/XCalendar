using System;

namespace XCalendar.Models
{
    public class CalendarDay : BaseObservableModel
    {
        #region Fields
        private DateTime _dateTime = DateTime.Today;
        #endregion

        #region Properties
        public DateTime DateTime
        {
            get
            {
                return _dateTime;
            }
            set
            {
                _dateTime = value;
                OnPropertyChanged();
            }
        }
        #endregion
    }
}
