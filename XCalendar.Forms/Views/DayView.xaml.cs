using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XCalendar.Core.Enums;
using XCalendar.Forms.Styles;

namespace XCalendar.Forms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DayView : ContentView
    {
        #region Properties

        #region Bindable Properties
        public DateTime? DateTime
        {
            get { return (DateTime?)GetValue(DateTimeProperty); }
            set { SetValue(DateTimeProperty, value); }
        }
        public DayState DayState
        {
            get { return (DayState)GetValue(DayStateProperty); }
            set { SetValue(DayStateProperty, value); }
        }
        public bool IsCurrentMonth
        {
            get { return (bool)GetValue(IsCurrentMonthProperty); }
            set { SetValue(IsCurrentMonthProperty, value); }
        }
        public bool IsOtherMonth
        {
            get { return (bool)GetValue(IsOtherMonthProperty); }
            set { SetValue(IsOtherMonthProperty, value); }
        }
        public bool IsToday
        {
            get { return (bool)GetValue(IsTodayProperty); }
            set { SetValue(IsTodayProperty, value); }
        }
        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }
        public bool IsInvalid
        {
            get { return (bool)GetValue(IsInvalidProperty); }
            set { SetValue(IsInvalidProperty, value); }
        }
        public bool IsDayStateCurrentMonth
        {
            get { return (bool)GetValue(IsDayStateCurrentMonthProperty); }
            set { SetValue(IsDayStateCurrentMonthProperty, value); }
        }
        public bool IsDayStateOtherMonth
        {
            get { return (bool)GetValue(IsDayStateOtherMonthProperty); }
            set { SetValue(IsDayStateOtherMonthProperty, value); }
        }
        public bool IsDayStateToday
        {
            get { return (bool)GetValue(IsDayStateTodayProperty); }
            set { SetValue(IsDayStateTodayProperty, value); }
        }
        public bool IsDayStateSelected
        {
            get { return (bool)GetValue(IsDayStateSelectedProperty); }
            set { SetValue(IsDayStateSelectedProperty, value); }
        }
        public bool IsDayStateInvalid
        {
            get { return (bool)GetValue(IsDayStateInvalidProperty); }
            set { SetValue(IsDayStateInvalidProperty, value); }
        }
        public Style CurrentMonthStyle
        {
            get { return (Style)GetValue(CurrentMonthStyleProperty); }
            set { SetValue(CurrentMonthStyleProperty, value); }
        }
        public Style TodayStyle
        {
            get { return (Style)GetValue(TodayStyleProperty); }
            set { SetValue(TodayStyleProperty, value); }
        }
        public Style OtherMonthStyle
        {
            get { return (Style)GetValue(OtherMonthStyleProperty); }
            set { SetValue(OtherMonthStyleProperty, value); }
        }
        public Style InvalidStyle
        {
            get { return (Style)GetValue(InvalidStyleProperty); }
            set { SetValue(InvalidStyleProperty, value); }
        }
        public Style SelectedStyle
        {
            get { return (Style)GetValue(SelectedStyleProperty); }
            set { SetValue(SelectedStyleProperty, value); }
        }
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }
        public bool AutoSetStyleBasedOnDayState
        {
            get { return (bool)GetValue(AutoSetStyleBasedOnDayStateProperty); }
            set { SetValue(AutoSetStyleBasedOnDayStateProperty, value); }
        }
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
        [Xamarin.Forms.TypeConverter(typeof(FontSizeConverter))]
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
        public static readonly BindableProperty DateTimeProperty = BindableProperty.Create(nameof(DateTime), typeof(DateTime?), typeof(DayView), System.DateTime.Today, propertyChanged: DateTimePropertyChanged);
        public static readonly BindableProperty DayStateProperty = BindableProperty.Create(nameof(DayState), typeof(DayState), typeof(DayView), DayState.CurrentMonth, propertyChanged: DayStatePropertyChanged, coerceValue: CoerceDayState);
        public static readonly BindableProperty IsCurrentMonthProperty = BindableProperty.Create(nameof(IsCurrentMonth), typeof(bool), typeof(DayView), true, propertyChanged: IsCurrentMonthPropertyChanged);
        public static readonly BindableProperty IsOtherMonthProperty = BindableProperty.Create(nameof(IsOtherMonth), typeof(bool), typeof(DayView), propertyChanged: IsOtherMonthPropertyChanged);
        public static readonly BindableProperty IsTodayProperty = BindableProperty.Create(nameof(IsToday), typeof(bool), typeof(DayView), propertyChanged: IsTodayPropertyChanged);
        public static readonly BindableProperty IsSelectedProperty = BindableProperty.Create(nameof(IsSelected), typeof(bool), typeof(DayView), propertyChanged: IsSelectedPropertyChanged);
        public static readonly BindableProperty IsInvalidProperty = BindableProperty.Create(nameof(IsInvalid), typeof(bool), typeof(DayView), propertyChanged: IsInvalidPropertyChanged);
        public static readonly BindableProperty IsDayStateCurrentMonthProperty = BindableProperty.Create(nameof(IsDayStateCurrentMonth), typeof(bool), typeof(DayView));
        public static readonly BindableProperty IsDayStateOtherMonthProperty = BindableProperty.Create(nameof(IsDayStateOtherMonth), typeof(bool), typeof(DayView));
        public static readonly BindableProperty IsDayStateTodayProperty = BindableProperty.Create(nameof(IsDayStateToday), typeof(bool), typeof(DayView));
        public static readonly BindableProperty IsDayStateSelectedProperty = BindableProperty.Create(nameof(IsDayStateSelected), typeof(bool), typeof(DayView));
        public static readonly BindableProperty IsDayStateInvalidProperty = BindableProperty.Create(nameof(IsDayStateInvalid), typeof(bool), typeof(DayView));
        public static readonly BindableProperty CurrentMonthStyleProperty = BindableProperty.Create(nameof(CurrentMonthStyle), typeof(Style), typeof(DayView), propertyChanged: CurrentMonthStylePropertyChanged, defaultValueCreator: CreateDefaultDayViewCurrentMonthStyle);
        public static readonly BindableProperty OtherMonthStyleProperty = BindableProperty.Create(nameof(OtherMonthStyle), typeof(Style), typeof(DayView), propertyChanged: OtherMonthStylePropertyChanged, defaultValueCreator: CreateDefaultDayViewOtherMonthStyle);
        public static readonly BindableProperty TodayStyleProperty = BindableProperty.Create(nameof(TodayStyle), typeof(Style), typeof(DayView), propertyChanged: TodayStylePropertyChanged, defaultValueCreator: CreateDefaultDayViewTodayStyle);
        public static readonly BindableProperty SelectedStyleProperty = BindableProperty.Create(nameof(SelectedStyle), typeof(Style), typeof(DayView), propertyChanged: SelectedStylePropertyChanged, defaultValueCreator: CreateDefaultDayViewSelectedStyle);
        public static readonly BindableProperty InvalidStyleProperty = BindableProperty.Create(nameof(InvalidStyle), typeof(Style), typeof(DayView), propertyChanged: InvalidStylePropertyChanged, defaultValueCreator: CreateDefaultDayViewInvalidStyle);
        public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(DayView));
        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(DayView));
        public static readonly BindableProperty CharacterSpacingProperty = BindableProperty.Create(nameof(CharacterSpacing), typeof(double), typeof(DayView), Label.CharacterSpacingProperty.DefaultValue);
        public static readonly BindableProperty FontAttributesProperty = BindableProperty.Create(nameof(FontAttributes), typeof(FontAttributes), typeof(DayView), Label.FontAttributesProperty.DefaultValue);
        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(DayView), Label.FontFamilyProperty.DefaultValue);
        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(nameof(FontSize), typeof(double), typeof(DayView), Label.FontSizeProperty.DefaultValue);
        public static readonly BindableProperty FormattedTextProperty = BindableProperty.Create(nameof(FormattedText), typeof(FormattedString), typeof(DayView), Label.FormattedTextProperty.DefaultValue);
        public static readonly BindableProperty HorizontalTextAlignmentProperty = BindableProperty.Create(nameof(HorizontalTextAlignment), typeof(TextAlignment), typeof(DayView), TextAlignment.Center);
        public static readonly BindableProperty LineBreakModeProperty = BindableProperty.Create(nameof(LineBreakMode), typeof(LineBreakMode), typeof(DayView), Label.LineBreakModeProperty.DefaultValue);
        public static readonly BindableProperty LineHeightProperty = BindableProperty.Create(nameof(LineHeight), typeof(double), typeof(DayView), Label.LineHeightProperty.DefaultValue);
        public static readonly BindableProperty MaxLinesProperty = BindableProperty.Create(nameof(MaxLines), typeof(int), typeof(DayView), Label.MaxLinesProperty.DefaultValue);
        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(DayView), Label.TextProperty.DefaultValue);
        public static readonly BindableProperty TextDecorationsProperty = BindableProperty.Create(nameof(TextDecorations), typeof(TextDecorations), typeof(DayView), Label.TextDecorationsProperty.DefaultValue);
        public static readonly BindableProperty TextTransformProperty = BindableProperty.Create(nameof(TextTransform), typeof(TextTransform), typeof(DayView), Label.TextTransformProperty.DefaultValue);
        public static readonly BindableProperty TextTypeProperty = BindableProperty.Create(nameof(TextType), typeof(TextType), typeof(DayView), Label.TextTypeProperty.DefaultValue);
        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(DayView), Label.TextColorProperty.DefaultValue);
        public static readonly BindableProperty VerticalTextAlignmentProperty = BindableProperty.Create(nameof(VerticalTextAlignment), typeof(TextAlignment), typeof(DayView), TextAlignment.Center);
        public static readonly BindableProperty AutoSetStyleBasedOnDayStateProperty = BindableProperty.Create(nameof(AutoSetStyleBasedOnDayState), typeof(bool), typeof(DayView), true, propertyChanged: AutoSetStyleBasedOnDayStatePropertyChanged);
        #endregion

        #endregion

        #region Constructors
        public DayView()
        {
            SetBinding(TextProperty, new Binding(path: "DateTime.Day", source: this));

            InitializeComponent();
        }
        #endregion

        #region Methods
        public virtual DayState EvaluateDayState()
        {
            bool isOtherMonth = !IsCurrentMonth;

            if (IsInvalid)
            {
                return DayState.Invalid;
            }
            else if (IsSelected && IsCurrentMonth)
            {
                return DayState.Selected;
            }
            else if (IsToday && IsCurrentMonth)
            {
                return DayState.Today;
            }
            else if (isOtherMonth)
            {
                return DayState.OtherMonth;
            }
            else if (IsCurrentMonth)
            {
                return DayState.CurrentMonth;
            }
            else
            {
                throw new NotImplementedException();
            }
        }
        public virtual void UpdateView()
        {
            if (AutoSetStyleBasedOnDayState)
            {
                switch (DayState)
                {
                    case DayState.CurrentMonth:
                        Style = CurrentMonthStyle;
                        break;

                    case DayState.OtherMonth:
                        Style = OtherMonthStyle;
                        break;

                    case DayState.Today:
                        Style = TodayStyle;
                        break;

                    case DayState.Selected:
                        Style = SelectedStyle;
                        break;

                    case DayState.Invalid:
                        Style = InvalidStyle;
                        break;

                    default:
                        throw new NotImplementedException($"{nameof(DayState)} '{DayState}' is not implemented.");
                }
            }
        }

        #region Bindable Properties Methods
        private static object CreateDefaultDayViewCurrentMonthStyle(BindableObject bindable)
        {
            //Default value doesn't work so a DefaultValueCreator is used instead.
            return DefaultStyles.DefaultDayViewCurrentMonthStyle;
        }
        private static object CreateDefaultDayViewOtherMonthStyle(BindableObject bindable)
        {
            //Default value doesn't work so a DefaultValueCreator is used instead.
            return DefaultStyles.DefaultDayViewOtherMonthStyle;
        }
        private static object CreateDefaultDayViewTodayStyle(BindableObject bindable)
        {
            //Default value doesn't work so a DefaultValueCreator is used instead.
            return DefaultStyles.DefaultDayViewTodayStyle;
        }
        private static object CreateDefaultDayViewSelectedStyle(BindableObject bindable)
        {
            //Default value doesn't work so a DefaultValueCreator is used instead.
            return DefaultStyles.DefaultDayViewSelectedStyle;
        }
        private static object CreateDefaultDayViewInvalidStyle(BindableObject bindable)
        {
            //Default value doesn't work so a DefaultValueCreator is used instead.
            return DefaultStyles.DefaultDayViewInvalidStyle;
        }
        private static void DateTimePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            DayView control = (DayView)bindable;

            DayState evaluatedDayState = control.EvaluateDayState();

            if (control.DayState != evaluatedDayState)
            {
                control.DayState = evaluatedDayState;
            }
            else
            {
                control.UpdateView();
            }
        }
        private static void IsCurrentMonthPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            DayView control = (DayView)bindable;

            control.DayState = control.EvaluateDayState();
        }
        private static void IsOtherMonthPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            DayView control = (DayView)bindable;

            control.DayState = control.EvaluateDayState();
        }
        private static void IsTodayPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            DayView control = (DayView)bindable;

            control.DayState = control.EvaluateDayState();
        }
        private static void IsSelectedPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            DayView control = (DayView)bindable;

            control.DayState = control.EvaluateDayState();
        }
        private static void IsInvalidPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            DayView control = (DayView)bindable;

            control.DayState = control.EvaluateDayState();
        }
        private static void DayStatePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            DayView control = (DayView)bindable;
            DayState newDayState = (DayState)newValue;

            control.IsDayStateCurrentMonth = newDayState == DayState.CurrentMonth;
            control.IsDayStateOtherMonth = newDayState == DayState.OtherMonth;
            control.IsDayStateToday = newDayState == DayState.Today;
            control.IsDayStateSelected = newDayState == DayState.Selected;
            control.IsDayStateInvalid = newDayState == DayState.Invalid;

            control.UpdateView();
        }
        private static void CurrentMonthStylePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            DayView control = (DayView)bindable;

            control.UpdateView();
        }
        private static void OtherMonthStylePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            DayView control = (DayView)bindable;

            control.UpdateView();
        }
        private static void TodayStylePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            DayView control = (DayView)bindable;

            control.UpdateView();
        }
        private static void SelectedStylePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            DayView control = (DayView)bindable;
            Style newSelectedStyle = (Style)newValue;

            if (control.DayState == DayState.Selected)
            {
                control.Style = newSelectedStyle;
            }
        }
        private static void InvalidStylePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            DayView control = (DayView)bindable;

            control.UpdateView();
        }
        private static void AutoSetStyleBasedOnDayStatePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            DayView control = (DayView)bindable;
            bool newAutoSetStyleBasedOnDayState = (bool)newValue;

            if (newAutoSetStyleBasedOnDayState)
            {
                control.UpdateView();
            }
        }
        private static object CoerceDayState(BindableObject bindable, object value)
        {
            DayView control = (DayView)bindable;

            return control.EvaluateDayState();
        }
        #endregion

        #endregion
    }
}