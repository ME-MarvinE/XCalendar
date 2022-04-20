using XCalendarMauiSample.ViewModels;

namespace XCalendarMauiSample.Views
{
    public partial class EventCalendarExamplePage : ContentPage
    {
        public EventCalendarExamplePage()
        {
            InitializeComponent();
            BindingContext = new EventCalendarExampleViewModel();
        }
    }
}