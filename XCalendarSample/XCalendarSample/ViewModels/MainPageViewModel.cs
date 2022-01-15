using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.CommunityToolkit.ObjectModel;

namespace XCalendarSample.ViewModels
{
    public class MainPageViewModel
    {
        public ObservableRangeCollection<DateTime> SelectedDates { get; set; } = new ObservableRangeCollection<DateTime>() { DateTime.Today };
        public DateTime NavigatedDate { get; set; } = DateTime.Today;
    }
}
