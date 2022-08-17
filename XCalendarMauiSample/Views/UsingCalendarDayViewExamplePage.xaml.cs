using XCalendarMauiSample.ViewModels;

namespace XCalendarMauiSample.Views
{
    public partial class UsingDayViewExamplePage : ContentPage
    {
        public UsingDayViewExamplePage()
        {
            InitializeComponent();
            BindingContext = new UsingDayViewExampleViewModel();
        }
    }
}