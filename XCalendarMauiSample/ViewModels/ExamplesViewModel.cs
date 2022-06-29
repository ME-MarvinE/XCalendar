using PropertyChanged;
using System.Windows.Input;
using XCalendar.Core.Models;
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
                    new Tag() { Title = "ICalendarDay" },
                    new Tag() { Title = "ICalendarDayResolver" },
                    new Tag() { Title = "DayResolver" }
                }
            },
            new Example()
            {
                Page = new CustomDatePickerDialogExamplePage(),
                Title = "Custom DatePicker Dialog",
                Description = $"A custom DatePicker made using a {nameof(CalendarView)}."
            },
            new Example()
            {
                Page = new SelectionExamplePage(),
                Title = "Date Selection",
                Description = $"Showcase of {nameof(CalendarView)}'s selection capabilities."
            },
            new Example()
            {
                Page = new UsingCalendarDayViewExamplePage(),
                Title = $"Using {nameof(CalendarDayView)}",
                Description = $"How to use the {nameof(CalendarDayView)} control.",
                Tags = new List<Tag>()
                {
                    new Tag() { Title = "DayTemplate" }
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
            ShowPageCommand = new Command<Page>(async(Page Page) => await ShowPage(Page));
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
            bool SearchTags = true;

            if (string.IsNullOrWhiteSpace(SearchText))
            {
                DisplayedExamples.ReplaceRange(Examples);
            }
            else
            {
                DisplayedExamples.ReplaceRange(Examples.Where(x => x.Title.ToLower().Contains(SearchText.ToLower()) || (SearchTags && x.Tags.Any(Tag => Tag.Title.ToLower().Contains(SearchText.ToLower())))));
            }
        }
        public async Task ShowPage(Page Page)
        {
            await Shell.Current.Navigation.PushAsync(Page);
        }
        #endregion
    }
}
