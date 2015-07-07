namespace OrchestraShell2.Views
{
    using Catel.Windows.Controls;
    using ViewModels;
    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// Mod. to example. Workaround of "lack" of call of the proper constructor of the view model
        /// Modified for explict injection of the view model, its a part of the workaround
        /// </summary>
        public MainWindow(MainWindowViewModel _mainwindowviewmodel):base(_mainwindowviewmodel)
        {
            InitializeComponent();
        }
    }
}
