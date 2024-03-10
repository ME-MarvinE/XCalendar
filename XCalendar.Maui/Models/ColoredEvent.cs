using XCalendar.Core.Models;

namespace XCalendar.Maui.Models
{
    public class ColoredEvent : Event
    {
        #region Fields
        private Color _color;
        #endregion

        #region Properties
        public Color Color
        {
            get
            {
                return _color;
            }
            set
            {
                if (_color != value)
                {
                    _color = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion
    }
}