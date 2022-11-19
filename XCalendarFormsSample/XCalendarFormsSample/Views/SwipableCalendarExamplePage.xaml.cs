using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XCalendarFormsSample.ViewModels;

namespace XCalendarFormsSample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SwipableCalendarExamplePage : ContentPage
    {
        public SwipableCalendarExamplePage()
        {
            InitializeComponent();
            BindingContext = new SwipableCalendarExampleViewModel();
        }
    }
}