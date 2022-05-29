using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XCalendarFormsSample.ViewModels;

namespace XCalendarFormsSample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectionExamplePage : ContentPage
    {
        public SelectionExamplePage()
        {
            InitializeComponent();
            BindingContext = new SelectionExampleViewModel();
        }
    }
}