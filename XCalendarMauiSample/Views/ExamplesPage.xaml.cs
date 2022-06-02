using XCalendarMauiSample.ViewModels;

namespace XCalendarMauiSample.Views
{
    public partial class ExamplesPage : ContentPage
    {
        public ExamplesPage()
        {
            InitializeComponent();
            BindingContext = new ExamplesViewModel();
        }
    }
}