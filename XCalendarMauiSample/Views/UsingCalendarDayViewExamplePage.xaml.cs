using XCalendarMauiSample.ViewModels;

namespace XCalendarMauiSample.Views
{
    public partial class UsingCalendarDayViewExamplePage : ContentPage
    {
        public UsingCalendarDayViewExamplePage()
        {
            InitializeComponent();
            BindingContext = new UsingCalendarDayViewExampleViewModel();
        }
    }
}