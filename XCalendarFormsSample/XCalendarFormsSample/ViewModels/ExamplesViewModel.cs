using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XCalendarFormsSample.Views;

namespace XCalendarFormsSample.ViewModels
{
    public class ExamplesViewModel : BaseViewModel
    {
        #region Commands
        public ICommand ShowEventCalendarExampleCommand { get; set; }
        public ICommand ShowCustomDatePickerDialogExampleCommand { get; set; }
        #endregion

        #region Constructors
        public ExamplesViewModel()
        {
            ShowEventCalendarExampleCommand = new Command(async () => await ShowEventCalendarExample());
            ShowCustomDatePickerDialogExampleCommand = new Command(async () => await ShowCustomDatePickerDialogExample());
        }
        #endregion

        #region Methods
        public async Task ShowEventCalendarExample()
        {
            await Shell.Current.Navigation.PushAsync(new EventCalendarExamplePage());
        }
        public async Task ShowCustomDatePickerDialogExample()
        {
            await Shell.Current.Navigation.PushAsync(new CustomDatePickerDialogExamplePage());
        }
        
        #endregion
    }
}
