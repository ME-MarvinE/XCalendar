using System.Collections;
using System.Windows.Input;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XCalendarFormsSample.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
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
        public ICommand DismissDialogCommand { get; set; }
        public ICommand CancelDialogCommand { get; set; }
        public ICommand ResetReturnValueCommand { get; set; }
        #endregion

        #endregion

        #region Constructors
        public SelectItemDialogPopup(object initialValue, IEnumerable itemsSource)
        {
            DismissDialogCommand = new Command(() => Dismiss(ReturnValue));
            CancelDialogCommand = new Command(CancelDialog);
            ResetReturnValueCommand = new Command(ResetReturnValue);

            InitializeComponent();

            _initialValue = initialValue;
            ItemsSource = itemsSource;

            ResetReturnValue();
        }
        #endregion

        #region Methods
        public void CancelDialog()
        {
            Dismiss(_initialValue);
        }
        public void ResetReturnValue()
        {
            ReturnValue = _initialValue;
        }
        protected override object GetLightDismissResult()
        {
            return _initialValue;
        }
        #endregion
    }
}