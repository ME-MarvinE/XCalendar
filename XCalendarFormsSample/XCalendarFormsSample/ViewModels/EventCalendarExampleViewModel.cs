﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using XCalendar.Core.Collections;
using XCalendar.Core.Enums;
using XCalendar.Core.Extensions;
using XCalendar.Core.Models;
using XCalendar.Forms.Models;
using XCalendarFormsSample.Models;

namespace XCalendarFormsSample.ViewModels
{
    public class EventCalendarExampleViewModel : BaseViewModel
    {
        #region Fields
        private static readonly Random _random = new Random();
        #endregion

        #region Properties
        public Calendar<ColoredEventsDay, ColoredEvent> EventCalendar { get; set; } = new Calendar<ColoredEventsDay, ColoredEvent>()
        {
            SelectedDates = new ObservableRangeCollection<DateTime>(),
            SelectionAction = SelectionAction.Modify,
            SelectionType = SelectionType.Single
        };
        public List<Color> EventColors { get; } = new List<Color>() { Color.Red, Color.Orange, Color.Yellow, Color.FromHex("#00A000"), Color.Blue, Color.FromHex("#8010E0") };
        public ObservableRangeCollection<ColoredEvent> SelectedEvents { get; } = new ObservableRangeCollection<ColoredEvent>();
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

            List<ColoredEvent> events = new List<ColoredEvent>()
            {
                new ColoredEvent() { Title = "Bowling", Description = "Bowling with friends" },
                new ColoredEvent() { Title = "Swimming", Description = "Swimming with friends" },
                new ColoredEvent() { Title = "Kayaking", Description = "Kayaking with friends" },
                new ColoredEvent() { Title = "Shopping", Description = "Shopping with friends" },
                new ColoredEvent() { Title = "Hiking", Description = "Hiking with friends" },
                new ColoredEvent() { Title = "Kareoke", Description = "Kareoke with friends" },
                new ColoredEvent() { Title = "Dining", Description = "Dining with friends" },
                new ColoredEvent() { Title = "Running", Description = "Running with friends" },
                new ColoredEvent() { Title = "Traveling", Description = "Traveling with friends" },
                new ColoredEvent() { Title = "Clubbing", Description = "Clubbing with friends" },
                new ColoredEvent() { Title = "Learning", Description = "Learning with friends" },
                new ColoredEvent() { Title = "Driving", Description = "Driving with friends" },
                new ColoredEvent() { Title = "Skydiving", Description = "Skydiving with friends" },
                new ColoredEvent() { Title = "Bungee Jumping", Description = "Bungee Jumping with friends" },
                new ColoredEvent() { Title = "Trampolining", Description = "Trampolining with friends" },
                new ColoredEvent() { Title = "Adventuring", Description = "Adventuring with friends" },
                new ColoredEvent() { Title = "Roller Skating", Description = "Rollerskating with friends" },
                new ColoredEvent() { Title = "Ice Skating", Description = "Ice Skating with friends" },
                new ColoredEvent() { Title = "Skateboarding", Description = "Skateboarding with friends" },
                new ColoredEvent() { Title = "Crafting", Description = "Crafting with friends" },
                new ColoredEvent() { Title = "Drinking", Description = "Drinking with friends" },
                new ColoredEvent() { Title = "Playing Games", Description = "Playing Games with friends" },
                new ColoredEvent() { Title = "Canoeing", Description = "Canoeing with friends" },
                new ColoredEvent() { Title = "Climbing", Description = "Climbing with friends" },
                new ColoredEvent() { Title = "Partying", Description = "Partying with friends" },
                new ColoredEvent() { Title = "Relaxing", Description = "Relaxing with friends" },
                new ColoredEvent() { Title = "Exercising", Description = "Exercising with friends" },
                new ColoredEvent() { Title = "Baking", Description = "Baking with friends" },
                new ColoredEvent() { Title = "Skiing", Description = "Skiing with friends" },
                new ColoredEvent() { Title = "Snowboarding", Description = "Snowboarding with friends" },
                new ColoredEvent() { Title = "Surfing", Description = "Surfing with friends" },
                new ColoredEvent() { Title = "Paragliding", Description = "Paragliding with friends" },
                new ColoredEvent() { Title = "Sailing", Description = "Sailing with friends" },
                new ColoredEvent() { Title = "Cooking", Description = "Cooking with friends" }
            };

            foreach (var @event in events)
            {
                @event.StartDate = DateTime.Today.AddDays(_random.Next(-20, 21)).AddDays(_random.NextDouble());
                @event.EndDate = @event.StartDate.AddDays(_random.Next(1, 4)).AddHours(_random.Next(17));

                if (_random.NextDouble() < 0.025)
                {
                    @event.EndDate = @event.EndDate.Value.AddYears(_random.Next(1, 4));
                }
                else if (_random.NextDouble() < 0.025)
                {
                    @event.EndDate = null;
                }

                @event.Color = EventColors[_random.Next(EventColors.Count)];
            }

            EventCalendar.Events.ReplaceRange(events);
            EventCalendar.SelectedDates.CollectionChanged += SelectedDates_CollectionChanged;
        }
        #endregion

        #region Methods
        private void SelectedDates_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            SelectedEvents.ReplaceRange(EventCalendar.Events.Where(x => EventCalendar.SelectedDates.Any(y => y.Date >= x.StartDate && (x.EndDate == null || y.Date < x.EndDate))).OrderByDescending(x => x.StartDate));
        }
        public void NavigateCalendar(int amount)
        {
            if (EventCalendar.NavigatedDate.TryAddMonths(amount, out DateTime targetDate))
            {
                EventCalendar.Navigate(targetDate - EventCalendar.NavigatedDate);
            }
            else
            {
                EventCalendar.Navigate(amount > 0 ? TimeSpan.MaxValue : TimeSpan.MinValue);
            }
        }
        public void ChangeDateSelection(DateTime dateTime)
        {
            EventCalendar?.ChangeDateSelection(dateTime);
        }
        #endregion
    }
}
