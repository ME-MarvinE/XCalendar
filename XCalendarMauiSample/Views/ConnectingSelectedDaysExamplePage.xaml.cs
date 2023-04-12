using XCalendarMauiSample.ViewModels;

namespace XCalendarMauiSample.Views
{
    public partial class ConnectingSelectedDaysExamplePage : ContentPage
    {
        public ConnectingSelectedDaysExamplePage()
        {
            InitializeComponent();
            BindingContext = new ConnectingSelectedDaysExampleViewModel();
        }
    }
}