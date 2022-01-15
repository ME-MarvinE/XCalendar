using System.ComponentModel;
using PropertyChanged;

namespace XCalendar.Models
{
    [AddINotifyPropertyChangedInterface]
    /// <summary>
    /// A base class for Models that need to implement the INotifyPropertyChanged interface.
    /// </summary>
    public abstract class BaseObservableModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}