using System;
using Xamarin.CommunityToolkit.ObjectModel;
using XCalendar.Core.Interfaces;
using XCalendar.Core.Models;

namespace XCalendarFormsSample.Models
{
    public class EventDay : BaseObservableModel, ICalendarDay
    {
        public DateTime? DateTime { get; set; }
        public ObservableRangeCollection<Event> Events { get; } = new ObservableRangeCollection<Event>();
    }
}
