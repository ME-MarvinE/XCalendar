using Xamarin.Forms;
using XCalendarFormsSample.ViewModels;

namespace XCalendarFormsSample.Views
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
