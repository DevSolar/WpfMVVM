using System.Windows;
using WpfMVVM.ViewModel;

namespace WpfMVVM
{
    // This is the CodeBehind for the View's XAML. Ideally, there should
    // be very little to be done here.
    public partial class MainWindow : Window
    {
        // We initialize the GUI components, instantiate the ViewModel,
        // and set our DataContext to the ViewModel, thus delegating all
        // the data handling out of the View.
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}