using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XCalendarFormsSample.ViewModels;

namespace XCalendarFormsSample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomisingADayExamplePage : ContentPage
    {
        public CustomisingADayExamplePage()
        {
            InitializeComponent();
            BindingContext = new CustomisingADayExampleViewModel();
        }
    }
}