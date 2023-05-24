using XCalendar.Maui.Views;

namespace XCalendar.Maui.Styles
{
    public static class DefaultStyles
    {
        #region Properties
        public static Style DefaultDayViewStyle { get; }
        public static Style DefaultDayViewCurrentMonthStyle { get; }
        public static Style DefaultDayViewOtherMonthStyle { get; }
        public static Style DefaultDayViewTodayStyle { get; }
        public static Style DefaultDayViewSelectedStyle { get; }
        public static Style DefaultDayViewInvalidStyle { get; }
        #endregion

        #region Constructors
        static DefaultStyles()
        {
            DefaultDayViewStyle = CreateDefaultDayViewStyle();
            DefaultDayViewCurrentMonthStyle = CreateDefaultDayViewCurrentMonthStyle();
            DefaultDayViewOtherMonthStyle = CreateDefaultDayViewOtherMonthStyle();
            DefaultDayViewTodayStyle = CreateDefaultDayViewTodayStyle();
            DefaultDayViewSelectedStyle = CreateDefaultDayViewSelectedStyle();
            DefaultDayViewInvalidStyle = CreateDefaultDayViewInvalidStyle();
        }
        #endregion

        #region Methods
        public static Style CreateDefaultDayViewStyle()
        {
            Style style = new Style(typeof(DayView)) { CanCascade = true };
            style.Setters.Add(new Setter() { Property = VisualElement.HeightRequestProperty, Value = 45d });

            return style;
        }
        public static Style CreateDefaultDayViewCurrentMonthStyle()
        {
            Style style = new Style(typeof(DayView)) { CanCascade = true, BasedOn = DefaultDayViewStyle };
            style.Setters.Add(new Setter() { Property = VisualElement.BackgroundColorProperty, Value = Colors.Transparent });
            style.Setters.Add(new Setter() { Property = DayView.TextColorProperty, Value = Colors.Black });

            return style;
        }
        public static Style CreateDefaultDayViewOtherMonthStyle()
        {
            Style style = new Style(typeof(DayView)) { CanCascade = true, BasedOn = DefaultDayViewStyle };
            style.Setters.Add(new Setter() { Property = VisualElement.BackgroundColorProperty, Value = Colors.Transparent });
            style.Setters.Add(new Setter() { Property = DayView.TextColorProperty, Value = Color.FromArgb("#A0A0A0") });

            return style;
        }
        public static Style CreateDefaultDayViewTodayStyle()
        {
            Style style = new Style(typeof(DayView)) { CanCascade = true, BasedOn = DefaultDayViewStyle };
            style.Setters.Add(new Setter() { Property = VisualElement.BackgroundColorProperty, Value = Colors.Transparent });
            style.Setters.Add(new Setter() { Property = DayView.TextColorProperty, Value = Color.FromArgb("#E00000") });

            return style;
        }
        public static Style CreateDefaultDayViewSelectedStyle()
        {
            Style style = new Style(typeof(DayView)) { CanCascade = true, BasedOn = DefaultDayViewStyle };
            style.Setters.Add(new Setter() { Property = VisualElement.BackgroundColorProperty, Value = Color.FromArgb("#E00000") });
            style.Setters.Add(new Setter() { Property = DayView.TextColorProperty, Value = Colors.White });

            return style;
        }
        public static Style CreateDefaultDayViewInvalidStyle()
        {
            Style style = new Style(typeof(DayView)) { CanCascade = true, BasedOn = DefaultDayViewStyle };
            style.Setters.Add(new Setter() { Property = VisualElement.BackgroundColorProperty, Value = Colors.Transparent });
            style.Setters.Add(new Setter() { Property = DayView.TextColorProperty, Value = Color.FromArgb("#FFA0A0") });

            return style;
        }
        #endregion
    }
}
