using System;

namespace XCalendar.Core.Interfaces
{
    public interface IEvent
    {
        string Title { get; set; }
        string Description { get; set; }
        DateTime DateTime { get; set; }
    }
}
