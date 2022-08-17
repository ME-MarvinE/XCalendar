using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XCalendar.Forms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavigationView : ContentView
    {
        #region Properties

        #region Bindable Properties
        public TextTransform TextTransform
        {
            get { return (TextTransform)GetValue(TextTransformProperty); }
            set { SetValue(TextTransformProperty, value); }
        }
        public FormattedString FormattedText
        {
            get { return (FormattedString)GetValue(FormattedTextProperty); }
            set { SetValue(FormattedTextProperty, value); }
        }
        public TextAlignment HorizontalTextAlignment
        {
            get { return (TextAlignment)GetValue(HorizontalTextAlignmentProperty); }
            set { SetValue(HorizontalTextAlignmentProperty, value); }
        }
        public LineBreakMode LineBreakMode
        {
            get { return (LineBreakMode)GetValue(LineBreakModeProperty); }
            set { SetValue(LineBreakModeProperty, value); }
        }
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }
        public double CharacterSpacing
        {
            get { return (double)GetValue(CharacterSpacingProperty); }
            set { SetValue(CharacterSpacingProperty, value); }
        }
        public TextAlignment VerticalTextAlignment
        {
            get { return (TextAlignment)GetValue(VerticalTextAlignmentProperty); }
            set { SetValue(VerticalTextAlignmentProperty, value); }
        }
        public FontAttributes FontAttributes
        {
            get { return (FontAttributes)GetValue(FontAttributesProperty); }
            set { SetValue(FontAttributesProperty, value); }
        }
        public TextDecorations TextDecorations
        {
            get { return (TextDecorations)GetValue(TextDecorationsProperty); }
            set { SetValue(TextDecorationsProperty, value); }
        }
        public string FontFamily
        {
            get { return (string)GetValue(FontFamilyProperty); }
            set { SetValue(FontFamilyProperty, value); }
        }
        [TypeConverter(typeof(FontSizeConverter))]
        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }
        public double LineHeight
        {
            get { return (double)GetValue(LineHeightProperty); }
            set { SetValue(LineHeightProperty, value); }
        }
        public int MaxLines
        {
            get { return (int)GetValue(MaxLinesProperty); }
            set { SetValue(MaxLinesProperty, value); }
        }
        public TextType TextType
        {
            get { return (TextType)GetValue(TextTypeProperty); }
            set { SetValue(TextTypeProperty, value); }
        }
        public ICommand ForwardsArrowCommand
        {
            get { return (ICommand)GetValue(ForwardsArrowCommandProperty); }
            set { SetValue(ForwardsArrowCommandProperty, value); }
        }
        public object ForwardsArrowCommandParameter
        {
            get { return (object)GetValue(ForwardsArrowCommandParameterProperty); }
            set { SetValue(ForwardsArrowCommandParameterProperty, value); }
        }
        public ICommand BackwardsArrowCommand
        {
            get { return (ICommand)GetValue(BackwardsArrowCommandProperty); }
            set { SetValue(BackwardsArrowCommandProperty, value); }
        }
        public object BackwardsArrowCommandParameter
        {
            get { return (object)GetValue(BackwardsArrowCommandParameterProperty); }
            set { SetValue(BackwardsArrowCommandParameterProperty, value); }
        }
        public Color ArrowColor
        {
            get { return (Color)GetValue(ArrowColorProperty); }
            set { SetValue(ArrowColorProperty, value); }
        }
        public Color ArrowBackgroundColor
        {
            get { return (Color)GetValue(ArrowBackgroundColorProperty); }
            set { SetValue(ArrowBackgroundColorProperty, value); }
        }
        public float ArrowCornerRadius
        {
            get { return (float)GetValue(ArrowCornerRadiusProperty); }
            set { SetValue(ArrowCornerRadiusProperty, value); }
        }

        #region Bindable Properties Initialisers
        public static readonly BindableProperty CharacterSpacingProperty = BindableProperty.Create(nameof(CharacterSpacing), typeof(double), typeof(NavigationView), Label.CharacterSpacingProperty.DefaultValue);
        public static readonly BindableProperty FontAttributesProperty = BindableProperty.Create(nameof(FontAttributes), typeof(FontAttributes), typeof(NavigationView), FontAttributes.Bold);
        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(NavigationView), Label.FontFamilyProperty.DefaultValue);
        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(nameof(FontSize), typeof(double), typeof(NavigationView), 18d);
        public static readonly BindableProperty FormattedTextProperty = BindableProperty.Create(nameof(FormattedText), typeof(FormattedString), typeof(NavigationView), Label.FormattedTextProperty.DefaultValue);
        public static readonly BindableProperty HorizontalTextAlignmentProperty = BindableProperty.Create(nameof(HorizontalTextAlignment), typeof(TextAlignment), typeof(NavigationView), TextAlignment.Center);
        public static readonly BindableProperty LineBreakModeProperty = BindableProperty.Create(nameof(LineBreakMode), typeof(LineBreakMode), typeof(NavigationView), Label.LineBreakModeProperty.DefaultValue);
        public static readonly BindableProperty LineHeightProperty = BindableProperty.Create(nameof(LineHeight), typeof(double), typeof(NavigationView), Label.LineHeightProperty.DefaultValue);
        public static readonly BindableProperty MaxLinesProperty = BindableProperty.Create(nameof(MaxLines), typeof(int), typeof(NavigationView), Label.MaxLinesProperty.DefaultValue);
        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(NavigationView), Label.TextProperty.DefaultValue);
        public static readonly BindableProperty TextDecorationsProperty = BindableProperty.Create(nameof(TextDecorations), typeof(TextDecorations), typeof(NavigationView), Label.TextDecorationsProperty.DefaultValue);
        public static readonly BindableProperty TextTransformProperty = BindableProperty.Create(nameof(TextTransform), typeof(TextTransform), typeof(NavigationView), Label.TextTransformProperty.DefaultValue);
        public static readonly BindableProperty TextTypeProperty = BindableProperty.Create(nameof(TextType), typeof(TextType), typeof(NavigationView), Label.TextTypeProperty.DefaultValue);
        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(NavigationView), Color.White);
        public static readonly BindableProperty VerticalTextAlignmentProperty = BindableProperty.Create(nameof(VerticalTextAlignment), typeof(TextAlignment), typeof(NavigationView), TextAlignment.Center);
        public static readonly BindableProperty ForwardsArrowCommandProperty = BindableProperty.Create(nameof(ForwardsArrowCommand), typeof(object), typeof(NavigationView));
        public static readonly BindableProperty ForwardsArrowCommandParameterProperty = BindableProperty.Create(nameof(ForwardsArrowCommandParameter), typeof(object), typeof(NavigationView));
        public static readonly BindableProperty BackwardsArrowCommandProperty = BindableProperty.Create(nameof(BackwardsArrowCommand), typeof(object), typeof(NavigationView));
        public static readonly BindableProperty BackwardsArrowCommandParameterProperty = BindableProperty.Create(nameof(BackwardsArrowCommandParameter), typeof(object), typeof(NavigationView));
        public static readonly BindableProperty ArrowColorProperty = BindableProperty.Create(nameof(ArrowColor), typeof(Color), typeof(NavigationView), Color.White);
        public static readonly BindableProperty ArrowBackgroundColorProperty = BindableProperty.Create(nameof(ArrowBackgroundColor), typeof(Color), typeof(NavigationView), Color.Transparent);
        public static readonly BindableProperty ArrowCornerRadiusProperty = BindableProperty.Create(nameof(ArrowCornerRadius), typeof(float), typeof(NavigationView), 100f);
        #endregion

        #endregion

        #endregion

        #region Constructors
        public NavigationView()
        {
            InitializeComponent();
        }
        #endregion
    }
}