using System.Windows.Input;
using XCalendar.Core.Enums;
using XCalendar.Core.Extensions;
using XCalendar.Core.Models;
using XCalendarMauiSample.Helpers;

namespace XCalendarMauiSample.ViewModels
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
        public int ForwardsNavigationAmount { get; set; } = 1;
        public int BackwardsNavigationAmount { get; set; } = -1;
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
            string CommonFunctionality = await PopupHelper.ShowSelectItemDialog(CommonFunctionalities[1], CommonFunctionalities);

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
            if (Calendar.NavigatedDate.TryAddMonths(Amount, out DateTime TargetDate))
            {
                Calendar.NavigateCalendar(TargetDate - Calendar.NavigatedDate);
            }
            else
            {
                Calendar.NavigateCalendar(Amount > 0 ? TimeSpan.MaxValue : TimeSpan.MinValue);
            }
        }
        public void ChangeDateSelection(DateTime DateTime)
        {
            Calendar?.ChangeDateSelection(DateTime);
        }
        #endregion
    }
}
