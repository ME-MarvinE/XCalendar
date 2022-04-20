using XCalendarMauiSample.ViewModels;

namespace XCalendarMauiSample.Views
{
    public partial class CustomDatePickerDialogExamplePage : ContentPage
    {
        public CustomDatePickerDialogExamplePage()
        {
            InitializeComponent();
            BindingContext = new CustomDatePickerDialogExampleViewModel();
        }
    }
}