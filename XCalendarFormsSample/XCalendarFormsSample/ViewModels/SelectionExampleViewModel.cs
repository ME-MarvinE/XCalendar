using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using XCalendar.Core.Enums;
using XCalendar.Core.Models;
using XCalendarFormsSample.Helpers;
using XCalendarFormsSample.Popups;

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
            Calendar.SelectionType = await PopupHelper.ShowSelectionTypeDialog(Calendar.SelectionType);
        }
        public async void ShowSelectionActionDialog()
        {
            Calendar.SelectionAction = await PopupHelper.ShowSelectionActionDialog(Calendar.SelectionAction);
        }
        public async void ShowCommonFunctionalityDialog()
        {
            string CommonFunctionality = (string)await Shell.Current.ShowPopupAsync(new SelectItemDialogPopup(CommonFunctionalities[1], CommonFunctionalities));

            switch (CommonFunctionality)
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
        public void NavigateCalendar(int Amount)
        {
            Calendar?.NavigateCalendar(Amount);
        }
        public void ChangeDateSelection(DateTime DateTime)
        {
            Calendar?.ChangeDateSelection(DateTime);
        }
        #endregion
    }
}
