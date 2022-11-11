using XCalendarMauiSample.ViewModels;

namespace XCalendarMauiSample.Views
{
    public partial class SwipableCalendarExamplePage : ContentPage
    {
        public SwipableCalendarExamplePage()
        {
            InitializeComponent();
            BindingContext = new SwipableCalendarExampleViewModel();
        }
    }
}