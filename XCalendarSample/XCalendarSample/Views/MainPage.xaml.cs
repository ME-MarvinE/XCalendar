using XCalendarSample.ViewModels;
using Xamarin.Forms;

namespace XCalendarSample.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
        }
    }
}
