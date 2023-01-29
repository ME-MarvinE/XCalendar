using CommunityToolkit.Maui.Views;
using System.Collections;
using System.Windows.Input;

namespace XCalendarMauiSample.Popups
{
    public partial class SelectItemDialogPopup : Popup
    {
        #region Properties
        private object _initialValue { get; }

        #region Bindable Properties
        public object ReturnValue
        {
            get { return (object)GetValue(ReturnValueProperty); }
            set { SetValue(ReturnValueProperty, value); }
        }
        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        #region Bindable Properties Initialisers
        public static readonly BindableProperty ReturnValueProperty = BindableProperty.Create(nameof(ReturnValue), typeof(object), typeof(SelectItemDialogPopup));
        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable), typeof(SelectItemDialogPopup));
        #endregion

        #endregion

        #region Commands
        public ICommand CloseDialogCommand { get; set; }
        public ICommand CancelDialogCommand { get; set; }
        public ICommand ResetReturnValueCommand { get; set; }
        #endregion

        #endregion

        #region Constructors
        public SelectItemDialogPopup(object initialValue, IEnumerable itemsSource)
        {
            CloseDialogCommand = new Command(() => Close(ReturnValue));
            CancelDialogCommand = new Command(CancelDialog);
            ResetReturnValueCommand = new Command(ResetReturnValue);

            InitializeComponent();

            _initialValue = initialValue;
            ItemsSource = itemsSource;

            ResetReturnValue();
            ResultWhenUserTapsOutsideOfPopup = _initialValue;
        }
        #endregion

        #region Methods
        public void CancelDialog()
        {
            Close(_initialValue);
        }
        public void ResetReturnValue()
        {
            ReturnValue = _initialValue;
        }
        #endregion
    }
}