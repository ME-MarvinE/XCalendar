using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using XCalendar.Core.Interfaces;

namespace XCalendar.Core.Models
{
    public class Event : IEvent, INotifyPropertyChanged
    {
        #region Fields
        private string _title;
        private string _description;
        private DateTime _dateTime = DateTime.Today;
        #endregion

        #region Properties
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                if (_title != value)
                {
                    _title = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged();
                }
            }
        }
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
