using PropertyChanged;
using System.Windows.Input;
using XCalendar.Core.Collections;
using XCalendar.Maui.Views;
using XCalendarMauiSample.Models;
using XCalendarMauiSample.Views;

namespace XCalendarMauiSample.ViewModels
{
    public class ExamplesViewModel : BaseViewModel
    {
        #region Properties
        public ObservableRangeCollection<Example> Examples { get; } = new ObservableRangeCollection<Example>()
        {
            new Example()
            {
                Page = new EventCalendarExamplePage(),
                Title = "Event Calendar",
                Description = "Uses indicators to show events for a certain day.",
                Tags = new List<Tag>()
                {
                    new Tag() { Title = "Event" },
                    new Tag() { Title = "Events" },
                    new Tag() { Title = "Appointmnts" },
                    new Tag() { Title = "Special" },
                    new Tag() { Title = "Indicator" }
                }
            },
            new Example()
            {
                Page = new CustomDatePickerDialogExamplePage(),
                Title = "Custom DatePicker Dialog",
                Description = "A custom DatePicker made using a {nameof(CalendarView)}."
            },
            new Example()
            {
                Page = new SelectionExamplePage(),
                Title = "Date Selection",
                Description = "Showcase of {nameof(CalendarView)}'s selection capabilities."
            },
            new Example()
            {
                Page = new UsingDayViewExamplePage(),
                Title = "Using {nameof(DayView)}",
                Description = "How to use the {nameof(DayView)} control.",
                Tags = new List<Tag>()
                {
                    new Tag() { Title = "DayTemplate" },
                    new Tag() { Title = "Customise" },
                    new Tag() { Title = "Customisation" }
                }
            },
            new Example()
            {
                Page = new CustomisingADayExamplePage(),
                Title = "Customising A Day",
                Description = "How to customise the appearance of a day in {nameof(CalendarView)}.",
                Tags = new List<Tag>()
                {
                    new Tag() { Title = "DayTemplate" },
                    new Tag() { Title = "Customise" },
                    new Tag() { Title = "Customisation" }
                }
            },
            new Example()
            {
                Page = new SwipableCalendarExamplePage(),
                Title = "Animated Swipable Calendar",
                Description = "How to create a Calendar where swiping navigates the calendar and shows a preview of the previous or next page.",
                Tags = new List<Tag>()
                {
                    new Tag() { Title = "Swipe" },
                    new Tag() { Title = "Swipable" },
                    new Tag() { Title = "Gesture" },
                    new Tag() { Title = "Recognizer" },
                    new Tag() { Title = "Animate" },
                    new Tag() { Title = "Animation" },
                    new Tag() { Title = "Previous" },
                    new Tag() { Title = "Next" },
                    new Tag() { Title = "Page" },
                    new Tag() { Title = "Carousel" },
                    new Tag() { Title = "Template" }
                }
            },
            new Example()
            {
                Page = new ConnectingSelectedDaysExamplePage(),
                Title = "Connecting Selected Days",
                Description = "Implementation of connecting consecutively selected days.",
                Tags = new List<Tag>()
                {
                    new Tag() { Title = "Span" },
                    new Tag() { Title = "Template" },
                    new Tag() { Title = "Templates" },
                    new Tag() { Title = "Inherit" },
                    new Tag() { Title = "Custom" },
                    new Tag() { Title = "Customise" },
                    new Tag() { Title = "DayView" },
                    new Tag() { Title = "Extend" },
                    new Tag() { Title = "Selection" },
                    new Tag() { Title = "Connect" },
                    new Tag() { Title = "Connecting" },
                    new Tag() { Title = "Connection" }
                }
            },
            new Example()
            {
                Page = new DuolingoStreakCalendarExamplePage(),
                Title = "Duolingo Streak Calendar",
                Description = "Implementation of the streak calendar in the 'Duolingo' app.",
                Tags = new List<Tag>()
                {
                    new Tag() { Title = "Duolingo" },
                    new Tag() { Title = "Template" },
                    new Tag() { Title = "Templates" },
                    new Tag() { Title = "Inherit" },
                    new Tag() { Title = "Custom" },
                    new Tag() { Title = "Customise" },
                    new Tag() { Title = "DayView" },
                    new Tag() { Title = "Extend" },
                    new Tag() { Title = "Selection" },
                    new Tag() { Title = "Connect" },
                    new Tag() { Title = "Connecting" },
                    new Tag() { Title = "Connection" }
                }
            }
        };
        public ObservableRangeCollection<Example> DisplayedExamples { get; } = new ObservableRangeCollection<Example>();
        [OnChangedMethod(nameof(OnSearchTextChanged))]
        public string SearchText { get; set; }
        #endregion

        #region Commands
        public ICommand SearchExamplesCommand { get; set; }
        public ICommand ShowPageCommand { get; set; }
        #endregion

        #region Constructors
        public ExamplesViewModel()
        {
            SearchExamplesCommand = new Command(SearchExamples);
            ShowPageCommand = new Command<Page>(async (Page page) => await ShowPage(page));
            SearchExamples();
        }
        #endregion

        #region Methods
        private void OnSearchTextChanged()
        {
            SearchExamples();
        }
        public void SearchExamples()
        {
            bool searchTags = true;

            if (string.IsNullOrWhiteSpace(SearchText))
            {
                DisplayedExamples.ReplaceRange(Examples);
            }
            else
            {
                DisplayedExamples.ReplaceRange(
                    Examples.Where(x =>
                    x.Title.ToLower().Contains(SearchText.ToLower()) ||
                    (searchTags && x.Tags.Any(tag =>
                        tag.Title.ToLower().Contains(SearchText.ToLower())))));
            }
        }
        public async Task ShowPage(Page page)
        {
            await Shell.Current.Navigation.PushAsync(page);
        }
        #endregion
    }
}
