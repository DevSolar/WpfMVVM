using WpfMVVM.Model;
using WpfMVVM.MVVM;
using System.Collections.ObjectModel;

namespace WpfMVVM.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {
        // ObservableCollection() means changes are automatically
        // notified to the GUI
        public ObservableCollection<Item> Items { get; set; }

        public RelayCommand AddCommand => new RelayCommand(execute => AddItem() /*, canExecute => { return true; }*/);
        public RelayCommand DeleteCommand => new RelayCommand(execute => DeleteItem(), canExecute => SelectedItem != null);
        public RelayCommand SaveCommand => new RelayCommand(execute => Save(), canExecute => CanSave());

        public MainWindowViewModel()
        {
            Items = new ObservableCollection<Item>();
        }

        private Item selectedItem;

        public Item SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged(); // From ViewModelBase
            }
        }

        private void AddItem()
        {
            Items.Add(new Item
            {
                Name = "NEW ITEM",
                SerialNumber = "XXXXX",
                Quantity = 0
            });
        }

        private void DeleteItem()
        {
            Items.Remove(selectedItem);
        }

        private void Save()
        {
            // save
        }

        private bool CanSave()
        {
            return true;
        }
    }
}
