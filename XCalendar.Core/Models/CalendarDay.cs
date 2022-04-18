using System;

namespace XCalendar.Core.Models
{
    public class CalendarDay : BaseObservableModel
    {
        #region Fields
        private DateTime? _DateTime = System.DateTime.Today;
        #endregion

        #region Properties
        public DateTime? DateTime
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
