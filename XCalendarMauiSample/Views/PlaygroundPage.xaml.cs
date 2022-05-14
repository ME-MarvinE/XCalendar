using XCalendarMauiSample.ViewModels;

namespace XCalendarMauiSample.Views
{
    public partial class PlaygroundPage : ContentPage
    {
        public PlaygroundPage()
        {
            InitializeComponent();
            BindingContext = new PlaygroundViewModel();
        }
    }
}
