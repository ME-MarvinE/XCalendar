using CommunityToolkit.Maui.Views;
using System.Windows.Input;
using XCalendar.Maui.Enums;
using XCalendarMauiSample.Helpers;
using XCalendarMauiSample.Popups;

namespace XCalendarMauiSample.ViewModels
{
    public class SelectionExampleViewModel : BaseViewModel
    {
        #region Properties
        public SelectionType SelectionType { get; set; } = SelectionType.Single;
        public SelectionAction SelectionAction { get; set; } = SelectionAction.Replace;
        public List<string> CommonFunctionalities { get; } = new List<string>()
        {
            "None",
            "Single",
            "Multiple",
            "Range"
        };
        #endregion

        #region Commands
        public ICommand ShowSelectionTypeDialogCommand { get; set; }
        public ICommand ShowSelectionActionDialogCommand { get; set; }
        public ICommand ShowCommonFunctionalityDialogCommand { get; set; }

        #endregion

        #region Constructors
        public SelectionExampleViewModel()
        {
            ShowSelectionTypeDialogCommand = new Command(ShowSelectionTypeDialog);
            ShowSelectionActionDialogCommand = new Command(ShowSelectionActionDialog);
            ShowCommonFunctionalityDialogCommand = new Command(ShowCommonFunctionalityDialog);
        }
        #endregion

        #region Methods
        public async void ShowSelectionTypeDialog()
        {
            SelectionType = await PopupHelper.ShowSelectionTypeDialog(SelectionType);
        }
        public async void ShowSelectionActionDialog()
        {
            SelectionAction = await PopupHelper.ShowSelectionActionDialog(SelectionAction);
        }
        public async void ShowCommonFunctionalityDialog()
        {
            string CommonFunctionality = (string)await Shell.Current.ShowPopupAsync(new SelectItemDialogPopup(CommonFunctionalities[1], CommonFunctionalities));

            switch (CommonFunctionality)
            {
                case "None":
                    SelectionType = SelectionType.None;
                    break;

                case "Single":
                    SelectionType = SelectionType.Single;
                    SelectionAction = SelectionAction.Replace;
                    break;

                case "Multiple":
                    SelectionType = SelectionType.Single;
                    SelectionAction = SelectionAction.Modify;
                    break;

                case "Range":
                    SelectionType = SelectionType.Range;
                    SelectionAction = SelectionAction.Replace;
                    break;
            }
        }
        #endregion
    }
}
