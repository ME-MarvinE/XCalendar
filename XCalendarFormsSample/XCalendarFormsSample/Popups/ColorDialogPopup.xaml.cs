using System.Windows.Input;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XCalendarFormsSample.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ColorDialogPopup : Popup<Color>
    {
        #region Properties

        public Color InitialSelectedColor { get; }

        #region Bindable Properties
        public Color SelectedColor
        {
            get { return (Color)GetValue(SelectedColorProperty); }
            set { SetValue(SelectedColorProperty, value); }
        }

        #region Bindable Properties Initialisers
        public static readonly BindableProperty SelectedColorProperty = BindableProperty.Create(nameof(SelectedColor), typeof(Color), typeof(ColorDialogPopup));
        #endregion

        #endregion

        #region Commands
        public ICommand CancelDialogCommand { get; }
        public ICommand DismissDialogCommand { get; }
        public ICommand ResetReturnValueCommand { get; }
        #endregion

        #endregion

        #region Constructors
        public ColorDialogPopup()
            : this(Color.Default)
        {
        }
        public ColorDialogPopup(Color InitialSelectedColor)
        {
            CancelDialogCommand = new Command(CancelDialog);
            DismissDialogCommand = new Command(DismissDialog);
            ResetReturnValueCommand = new Command(ResetReturnValue);

            InitializeComponent();

            this.InitialSelectedColor = InitialSelectedColor;
            SelectedColor = InitialSelectedColor;
        }
        #endregion

        #region Methods
        public void CancelDialog()
        {
            Dismiss(InitialSelectedColor);
        }
        public void DismissDialog()
        {
            Dismiss(SelectedColor);
        }
        public void ResetReturnValue()
        {
            SelectedColor = InitialSelectedColor;
        }
        protected override Color GetLightDismissResult()
        {
            return InitialSelectedColor;
        }
        #endregion
    }
}