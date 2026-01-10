using CommunityToolkit.Maui.Views;
using System.Windows.Input;

namespace XCalendarMauiSample.Popups
{
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
            : this(new Color())
        {
        }
        public ColorDialogPopup(Color initialSelectedColor)
        {
            CancelDialogCommand = new Command(CancelDialog);
            DismissDialogCommand = new Command(DismissDialog);
            ResetReturnValueCommand = new Command(ResetReturnValue);

            InitializeComponent();

            InitialSelectedColor = initialSelectedColor;
            SelectedColor = initialSelectedColor;
        }
        #endregion

        #region Methods
        public async void CancelDialog()
        {
            await CloseAsync(InitialSelectedColor);
        }
        public async void DismissDialog()
        {
            await CloseAsync(SelectedColor);
        }
        public void ResetReturnValue()
        {
            SelectedColor = InitialSelectedColor;
        }
        #endregion
    }
}