using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using XCalendar.Core.Collections;
using XCalendar.Core.Interfaces;

namespace XCalendar.Core.Models
{
    public class CalendarDay : CalendarDay<Event>
    { 
    }

    public class CalendarDay<TEvent> : ICalendarDay<TEvent> where TEvent : IEvent
    {
        #region Fields
        private DateTime _dateTime = DateTime.Today;
        private bool _isSelected;
        private bool _isCurrentMonth;
        private bool _isToday;
        private bool _isInvalid;
        private ObservableRangeCollection<TEvent> _events = new ObservableRangeCollection<TEvent>();
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
                if (_dateTime != value)
                {
                    _dateTime = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool IsCurrentMonth
        {
            get
            {
                return _isCurrentMonth;
            }
            set
            {
                if (_isCurrentMonth != value)
                {
                    _isCurrentMonth = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool IsToday
        {
            get
            {
                return _isToday;
            }
            set
            {
                if (_isToday != value)
                {
                    _isToday = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool IsInvalid
        {
            get
            {
                return _isInvalid;
            }
            set
            {
                if (_isInvalid != value)
                {
                    _isInvalid = value;
                    OnPropertyChanged();
                }
            }
        }
        public ObservableRangeCollection<TEvent> Events
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

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Methods
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
