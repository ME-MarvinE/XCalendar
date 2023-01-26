namespace XCalendarMauiSample.CustomControls
{
    public partial class ColorEditor : ContentView
    {
        #region Properties

        #region Bindable Properties
        public Color SelectedColor
        {
            get { return (Color)GetValue(SelectedColorProperty); }
            set { SetValue(SelectedColorProperty, value); }
        }
        public float SelectedColorRed
        {
            get { return (float)GetValue(SelectedColorRedProperty); }
            set { SetValue(SelectedColorRedProperty, value); }
        }
        public float SelectedColorGreen
        {
            get { return (float)GetValue(SelectedColorGreenProperty); }
            set { SetValue(SelectedColorGreenProperty, value); }
        }
        public float SelectedColorBlue
        {
            get { return (float)GetValue(SelectedColorBlueProperty); }
            set { SetValue(SelectedColorBlueProperty, value); }
        }
        public float SelectedColorAlpha
        {
            get { return (float)GetValue(SelectedColorAlphaProperty); }
            set { SetValue(SelectedColorAlphaProperty, value); }
        }

        #region Bindable Properties Initialisers
        public static readonly BindableProperty SelectedColorProperty = BindableProperty.Create(nameof(SelectedColor), typeof(Color), typeof(ColorEditor), defaultBindingMode: BindingMode.TwoWay, propertyChanged: SelectedColorPropertyChanged);
        public static readonly BindableProperty SelectedColorRedProperty = BindableProperty.Create(nameof(SelectedColorRed), typeof(float), typeof(ColorEditor), defaultBindingMode: BindingMode.TwoWay, propertyChanged: SelectedColorRedPropertyChanged);
        public static readonly BindableProperty SelectedColorGreenProperty = BindableProperty.Create(nameof(SelectedColorGreen), typeof(float), typeof(ColorEditor), defaultBindingMode: BindingMode.TwoWay, propertyChanged: SelectedColorGreenPropertyChanged);
        public static readonly BindableProperty SelectedColorBlueProperty = BindableProperty.Create(nameof(SelectedColorBlue), typeof(float), typeof(ColorEditor), defaultBindingMode: BindingMode.TwoWay, propertyChanged: SelectedColorBluePropertyChanged);
        public static readonly BindableProperty SelectedColorAlphaProperty = BindableProperty.Create(nameof(SelectedColorAlpha), typeof(float), typeof(ColorEditor), defaultBindingMode: BindingMode.TwoWay, propertyChanged: SelectedColorAlphaPropertyChanged);
        #endregion

        #endregion

        #endregion

        #region Constructors
        public ColorEditor()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods
        private static void SelectedColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ColorEditor control = (ColorEditor)bindable;
            Color newColor = (Color)newValue;

            if (control.SelectedColorRed != newColor.Red) { control.SelectedColorRed = newColor.Red; }
            if (control.SelectedColorGreen != newColor.Green) { control.SelectedColorGreen = newColor.Green; }
            if (control.SelectedColorBlue != newColor.Blue) { control.SelectedColorBlue = newColor.Blue; }
            if (control.SelectedColorAlpha != newColor.Alpha) { control.SelectedColorAlpha = newColor.Alpha; }
        }
        private static void SelectedColorRedPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ColorEditor control = (ColorEditor)bindable;
            float newRed = (float)newValue;

            control.SelectedColor = new Color(newRed, control.SelectedColor.Green, control.SelectedColor.Blue, control.SelectedColor.Alpha);
        }
        private static void SelectedColorGreenPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ColorEditor control = (ColorEditor)bindable;
            float newGreen = (float)newValue;

            control.SelectedColor = new Color(control.SelectedColor.Red, newGreen, control.SelectedColor.Blue, control.SelectedColor.Alpha);
        }
        private static void SelectedColorBluePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ColorEditor control = (ColorEditor)bindable;
            float newBlue = (float)newValue;

            control.SelectedColor = new Color(control.SelectedColor.Red, control.SelectedColor.Green, newBlue, control.SelectedColor.Alpha);
        }
        private static void SelectedColorAlphaPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ColorEditor control = (ColorEditor)bindable;
            float newAlpha = (float)newValue;

            control.SelectedColor = new Color(control.SelectedColor.Red, control.SelectedColor.Green, control.SelectedColor.Blue, newAlpha);
        }
        #endregion
    }
}