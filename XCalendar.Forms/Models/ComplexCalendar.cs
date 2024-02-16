using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using XCalendar.Core.Collections;
using XCalendar.Core.Models;
using XCalendar.Forms.Interfaces;

namespace XCalendar.Forms.Models
{
    public class ComplexCalendar : ComplexCalendar<ComplexCalendarDay, Event>
    {
    }
    public class ComplexCalendar<T, TEvent> : Calendar<T> where T : IComplexCalendarDay, new() where TEvent : IEvent
    {
        #region Fields
        private ObservableRangeCollection<TEvent> _events = new ObservableRangeCollection<TEvent>();
        #endregion

        #region Properties
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
                    if (_events != null)
                    {
                        _events.CollectionChanged -= Events_CollectionChanged;
                    }

                    if (value != null)
                    {
                        value.CollectionChanged += Events_CollectionChanged;
                    }

                    _events = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        #region Constructors
        public ComplexCalendar()
        {
            Events = new ObservableRangeCollection<TEvent>();
        }
        #endregion

        #region Methods
        public override void UpdateDay(T day, DateTime newDateTime)
        {
            base.UpdateDay(day, newDateTime);
            UpdateDayEvents(day);
        }
        public virtual void UpdateDayEvents(T day)
        {
            //It is known that the only thing that the events of the day depend on is the DateTime of the day, and that all events will have the same date.
            //So, only update the events if the existing ones' DateTime does not match the day's DateTime.
            //If the day has no events, there is no way to tell if it's because the day hasn't been updated before or if there are no events with that date, so update it either way.
            if (day.Events.Count > 0 && day.DateTime.Date == day.Events[0].DateTime.Date)
            {
                return;
            }

            IEnumerable<TEvent> events = Events.Where(x => x.DateTime.Date == day.DateTime.Date);

            //No use in replacing the collection if the source and target are both empty.
            if (day.Events.Count == 0 && !events.Any())
            {
                return;
            }

            IEnumerable<IEvent> castedEvents = events.Cast<IEvent>();

            //SequenceEqual could be omitted to improve performance but in the vast majority of cases there won't even be more than 5 events in one day, so impact on performance should be negligible
            //compared to always changing the collection and updating the binding.
            if (day.Events.SequenceEqual(castedEvents))
            {
                return;
            }

            day.Events.ReplaceRange(castedEvents);
        }
        private void Events_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            UpdateDays(NavigatedDate);
        }
        #endregion
    }
}
