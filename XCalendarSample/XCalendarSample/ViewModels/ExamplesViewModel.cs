using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XCalendarSample.Views;

namespace XCalendarSample.ViewModels
{
    public class ExamplesViewModel : BaseViewModel
    {
        #region Commands
        public ICommand ShowEventCalendarExampleCommand { get; set; }
        #endregion

        #region Constructors
        public ExamplesViewModel()
        {
            ShowEventCalendarExampleCommand = new Command(async () => await ShowEventCalendarExample());
        }
        #endregion

        #region Methods
        public async Task ShowEventCalendarExample()
        {
            await Shell.Current.Navigation.PushAsync(new EventCalendarExamplePage());
        }
        #endregion
    }
}
