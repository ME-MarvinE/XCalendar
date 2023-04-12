using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XCalendarFormsSample.ViewModels;

namespace XCalendarFormsSample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConnectingSelectedDaysExamplePage : ContentPage
    {
        public ConnectingSelectedDaysExamplePage()
        {
            InitializeComponent();
            BindingContext = new ConnectingSelectedDaysExampleViewModel();
        }
    }
}