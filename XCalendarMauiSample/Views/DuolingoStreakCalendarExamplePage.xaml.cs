using XCalendarMauiSample.ViewModels;

namespace XCalendarMauiSample.Views;

public partial class DuolingoStreakCalendarExamplePage : ContentPage
{
	public DuolingoStreakCalendarExamplePage()
	{
		InitializeComponent();
        BindingContext = new DuolingoStreakCalendarExampleViewModel();
    }
}