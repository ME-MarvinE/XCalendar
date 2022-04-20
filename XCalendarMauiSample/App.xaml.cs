using XCalendarMauiSample.Views;

namespace XCalendarMauiSample
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}