using PropertyChanged;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace XCalendarFormsSample.Models
{
    /// <summary>
    /// A base class for Models that need to implement the INotifyPropertyChanged interface.
    /// </summary>
    [AddINotifyPropertyChangedInterface]
    public abstract class BaseObservableModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}