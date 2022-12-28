using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XCalendar.Core.Enums;

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
        public Color CurrentMonthTextColor
        {
            get { return (Color)GetValue(CurrentMonthTextColorProperty); }
            set { SetValue(CurrentMonthTextColorProperty, value); }
        }
        public Color CurrentMonthBackgroundColor
        {
            get { return (Color)GetValue(CurrentMonthBackgroundColorProperty); }
            set { SetValue(CurrentMonthBackgroundColorProperty, value); }
        }
        public ICommand CurrentMonthCommand
        {
            get { return (ICommand)GetValue(CurrentMonthCommandProperty); }
            set { SetValue(CurrentMonthCommandProperty, value); }
        }
        public object CurrentMonthCommandParameter
        {
            get { return (object)GetValue(CurrentMonthCommandParameterProperty); }
            set { SetValue(CurrentMonthCommandParameterProperty, value); }
        }
        public Color TodayTextColor
        {
            get { return (Color)GetValue(TodayTextColorProperty); }
            set { SetValue(TodayTextColorProperty, value); }
        }
        public Color TodayBackgroundColor
        {
            get { return (Color)GetValue(TodayBackgroundColorProperty); }
            set { SetValue(TodayBackgroundColorProperty, value); }
        }
        public ICommand TodayCommand
        {
            get { return (ICommand)GetValue(TodayCommandProperty); }
            set { SetValue(TodayCommandProperty, value); }
        }
        public object TodayCommandParameter
        {
            get { return (object)GetValue(TodayCommandParameterProperty); }
            set { SetValue(TodayCommandParameterProperty, value); }
        }
        public Color OtherMonthTextColor
        {
            get { return (Color)GetValue(OtherMonthTextColorProperty); }
            set { SetValue(OtherMonthTextColorProperty, value); }
        }
        public Color OtherMonthBackgroundColor
        {
            get { return (Color)GetValue(OtherMonthBackgroundColorProperty); }
            set { SetValue(OtherMonthBackgroundColorProperty, value); }
        }
        public ICommand OtherMonthCommand
        {
            get { return (ICommand)GetValue(OtherMonthCommandProperty); }
            set { SetValue(OtherMonthCommandProperty, value); }
        }
        public object OtherMonthCommandParameter
        {
            get { return (object)GetValue(OtherMonthCommandParameterProperty); }
            set { SetValue(OtherMonthCommandParameterProperty, value); }
        }
        public Color InvalidTextColor
        {
            get { return (Color)GetValue(InvalidTextColorProperty); }
            set { SetValue(InvalidTextColorProperty, value); }
        }
        public Color InvalidBackgroundColor
        {
            get { return (Color)GetValue(InvalidBackgroundColorProperty); }
            set { SetValue(InvalidBackgroundColorProperty, value); }
        }
        public ICommand InvalidCommand
        {
            get { return (ICommand)GetValue(InvalidCommandProperty); }
            set { SetValue(InvalidCommandProperty, value); }
        }
        public object InvalidCommandParameter
        {
            get { return (object)GetValue(InvalidCommandParameterProperty); }
            set { SetValue(InvalidCommandParameterProperty, value); }
        }
        public Color SelectedTextColor
        {
            get { return (Color)GetValue(SelectedTextColorProperty); }
            set { SetValue(SelectedTextColorProperty, value); }
        }
        public Color SelectedBackgroundColor
        {
            get { return (Color)GetValue(SelectedBackgroundColorProperty); }
            set { SetValue(SelectedBackgroundColorProperty, value); }
        }
        public ICommand SelectedCommand
        {
            get { return (ICommand)GetValue(SelectedCommandProperty); }
            set { SetValue(SelectedCommandProperty, value); }
        }
        public object SelectedCommandParameter
        {
            get { return (object)GetValue(SelectedCommandParameterProperty); }
            set { SetValue(SelectedCommandParameterProperty, value); }
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
        public static readonly BindableProperty DayStateProperty = BindableProperty.Create(nameof(DayState), typeof(DayState), typeof(DayView), propertyChanged: DayStatePropertyChanged, coerceValue: CoerceDayState);
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
        public static readonly BindableProperty CurrentMonthTextColorProperty = BindableProperty.Create(nameof(CurrentMonthTextColor), typeof(Color), typeof(DayView), Color.Black, propertyChanged: StateAppearanceChanged);
        public static readonly BindableProperty CurrentMonthBackgroundColorProperty = BindableProperty.Create(nameof(CurrentMonthBackgroundColor), typeof(Color), typeof(DayView), Color.Transparent, propertyChanged: StateAppearanceChanged);
        public static readonly BindableProperty CurrentMonthCommandProperty = BindableProperty.Create(nameof(CurrentMonthCommand), typeof(ICommand), typeof(DayView), propertyChanged: StateAppearanceChanged);
        public static readonly BindableProperty CurrentMonthCommandParameterProperty = BindableProperty.Create(nameof(CurrentMonthCommandParameter), typeof(object), typeof(DayView), propertyChanged: StateAppearanceChanged);
        public static readonly BindableProperty TodayTextColorProperty = BindableProperty.Create(nameof(TodayTextColor), typeof(Color), typeof(DayView), Color.Black, propertyChanged: StateAppearanceChanged);
        public static readonly BindableProperty TodayBackgroundColorProperty = BindableProperty.Create(nameof(TodayBackgroundColor), typeof(Color), typeof(DayView), Color.Transparent, propertyChanged: StateAppearanceChanged);
        public static readonly BindableProperty TodayCommandProperty = BindableProperty.Create(nameof(TodayCommand), typeof(ICommand), typeof(DayView), propertyChanged: StateAppearanceChanged);
        public static readonly BindableProperty TodayCommandParameterProperty = BindableProperty.Create(nameof(TodayCommandParameter), typeof(object), typeof(DayView), propertyChanged: StateAppearanceChanged);
        public static readonly BindableProperty OtherMonthTextColorProperty = BindableProperty.Create(nameof(OtherMonthTextColor), typeof(Color), typeof(DayView), Color.FromHex("#A0A0A0"), propertyChanged: StateAppearanceChanged);
        public static readonly BindableProperty OtherMonthBackgroundColorProperty = BindableProperty.Create(nameof(OtherMonthBackgroundColor), typeof(Color), typeof(DayView), Color.Transparent, propertyChanged: StateAppearanceChanged);
        public static readonly BindableProperty OtherMonthCommandProperty = BindableProperty.Create(nameof(OtherMonthCommand), typeof(ICommand), typeof(DayView), propertyChanged: StateAppearanceChanged);
        public static readonly BindableProperty OtherMonthCommandParameterProperty = BindableProperty.Create(nameof(OtherMonthCommandParameter), typeof(object), typeof(DayView), propertyChanged: StateAppearanceChanged);
        public static readonly BindableProperty InvalidTextColorProperty = BindableProperty.Create(nameof(InvalidTextColor), typeof(Color), typeof(DayView), Color.FromHex("#FFA0A0"), propertyChanged: StateAppearanceChanged);
        public static readonly BindableProperty InvalidBackgroundColorProperty = BindableProperty.Create(nameof(InvalidBackgroundColor), typeof(Color), typeof(DayView), Color.Transparent, propertyChanged: StateAppearanceChanged);
        public static readonly BindableProperty InvalidCommandProperty = BindableProperty.Create(nameof(InvalidCommand), typeof(ICommand), typeof(DayView), propertyChanged: StateAppearanceChanged);
        public static readonly BindableProperty InvalidCommandParameterProperty = BindableProperty.Create(nameof(InvalidCommandParameter), typeof(object), typeof(DayView), propertyChanged: StateAppearanceChanged);
        public static readonly BindableProperty SelectedTextColorProperty = BindableProperty.Create(nameof(SelectedTextColor), typeof(Color), typeof(DayView), Color.White, propertyChanged: StateAppearanceChanged);
        public static readonly BindableProperty SelectedBackgroundColorProperty = BindableProperty.Create(nameof(SelectedBackgroundColor), typeof(Color), typeof(DayView), Color.FromHex("#E00000"), propertyChanged: StateAppearanceChanged);
        public static readonly BindableProperty SelectedCommandProperty = BindableProperty.Create(nameof(SelectedCommand), typeof(ICommand), typeof(DayView), propertyChanged: StateAppearanceChanged);
        public static readonly BindableProperty SelectedCommandParameterProperty = BindableProperty.Create(nameof(SelectedCommandParameter), typeof(object), typeof(DayView), propertyChanged: StateAppearanceChanged);
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
        #endregion

        #endregion

        #region Constructors
        public DayView()
        {
            SetBinding(TextProperty, new Binding(path: "DateTime.Day", source: this));
            DayState = DayState.CurrentMonth;

            InitializeComponent();
        }
        #endregion

        #region Methods
        public virtual DayState EvaluateDayState()
        {
            bool IsOtherMonth = !IsCurrentMonth;

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
            else if (IsOtherMonth)
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
            switch (DayState)
            {
                case DayState.CurrentMonth:
                    BackgroundColor = CurrentMonthBackgroundColor;
                    TextColor = CurrentMonthTextColor;
                    Command = CurrentMonthCommand;
                    CommandParameter = CurrentMonthCommandParameter;
                    break;

                case DayState.OtherMonth:
                    BackgroundColor = OtherMonthBackgroundColor;
                    TextColor = OtherMonthTextColor;
                    Command = OtherMonthCommand;
                    CommandParameter = OtherMonthCommandParameter;
                    break;

                case DayState.Today:
                    BackgroundColor = TodayBackgroundColor;
                    TextColor = TodayTextColor;
                    Command = TodayCommand;
                    CommandParameter = TodayCommandParameter;
                    break;

                case DayState.Selected:
                    BackgroundColor = SelectedBackgroundColor;
                    TextColor = SelectedTextColor;
                    Command = SelectedCommand;
                    CommandParameter = SelectedCommandParameter;
                    break;

                case DayState.Invalid:
                    BackgroundColor = InvalidBackgroundColor;
                    TextColor = InvalidTextColor;
                    Command = InvalidCommand;
                    CommandParameter = InvalidCommandParameter;

                    break;

                default:
                    throw new NotImplementedException($"{nameof(DayState)} '{DayState}' is not implemented.");
            }
        }

        #region Bindable Properties Methods
        private static void DateTimePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            DayView Control = (DayView)bindable;

            Control.DayState = Control.EvaluateDayState();
            Control.UpdateView();
        }
        private static void IsCurrentMonthPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            DayView Control = (DayView)bindable;

            Control.DayState = Control.EvaluateDayState();
            Control.UpdateView();
        }
        private static void IsOtherMonthPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            DayView Control = (DayView)bindable;

            Control.DayState = Control.EvaluateDayState();
            Control.UpdateView();
        }
        private static void IsTodayPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            DayView Control = (DayView)bindable;

            Control.DayState = Control.EvaluateDayState();
            Control.UpdateView();
        }
        private static void IsSelectedPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            DayView Control = (DayView)bindable;

            Control.DayState = Control.EvaluateDayState();
            Control.UpdateView();
        }
        private static void IsInvalidPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            DayView Control = (DayView)bindable;

            Control.DayState = Control.EvaluateDayState();
            Control.UpdateView();
        }
        private static void DayStatePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            DayView Control = (DayView)bindable;
            DayState NewDayState = (DayState)newValue;

            Control.IsDayStateCurrentMonth = NewDayState == DayState.CurrentMonth;
            Control.IsDayStateOtherMonth = NewDayState == DayState.OtherMonth;
            Control.IsDayStateToday = NewDayState == DayState.Today;
            Control.IsDayStateSelected = NewDayState == DayState.Selected;
            Control.IsDayStateInvalid = NewDayState == DayState.Invalid;
        }
        private static void StateAppearanceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            DayView Control = (DayView)bindable;

            Control.UpdateView();
        }
        private static object CoerceDayState (BindableObject bindable, object value)
        {
            DayView Control = (DayView)bindable;

            return Control.EvaluateDayState();
        }
        #endregion

        #endregion
    }
}