using XCalendarMauiSample.ViewModels;

namespace XCalendarMauiSample.Views
{
    public partial class CustomisingADayExamplePage : ContentPage
    {
        public CustomisingADayExamplePage()
        {
            InitializeComponent();
            BindingContext = new CustomisingADayExampleViewModel();
        }
    }
}