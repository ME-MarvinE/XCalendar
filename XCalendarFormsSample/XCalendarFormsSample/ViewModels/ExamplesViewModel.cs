﻿using PropertyChanged;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;
using XCalendar.Forms.Views;
using XCalendarFormsSample.Models;
using XCalendarFormsSample.Views;

namespace XCalendarFormsSample.ViewModels
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
                Page = new UsingDayViewExamplePage(),
                Title = $"Using {nameof(DayView)}",
                Description = $"How to use the {nameof(DayView)} control.",
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
                Title = $"Customising A Day",
                Description = $"How to customise the appearance of a day in {nameof(CalendarView)}.",
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
                Title = $"Animated Swipable Calendar",
                Description = $"How to create a Calendar where swiping navigates the calendar and shows a preview of the previous or next page.",
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
            ShowPageCommand = new Command<Page>(async (Page Page) => await ShowPage(Page));
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
                DisplayedExamples.ReplaceRange(
                    Examples.Where(x => 
                    x.Title.ToLower().Contains(SearchText.ToLower()) ||
                    (SearchTags && x.Tags.Any(Tag => 
                        Tag.Title.ToLower().Contains(SearchText.ToLower())))));
            }
        }
        public async Task ShowPage(Page Page)
        {
            await Shell.Current.Navigation.PushAsync(Page);
        }
        #endregion
    }
}
