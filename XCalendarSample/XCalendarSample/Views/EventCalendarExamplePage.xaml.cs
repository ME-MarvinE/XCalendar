
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XCalendarSample.ViewModels;

namespace XCalendarSample.Views
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