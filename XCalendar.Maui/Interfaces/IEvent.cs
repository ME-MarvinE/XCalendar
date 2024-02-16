namespace XCalendar.Maui.Interfaces
{
    public interface IEvent
    {
        string Title { get; set; }
        string Description { get; set; }
        DateTime DateTime { get; set; }
        Color Color { get; set; }
    }
}
