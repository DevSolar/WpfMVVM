using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfMVVM.MVVM
{
    // Base class for ViewModel classes, giving each of them the
    // PropertyChanged EventHandler necessary to sync with the View.
    internal class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
