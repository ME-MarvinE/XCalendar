using XCalendarMauiSample.ViewModels;

namespace XCalendarMauiSample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExamplesPage : ContentPage
    {
        public ExamplesPage()
        {
            InitializeComponent();
            BindingContext = new ExamplesViewModel();
        }
    }
}