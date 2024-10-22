using WpfMVVM.Model;
using WpfMVVM.MVVM;
using System.Collections.ObjectModel;

namespace WpfMVVM.ViewModel
{
    // This is the ViewModel, the glue between the View (handling the
    // representation) and the Model (handling the data). This is where
    // the functionality of the UI elements is defined and their events
    // are being handled.
    internal class MainWindowViewModel : ViewModelBase
    {
        // Using an ObservableCollection means the binding of the
        // View's DataGrid (through the View's DataContext) to
        // this collection will keep the data in the collection in
        // sync with what the UI displays.
        public ObservableCollection<Item> Items { get; set; }

        // Constructor, initializing an empty data container.
        // Alternatively, we could get a pre-filled container
        // from the Model, populated from e.g. a file or a
        // database.
        public MainWindowViewModel()
        {
            Items = new ObservableCollection<Item>();
        }

        // Each button in the UI has a command function attached
        // to it that gets executed when the button is pressed.
        // The optional precondition can disallow the function
        // from being called -- which, thanks to the data binding,
        // the UI will reflect by a greyed-out button.
        public RelayCommand AddCommand => new RelayCommand(execute => AddItem() /*, canExecute => { return true; }*/);
        public RelayCommand DeleteCommand => new RelayCommand(execute => DeleteItem(), canExecute => SelectedItem != null);
        public RelayCommand SaveCommand => new RelayCommand(execute => Save(), canExecute => CanSave());

        private void AddItem()
        {
            Items.Add(new Item());
        }

        private void DeleteItem()
        {
            // We can safely say that selectedItem cannot be null here,
            // because of the precondition of the RelayCommand. (If it
            // were null, CanExecute() would have been false and the
            // button greyed out.)
            Items.Remove(selectedItem!);
        }

        private void Save()
        {
            // save
        }

        private bool CanSave()
        {
            return true;
        }

        // Reference to the selected Item (if any).
        private Item? selectedItem;

        public Item? SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged(); // From ViewModelBase
            }
        }
    }
}
