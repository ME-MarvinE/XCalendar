namespace XCalendarMauiSample.Models
{
    public class Event : BaseObservableModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Today;
        public Color Color { get; set; }
    }
}
