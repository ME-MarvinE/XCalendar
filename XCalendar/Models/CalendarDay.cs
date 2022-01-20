using System;

namespace XCalendar.Models
{
    public class CalendarDay : BaseObservableModel
    {
        #region Fields
        private DateTime _DateTime = DateTime.Today;
        #endregion

        #region Properties
        public DateTime DateTime
        {
            get
            {
                return _DateTime;
            }
            set
            {
                _DateTime = value;
                OnPropertyChanged();
            }
        }
        #endregion
    }
}
