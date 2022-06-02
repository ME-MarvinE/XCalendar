using XCalendarMauiSample.ViewModels;

namespace XCalendarMauiSample.Views
{
    public partial class SelectionExamplePage : ContentPage
    {
        public SelectionExamplePage()
        {
            InitializeComponent();
            BindingContext = new SelectionExampleViewModel();
        }
    }
}