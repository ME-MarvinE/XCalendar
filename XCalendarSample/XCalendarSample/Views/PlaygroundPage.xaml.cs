using XCalendarSample.ViewModels;
using Xamarin.Forms;

namespace XCalendarSample.Views
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
