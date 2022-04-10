using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XCalendarSample.ViewModels;

namespace XCalendarSample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomDatePickerDialogExamplePage : ContentPage
    {
        public CustomDatePickerDialogExamplePage()
        {
            InitializeComponent();
            BindingContext = new CustomDatePickerDialogExampleViewModel();
        }
    }
}