using CommunityToolkit.Maui.Views;
using System.Windows.Input;
using XCalendarMauiSample.Helpers;
using XCalendarMauiSample.Popups;

namespace XCalendarMauiSample.ViewModels
{
    public class CustomDatePickerDialogExampleViewModel : BaseViewModel
    {
        #region Properties
        public DateTime SelectedDate { get; set; } = DateTime.Today;
        #endregion

        #region Commands
        public ICommand ShowDatePickerDialogCommand { get; set; }
        #endregion

        #region Constructors
        public CustomDatePickerDialogExampleViewModel()
        {
            ShowDatePickerDialogCommand = new Command<DateTime>(ShowDatePickerDialog);
        }
        #endregion

        #region Methods
        public async void ShowDatePickerDialog(DateTime initialDate)
        {
            SelectedDate = await PopupHelper.ShowDatePickerDialogAsync(initialDate);
        }
        #endregion
    }
}
