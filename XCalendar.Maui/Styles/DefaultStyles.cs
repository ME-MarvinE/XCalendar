using XCalendar.Maui.Views;

namespace XCalendar.Maui.Styles
{
    public static class DefaultStyles
    {
        #region Properties
        public static Style DefaultDayViewCurrentMonthStyle { get; } = CreateDefaultDayViewCurrentMonthStyle();
        public static Style DefaultDayViewOtherMonthStyle { get; } = CreateDefaultDayViewOtherMonthStyle();
        public static Style DefaultDayViewTodayStyle { get; } = CreateDefaultDayViewTodayStyle();
        public static Style DefaultDayViewSelectedStyle { get; } = CreateDefaultDayViewSelectedStyle();
        public static Style DefaultDayViewInvalidStyle { get; } = CreateDefaultDayViewInvalidStyle();
        #endregion

        #region Methods
        public static Style CreateDefaultDayViewCurrentMonthStyle()
        {
            Style style = new Style(typeof(DayView)) { CanCascade = true };
            style.Setters.Add(new Setter() { Property = VisualElement.BackgroundColorProperty, Value = Colors.Transparent });
            style.Setters.Add(new Setter() { Property = DayView.TextColorProperty, Value = Colors.Black });
            style.Setters.Add(new Setter() { Property = VisualElement.HeightRequestProperty, Value = 45d });

            return style;
        }
        public static Style CreateDefaultDayViewOtherMonthStyle()
        {
            Style style = new Style(typeof(DayView)) { CanCascade = true };
            style.Setters.Add(new Setter() { Property = VisualElement.BackgroundColorProperty, Value = Colors.Transparent });
            style.Setters.Add(new Setter() { Property = DayView.TextColorProperty, Value = Color.FromArgb("#A0A0A0") });
            style.Setters.Add(new Setter() { Property = VisualElement.HeightRequestProperty, Value = 45d });

            return style;
        }
        public static Style CreateDefaultDayViewTodayStyle()
        {
            Style style = new Style(typeof(DayView)) { CanCascade = true };
            style.Setters.Add(new Setter() { Property = VisualElement.BackgroundColorProperty, Value = Colors.Transparent });
            style.Setters.Add(new Setter() { Property = DayView.TextColorProperty, Value = Colors.Black });
            style.Setters.Add(new Setter() { Property = VisualElement.HeightRequestProperty, Value = 45d });

            return style;
        }
        public static Style CreateDefaultDayViewSelectedStyle()
        {
            Style style = new Style(typeof(DayView)) { CanCascade = true };
            style.Setters.Add(new Setter() { Property = VisualElement.BackgroundColorProperty, Value = Color.FromArgb("#E00000") });
            style.Setters.Add(new Setter() { Property = DayView.TextColorProperty, Value = Colors.Black });
            style.Setters.Add(new Setter() { Property = VisualElement.HeightRequestProperty, Value = 45d });

            return style;
        }
        public static Style CreateDefaultDayViewInvalidStyle()
        {
            Style style = new Style(typeof(DayView)) { CanCascade = true };
            style.Setters.Add(new Setter() { Property = VisualElement.BackgroundColorProperty, Value = Colors.Transparent });
            style.Setters.Add(new Setter() { Property = DayView.TextColorProperty, Value = Color.FromArgb("#FFA0A0") });
            style.Setters.Add(new Setter() { Property = VisualElement.HeightRequestProperty, Value = 45d });

            return style;
        }
        #endregion
    }
}
