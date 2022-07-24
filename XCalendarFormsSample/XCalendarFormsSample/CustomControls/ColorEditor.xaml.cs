using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XCalendarFormsSample.CustomControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ColorEditor : ContentView
    {
        #region Properties

        #region Bindable Properties
        public Color SelectedColor
        {
            get { return (Color)GetValue(SelectedColorProperty); }
            set { SetValue(SelectedColorProperty, value); }
        }
        public double SelectedColorR
        {
            get { return (double)GetValue(SelectedColorRProperty); }
            set { SetValue(SelectedColorRProperty, value); }
        }
        public double SelectedColorG
        {
            get { return (double)GetValue(SelectedColorGProperty); }
            set { SetValue(SelectedColorGProperty, value); }
        }
        public double SelectedColorB
        {
            get { return (double)GetValue(SelectedColorBProperty); }
            set { SetValue(SelectedColorBProperty, value); }
        }
        public double SelectedColorA
        {
            get { return (double)GetValue(SelectedColorAProperty); }
            set { SetValue(SelectedColorAProperty, value); }
        }

        #region Bindable Properties Initialisers
        public static readonly BindableProperty SelectedColorProperty = BindableProperty.Create(nameof(SelectedColor), typeof(Color), typeof(ColorEditor), defaultBindingMode: BindingMode.TwoWay, propertyChanged: SelectedColorPropertyChanged);
        public static readonly BindableProperty SelectedColorRProperty = BindableProperty.Create(nameof(SelectedColorR), typeof(double), typeof(ColorEditor), defaultBindingMode: BindingMode.TwoWay, propertyChanged: SelectedColorRPropertyChanged);
        public static readonly BindableProperty SelectedColorGProperty = BindableProperty.Create(nameof(SelectedColorG), typeof(double), typeof(ColorEditor), defaultBindingMode: BindingMode.TwoWay, propertyChanged: SelectedColorGPropertyChanged);
        public static readonly BindableProperty SelectedColorBProperty = BindableProperty.Create(nameof(SelectedColorB), typeof(double), typeof(ColorEditor), defaultBindingMode: BindingMode.TwoWay, propertyChanged: SelectedColorBPropertyChanged);
        public static readonly BindableProperty SelectedColorAProperty = BindableProperty.Create(nameof(SelectedColorA), typeof(double), typeof(ColorEditor), defaultBindingMode: BindingMode.TwoWay, propertyChanged: SelectedColorAPropertyChanged);
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

            if (Control.SelectedColorR != NewColor.R) { Control.SelectedColorR = NewColor.R; }
            if (Control.SelectedColorG != NewColor.G) { Control.SelectedColorG = NewColor.G; }
            if (Control.SelectedColorB != NewColor.B) { Control.SelectedColorB = NewColor.B; }
            if (Control.SelectedColorA != NewColor.A) { Control.SelectedColorA = NewColor.A; }
        }
        private static void SelectedColorRPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ColorEditor Control = (ColorEditor)bindable;
            double NewR = (double)newValue;

            Control.SelectedColor = new Color(NewR, Control.SelectedColor.G, Control.SelectedColor.B, Control.SelectedColor.A);
        }
        private static void SelectedColorGPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ColorEditor Control = (ColorEditor)bindable;
            double NewG = (double)newValue;

            Control.SelectedColor = new Color(Control.SelectedColor.R, NewG, Control.SelectedColor.B, Control.SelectedColor.A);
        }
        private static void SelectedColorBPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ColorEditor Control = (ColorEditor)bindable;
            double NewB = (double)newValue;

            Control.SelectedColor = new Color(Control.SelectedColor.R, Control.SelectedColor.G, NewB, Control.SelectedColor.A);
        }
        private static void SelectedColorAPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ColorEditor Control = (ColorEditor)bindable;
            double NewA = (double)newValue;

            Control.SelectedColor = new Color(Control.SelectedColor.R, Control.SelectedColor.G, Control.SelectedColor.B, NewA);
        }
        #endregion
    }
}