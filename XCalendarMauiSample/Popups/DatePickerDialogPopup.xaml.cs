using PropertyChanged;
using System;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using CommunityToolkit.Maui.Views;

namespace XCalendarMauiSample.Popups
{
    [AddINotifyPropertyChangedInterface]
    public partial class DatePickerDialogPopup : Popup
    {
        #region Properties
        public DateTime InitialDate { get; }
        public DateTime SelectedDate { get; set; }
        public RangeObservableCollection<DateTime> SelectedDates { get; } = new RangeObservableCollection<DateTime>() { DateTime.Today };
        public DateTime NavigatedDate { get; set; } = DateTime.Today;
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

            SelectedDates.CollectionChanged += SelectedDates_CollectionChanged;

            this.InitialDate = InitialDate;
            ResultWhenUserTapsOutsideOfPopup = InitialDate;
            SelectedDates.ReplaceRange(new List<DateTime>() { InitialDate } );

            InitializeComponent();
            ResetNavigatedDate();
        }

        private void SelectedDates_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            SelectedDate = SelectedDates.FirstOrDefault();
        }
        #endregion

        #region Methods
        public void ResetNavigatedDate()
        {
            NavigatedDate = SelectedDate;
        }
        public void ReturnInitialDate()
        {
            Close(InitialDate);
        }
        public void ReturnSelectedDate()
        {
            Close(SelectedDate);
        }
        #endregion
    }
}