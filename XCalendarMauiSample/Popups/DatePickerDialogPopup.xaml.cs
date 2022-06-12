using PropertyChanged;
using System;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using CommunityToolkit.Maui.Views;
using XCalendar.Maui;
using XCalendar.Core.Models;
using XCalendar.Core.Enums;

namespace XCalendarMauiSample.Popups
{
    [AddINotifyPropertyChangedInterface]
    public partial class DatePickerDialogPopup : Popup
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
            ResultWhenUserTapsOutsideOfPopup = InitialDate;
            Calendar.SelectedDates.ReplaceRange(new List<DateTime>() { InitialDate } );

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
            Close(InitialDate);
        }
        public void ReturnSelectedDate()
        {
            Close(SelectedDate);
        }
        #endregion
    }
}