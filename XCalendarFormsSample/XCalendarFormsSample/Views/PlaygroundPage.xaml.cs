using XCalendarFormsSample.ViewModels;
using Xamarin.Forms;

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
