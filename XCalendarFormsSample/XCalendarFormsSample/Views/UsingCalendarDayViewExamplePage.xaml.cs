using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XCalendarFormsSample.ViewModels;

namespace XCalendarFormsSample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsingCalendarDayViewExamplePage : ContentPage
    {
        public UsingCalendarDayViewExamplePage()
        {
            InitializeComponent();
            BindingContext = new UsingCalendarDayViewExampleViewModel();
        }
    }
}