using System;
using XCalendar.Core.Interfaces;

namespace XCalendar.Core.Models
{
    public class CalendarDay : BaseObservableModel, ICalendarDay
    {
        #region Fields
        private DateTime _DateTime = DateTime.Today;
        private bool _IsSelected;
        private bool _IsCurrentMonth;
        private bool _IsToday;
        private bool _IsInvalid;
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
                if (_DateTime != value)
                {
                    _DateTime = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool IsSelected
        {
            get
            {
                return _IsSelected;
            }
            set
            {
                if (_IsSelected != value)
                {
                    _IsSelected = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool IsCurrentMonth
        {
            get
            {
                return _IsCurrentMonth;
            }
            set
            {
                if (_IsCurrentMonth != value)
                {
                    _IsCurrentMonth = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool IsToday
        {
            get
            {
                return _IsToday;
            }
            set
            {
                if (_IsToday != value)
                {
                    _IsToday = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool IsInvalid
        {
            get
            {
                return _IsInvalid;
            }
            set
            {
                if (_IsInvalid != value)
                {
                    _IsInvalid = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion
    }
}
