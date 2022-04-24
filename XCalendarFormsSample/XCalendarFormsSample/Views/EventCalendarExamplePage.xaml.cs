
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XCalendarFormsSample.ViewModels;

namespace XCalendarFormsSample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventCalendarExamplePage : ContentPage
    {
        public EventCalendarExamplePage()
        {
            InitializeComponent();
            BindingContext = new EventCalendarExampleViewModel();
        }
    }
}