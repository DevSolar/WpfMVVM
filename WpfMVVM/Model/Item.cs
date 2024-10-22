namespace WpfMVVM.Model
{
    // The Model is the backend of the code, the actual data
    // and its business logic worked upon under control of the
    // GUI. In this case, one of the Items that can be created,
    // modified, or deleted in the GUI dialog. The Model could
    // then forward these actions to a file, or a database for
    // example.
    // The default values are automatically given to any new
    // Item created (like in MainWindowViewModel.AddItem()).
    internal class Item
    {
        public string Name { get; set; } = "NEW ITEM";
        public string SerialNumber { get; set; } = "XXXX";
        public int Quantity { get; set; } = 0;
    }
}
