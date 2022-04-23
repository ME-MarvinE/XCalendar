using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace XCalendar.Maui.Views;

public partial class BorderedLabel : Border
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

    #endregion

    #region Bindable Properties Initialisers
    public static readonly BindableProperty CharacterSpacingProperty = BindableProperty.Create(nameof(CharacterSpacing), typeof(double), typeof(BorderedLabel), Label.CharacterSpacingProperty.DefaultValue);
    public static readonly BindableProperty FontAttributesProperty = BindableProperty.Create(nameof(FontAttributes), typeof(FontAttributes), typeof(BorderedLabel), Label.FontAttributesProperty.DefaultValue);
    public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(BorderedLabel), Label.FontFamilyProperty.DefaultValue);
    public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(nameof(FontSize), typeof(double), typeof(BorderedLabel), Label.FontSizeProperty.DefaultValue);
    public static readonly BindableProperty FormattedTextProperty = BindableProperty.Create(nameof(FormattedText), typeof(FormattedString), typeof(BorderedLabel), Label.FormattedTextProperty.DefaultValue);
    public static readonly BindableProperty HorizontalTextAlignmentProperty = BindableProperty.Create(nameof(HorizontalTextAlignment), typeof(TextAlignment), typeof(BorderedLabel), TextAlignment.Center);
    public static readonly BindableProperty LineBreakModeProperty = BindableProperty.Create(nameof(LineBreakMode), typeof(LineBreakMode), typeof(BorderedLabel), Label.LineBreakModeProperty.DefaultValue);
    public static readonly BindableProperty LineHeightProperty = BindableProperty.Create(nameof(LineHeight), typeof(double), typeof(BorderedLabel), Label.LineHeightProperty.DefaultValue);
    public static readonly BindableProperty MaxLinesProperty = BindableProperty.Create(nameof(MaxLines), typeof(int), typeof(BorderedLabel), Label.MaxLinesProperty.DefaultValue);
    public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(BorderedLabel), Label.TextProperty.DefaultValue);
    public static readonly BindableProperty TextDecorationsProperty = BindableProperty.Create(nameof(TextDecorations), typeof(TextDecorations), typeof(BorderedLabel), Label.TextDecorationsProperty.DefaultValue);
    public static readonly BindableProperty TextTransformProperty = BindableProperty.Create(nameof(TextTransform), typeof(TextTransform), typeof(BorderedLabel), Label.TextTransformProperty.DefaultValue);
    public static readonly BindableProperty TextTypeProperty = BindableProperty.Create(nameof(TextType), typeof(TextType), typeof(BorderedLabel), Label.TextTypeProperty.DefaultValue);
    public static readonly BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(BorderedLabel), Label.TextColorProperty.DefaultValue);
    public static readonly BindableProperty VerticalTextAlignmentProperty = BindableProperty.Create(nameof(VerticalTextAlignment), typeof(TextAlignment), typeof(BorderedLabel), TextAlignment.Center);
    #endregion

    #endregion

    #region Constructors
    public BorderedLabel()
    {
        InitializeComponent();
    }
    #endregion
}