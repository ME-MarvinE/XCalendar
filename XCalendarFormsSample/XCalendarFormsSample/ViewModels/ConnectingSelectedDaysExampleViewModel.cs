using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using XCalendar.Core.Enums;
using XCalendar.Core.Extensions;
using XCalendar.Core.Models;
using XCalendarFormsSample.Helpers;
using XCalendarFormsSample.Models;

namespace XCalendarFormsSample.ViewModels
{
    public class ConnectingSelectedDaysExampleViewModel : BaseViewModel
    {
        #region Properties
        public Calendar<ConnectableDay> Calendar { get; set; } = new Calendar<ConnectableDay>()
        {
            SelectionType = SelectionType.Single,
            SelectionAction = SelectionAction.Modify
        };
        public bool ConnectDaysToLeft { get; set; } = true;
        public bool ConnectDaysToRight { get; set; } = true;
        public bool ConnectDaysToTop { get; set; }
        public bool ConnectDaysToBottom { get; set; }
        #endregion

        #region Commands
        public ICommand ShowSelectionTypeDialogCommand { get; set; }
        public ICommand ShowSelectionActionDialogCommand { get; set; }
        public ICommand NavigateCalendarCommand { get; set; }
        public ICommand ChangeDateSelectionCommand { get; set; }
        #endregion

        #region Constructors
        public ConnectingSelectedDaysExampleViewModel()
        {
            ShowSelectionTypeDialogCommand = new Command(ShowSelectionTypeDialog);
            ShowSelectionActionDialogCommand = new Command(ShowSelectionActionDialog);
            NavigateCalendarCommand = new Command<int>(NavigateCalendar);
            ChangeDateSelectionCommand = new Command<DateTime>(ChangeDateSelection);

            Calendar.DaysUpdated += Calendar_DaysUpdated;
            Calendar.DateSelectionChanged += Calendar_DateSelectionChanged;
        }
        #endregion

        #region Methods
        public async void ShowSelectionTypeDialog()
        {
            Calendar.SelectionType = await PopupHelper.ShowSelectItemDialogAsync(Calendar.SelectionType, PopupHelper.AllSelectionTypes);
        }
        public async void ShowSelectionActionDialog()
        {
            Calendar.SelectionAction = await PopupHelper.ShowSelectItemDialogAsync(Calendar.SelectionAction, PopupHelper.AllSelectionActions);
        }
        public void NavigateCalendar(int amount)
        {
            if (Calendar.NavigatedDate.TryAddMonths(amount, out DateTime targetDate))
            {
                Calendar.Navigate(targetDate - Calendar.NavigatedDate);
            }
            else
            {
                Calendar.Navigate(amount > 0 ? TimeSpan.MaxValue : TimeSpan.MinValue);
            }
        }
        public void ChangeDateSelection(DateTime dateTime)
        {
            Calendar.ChangeDateSelection(dateTime);
        }
        public void UpdateDayConnections()
        {
            //Calculate which days should be connected to each other. 
            for (int i = 0; i < Calendar.Days.Count; i++)
            {
                //Using indexes is faster than performing operations on the current day's date and also supports the Calendar's 'CustomDayNamesOrder' property.
                ConnectableDay day = Calendar.Days[i];

                int daysPerRow = (int)Math.Ceiling(Calendar.Days.Count / (double)Calendar.Rows);
                int dayToLeftIndex = i - 1;
                int dayToRightIndex = i + 1;
                int dayToTopIndex = i - daysPerRow;
                int dayToBottomIndex = i + daysPerRow;

                ConnectableDay dayToLeft = Calendar.Days.ElementAtOrDefault(dayToLeftIndex);
                ConnectableDay dayToRight = Calendar.Days.ElementAtOrDefault(dayToRightIndex);
                ConnectableDay dayToTop = Calendar.Days.ElementAtOrDefault(dayToTopIndex);
                ConnectableDay dayToBottom = Calendar.Days.ElementAtOrDefault(dayToBottomIndex);

                //This could be made more efficient by storing which days' sides have already been checked and skipping the calculation for that side when it's that day's turn to be processed.
                day.ConnectsToLeft = ConnectDaysToLeft && day.IsSelected && dayToLeft != null && dayToLeft.IsSelected;
                day.ConnectsToRight = ConnectDaysToRight && day.IsSelected && dayToRight != null && dayToRight.IsSelected;
                day.ConnectsToTop = ConnectDaysToTop && day.IsSelected && dayToTop != null && dayToTop.IsSelected;
                day.ConnectsToBottom = ConnectDaysToBottom && day.IsSelected && dayToBottom != null && dayToBottom.IsSelected;
            }
        }
        private void Calendar_DateSelectionChanged(object sender, DateSelectionChangedEventArgs e)
        {
            UpdateDayConnections();
        }
        private void Calendar_DaysUpdated(object sender, EventArgs e)
        {
            UpdateDayConnections();
        }
        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == nameof(ConnectDaysToLeft)
                || propertyName == nameof(ConnectDaysToRight)
                || propertyName == nameof(ConnectDaysToTop)
                || propertyName == nameof(ConnectDaysToBottom))
            {
                UpdateDayConnections();
            }
        }
        #endregion
    }
}
