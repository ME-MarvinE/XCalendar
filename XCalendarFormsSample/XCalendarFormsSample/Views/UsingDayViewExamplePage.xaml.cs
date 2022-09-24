using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XCalendarFormsSample.ViewModels;

namespace XCalendarFormsSample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsingDayViewExamplePage : ContentPage
    {
        public UsingDayViewExamplePage()
        {
            InitializeComponent();
            BindingContext = new UsingDayViewExampleViewModel();
        }
    }
}