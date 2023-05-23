using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XCalendarFormsSample.ViewModels;

namespace XCalendarFormsSample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DuolingoStreakCalendarExamplePage : ContentPage
    {
        public DuolingoStreakCalendarExamplePage()
        {
            InitializeComponent();
            BindingContext = new DuolingoStreakCalendarExampleViewModel();
        }
    }
}