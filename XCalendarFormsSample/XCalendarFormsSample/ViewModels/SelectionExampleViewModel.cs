using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using XCalendar.Core.Enums;
using XCalendar.Core.Extensions;
using XCalendar.Core.Models;
using XCalendarFormsSample.Helpers;

namespace XCalendarFormsSample.ViewModels
{
    public class SelectionExampleViewModel : BaseViewModel
    {
        #region Properties
        public List<string> CommonFunctionalities { get; } = new List<string>()
        {
            "None",
            "Single",
            "Multiple",
            "Range"
        };
        public Calendar<CalendarDay> Calendar { get; set; } = new Calendar<CalendarDay>()
        {
            SelectionType = SelectionType.Single,
            SelectionAction = SelectionAction.Replace
        };
        #endregion

        #region Commands
        public ICommand ShowSelectionTypeDialogCommand { get; set; }
        public ICommand ShowSelectionActionDialogCommand { get; set; }
        public ICommand ShowCommonFunctionalityDialogCommand { get; set; }
        public ICommand NavigateCalendarCommand { get; set; }
        public ICommand ChangeDateSelectionCommand { get; set; }
        #endregion

        #region Constructors
        public SelectionExampleViewModel()
        {
            ShowSelectionTypeDialogCommand = new Command(ShowSelectionTypeDialog);
            ShowSelectionActionDialogCommand = new Command(ShowSelectionActionDialog);
            ShowCommonFunctionalityDialogCommand = new Command(ShowCommonFunctionalityDialog);
            NavigateCalendarCommand = new Command<int>(NavigateCalendar);
            ChangeDateSelectionCommand = new Command<DateTime>(ChangeDateSelection);
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
        public async void ShowCommonFunctionalityDialog()
        {
            string commonFunctionality = await PopupHelper.ShowSelectItemDialogAsync(CommonFunctionalities[1], CommonFunctionalities);

            switch (commonFunctionality)
            {
                case "None":
                    Calendar.SelectionType = SelectionType.None;
                    break;

                case "Single":
                    Calendar.SelectionType = SelectionType.Single;
                    Calendar.SelectionAction = SelectionAction.Replace;
                    break;

                case "Multiple":
                    Calendar.SelectionType = SelectionType.Single;
                    Calendar.SelectionAction = SelectionAction.Modify;
                    break;

                case "Range":
                    Calendar.SelectionType = SelectionType.Range;
                    Calendar.SelectionAction = SelectionAction.Replace;
                    break;
            }
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
            Calendar?.ChangeDateSelection(dateTime);
        }
        #endregion
    }
}
