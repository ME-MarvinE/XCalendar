using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XCalendarFormsSample.ViewModels;

namespace XCalendarFormsSample.Views
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