using PropertyChanged;
using System;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Input;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XCalendar.Core.Enums;
using XCalendar.Core.Models;

namespace XCalendarFormsSample.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [AddINotifyPropertyChangedInterface]
    public partial class DatePickerDialogPopup : Popup<DateTime>
    {
        #region Properties
        public DateTime InitialDate { get; }
        public DateTime SelectedDate { get; set; }
        public Calendar Calendar { get; } = new Calendar()
        {
            NavigatedDate = DateTime.Today,
            SelectedDates = new ObservableRangeCollection<DateTime>() { DateTime.Today },
            SelectionAction = SelectionAction.Replace,
            SelectionType = SelectionType.Single
        };
        #endregion

        #region Commands
        public ICommand ReturnSelectedDateCommand { get; set; }
        public ICommand ReturnInitialDateCommand { get; set; }
        public ICommand ResetNavigatedDateCommand { get; set; }
        #endregion

        #region Constructors
        public DatePickerDialogPopup(DateTime InitialDate)
        {
            ReturnSelectedDateCommand = new Command(ReturnSelectedDate);
            ReturnInitialDateCommand = new Command(ReturnInitialDate);
            ResetNavigatedDateCommand = new Command(ResetNavigatedDate);

            Calendar.SelectedDates.CollectionChanged += SelectedDates_CollectionChanged;

            this.InitialDate = InitialDate;
            Calendar.SelectedDates.Replace(InitialDate);

            InitializeComponent();
            ResetNavigatedDate();
        }

        private void SelectedDates_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            SelectedDate = Calendar.SelectedDates.FirstOrDefault();
        }
        #endregion

        #region Methods
        public void ResetNavigatedDate()
        {
            Calendar.NavigatedDate = SelectedDate;
        }
        public void ReturnInitialDate()
        {
            Dismiss(InitialDate);
        }
        public void ReturnSelectedDate()
        {
            Dismiss(SelectedDate);
        }
        protected override DateTime GetLightDismissResult()
        {
            return InitialDate;
        }
        #endregion
    }
}