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
            ColorEditor Control = (ColorEditor)bindable;
            Color NewColor = (Color)newValue;

            if (Control.SelectedColorRed != NewColor.Red) { Control.SelectedColorRed = NewColor.Red; }
            if (Control.SelectedColorGreen != NewColor.Green) { Control.SelectedColorGreen = NewColor.Green; }
            if (Control.SelectedColorBlue != NewColor.Blue) { Control.SelectedColorBlue = NewColor.Blue; }
            if (Control.SelectedColorAlpha != NewColor.Alpha) { Control.SelectedColorAlpha = NewColor.Alpha; }
        }
        private static void SelectedColorRedPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ColorEditor Control = (ColorEditor)bindable;
            float NewRed = (float)newValue;

            Control.SelectedColor = new Color(NewRed, Control.SelectedColor.Green, Control.SelectedColor.Blue, Control.SelectedColor.Alpha);
        }
        private static void SelectedColorGreenPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ColorEditor Control = (ColorEditor)bindable;
            float NewGreen = (float)newValue;

            Control.SelectedColor = new Color(Control.SelectedColor.Red, NewGreen, Control.SelectedColor.Blue, Control.SelectedColor.Alpha);
        }
        private static void SelectedColorBluePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ColorEditor Control = (ColorEditor)bindable;
            float NewBlue = (float)newValue;

            Control.SelectedColor = new Color(Control.SelectedColor.Red, Control.SelectedColor.Green, NewBlue, Control.SelectedColor.Alpha);
        }
        private static void SelectedColorAlphaPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ColorEditor Control = (ColorEditor)bindable;
            float NewAlpha = (float)newValue;

            Control.SelectedColor = new Color(Control.SelectedColor.Red, Control.SelectedColor.Green, Control.SelectedColor.Blue, NewAlpha);
        }
        #endregion
    }
}