using PropertyChanged;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace XCalendarFormsSample.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Methods
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
