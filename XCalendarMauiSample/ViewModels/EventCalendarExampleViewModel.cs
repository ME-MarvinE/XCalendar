using System.Collections.Specialized;
using System.Globalization;
using System.Windows.Input;
using XCalendar.Core.Enums;
using XCalendar.Core.Extensions;
using XCalendar.Core.Models;
using XCalendarMauiSample.Models;

namespace XCalendarMauiSample.ViewModels
{
    public class EventCalendarExampleViewModel : BaseViewModel
    {
        #region Properties
        public Calendar<EventDay> EventCalendar { get; set; } = new Calendar<EventDay>()
        {
            SelectedDates = new ObservableRangeCollection<DateTime>(),
            SelectionAction = SelectionAction.Modify,
            SelectionType = SelectionType.Single
        };
        public static readonly Random Random = new Random();
        public List<Color> Colors { get; } = new List<Color>() { Microsoft.Maui.Graphics.Colors.Red, Microsoft.Maui.Graphics.Colors.Orange, Microsoft.Maui.Graphics.Colors.Yellow, Color.FromArgb("#00A000"), Microsoft.Maui.Graphics.Colors.Blue, Color.FromArgb("#8010E0") };
        public ObservableRangeCollection<Event> Events { get; } = new ObservableRangeCollection<Event>()
        {
            new Event() { Title = "Bowling", Description = "Bowling with friends" },
            new Event() { Title = "Swimming", Description = "Swimming with friends" },
            new Event() { Title = "Kayaking", Description = "Kayaking with friends" },
            new Event() { Title = "Shopping", Description = "Shopping with friends" },
            new Event() { Title = "Hiking", Description = "Hiking with friends" },
            new Event() { Title = "Kareoke", Description = "Kareoke with friends" },
            new Event() { Title = "Dining", Description = "Dining with friends" },
            new Event() { Title = "Running", Description = "Running with friends" },
            new Event() { Title = "Traveling", Description = "Traveling with friends" },
            new Event() { Title = "Clubbing", Description = "Clubbing with friends" },
            new Event() { Title = "Learning", Description = "Learning with friends" },
            new Event() { Title = "Driving", Description = "Driving with friends" },
            new Event() { Title = "Skydiving", Description = "Skydiving with friends" },
            new Event() { Title = "Bungee Jumping", Description = "Bungee Jumping with friends" },
            new Event() { Title = "Trampolining", Description = "Trampolining with friends" },
            new Event() { Title = "Adventuring", Description = "Adventuring with friends" },
            new Event() { Title = "Roller Skating", Description = "Rollerskating with friends" },
            new Event() { Title = "Ice Skating", Description = "Ice Skating with friends" },
            new Event() { Title = "Skateboarding", Description = "Skateboarding with friends" },
            new Event() { Title = "Crafting", Description = "Crafting with friends" },
            new Event() { Title = "Drinking", Description = "Drinking with friends" },
            new Event() { Title = "Playing Games", Description = "Playing Games with friends" },
            new Event() { Title = "Canoeing", Description = "Canoeing with friends" },
            new Event() { Title = "Climbing", Description = "Climbing with friends" },
            new Event() { Title = "Partying", Description = "Partying with friends" },
            new Event() { Title = "Relaxing", Description = "Relaxing with friends" },
            new Event() { Title = "Exercising", Description = "Exercising with friends" },
            new Event() { Title = "Baking", Description = "Baking with friends" },
            new Event() { Title = "Skiing", Description = "Skiing with friends" },
            new Event() { Title = "Snowboarding", Description = "Snowboarding with friends" },
            new Event() { Title = "Surfing", Description = "Surfing with friends" },
            new Event() { Title = "Paragliding", Description = "Paragliding with friends" },
            new Event() { Title = "Sailing", Description = "Sailing with friends" },
            new Event() { Title = "Cooking", Description = "Cooking with friends" }
        };
        public ObservableRangeCollection<Event> SelectedEvents { get; } = new ObservableRangeCollection<Event>();
        #endregion

        #region Commands
        public ICommand NavigateCalendarCommand { get; set; }
        public ICommand ChangeDateSelectionCommand { get; set; }
        #endregion

        #region Constructors
        public EventCalendarExampleViewModel()
        {
            NavigateCalendarCommand = new Command<int>(NavigateCalendar);
            ChangeDateSelectionCommand = new Command<DateTime>(ChangeDateSelection);

            foreach (Event Event in Events)
            {
                Event.DateTime = DateTime.Today.AddDays(Random.Next(-20, 21)).AddSeconds(Random.Next(86400));
                Event.Color = Colors[Random.Next(6)];
            }

            EventCalendar.SelectedDates.CollectionChanged += SelectedDates_CollectionChanged;
            EventCalendar.DaysUpdated += EventCalendar_DaysUpdated;
            foreach (var Day in EventCalendar.Days)
            {
                Day.Events.ReplaceRange(Events.Where(x => x.DateTime.Date == Day.DateTime.Date));
            }
        }
        #endregion

        #region Methods
        private void EventCalendar_DaysUpdated(object sender, EventArgs e)
        {
            foreach (var Day in EventCalendar.Days)
            {
                Day.Events.ReplaceRange(Events.Where(x => x.DateTime.Date == Day.DateTime.Date));
            }
        }
        private void SelectedDates_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            SelectedEvents.ReplaceRange(Events.Where(x => EventCalendar.SelectedDates.Any(y => x.DateTime.Date == y.Date)).OrderByDescending(x => x.DateTime));
        }
        public void NavigateCalendar(int Amount)
        {
            if (EventCalendar.NavigatedDate.TryAddMonths(Amount, out DateTime TargetDate))
            {
                EventCalendar.NavigateCalendar(TargetDate - EventCalendar.NavigatedDate);
            }
            else
            {
                EventCalendar.NavigateCalendar(Amount > 0 ? TimeSpan.MaxValue : TimeSpan.MinValue);
            }
        }
        public void ChangeDateSelection(DateTime DateTime)
        {
            EventCalendar?.ChangeDateSelection(DateTime);
        }
        #endregion
    }
}
