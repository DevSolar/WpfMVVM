using System.Windows.Input;

namespace WpfMVVM.MVVM
{
    // Base class for commands relayed from the View to the ViewModel.
    // In the ViewModel class, "commands" can now be easily defined by:
    // public RelayCommand XXXCommand
    //      => new RelayCommand(execute => XXXFunction() [, canExecute => /* Precondition */]);
    internal class RelayCommand : ICommand
    {
        private Action<object?> execute;
        private Func<object?, bool>? canExecute;

        // Constructor
        public RelayCommand(Action<object?> execute, Func<object?, bool>? canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        // Funny boilerplate (no idea what this really does)
        event EventHandler? ICommand.CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        // CanExecute if no precondition is defined, or it is satisfied
        public bool CanExecute(object? parameter)
        {
            return canExecute == null || canExecute(parameter);
        }

        // Just wrapping the execute() function given the constructor
        public void Execute(object? parameter)
        {
            execute(parameter);
        }
    }
}
