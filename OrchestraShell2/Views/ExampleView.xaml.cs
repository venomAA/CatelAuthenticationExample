namespace OrchestraShell2.Views
{
    using Catel.Windows;

    using ViewModels;

    /// <summary>
    /// Interaction logic for ExampleView.xaml.
    /// </summary>
    public partial class ExampleView : DataWindow
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExampleView"/> class.
        /// </summary>
        public ExampleView()
            : this(null) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExampleView"/> class.
        /// </summary>
        /// <param name="viewModel">The view model to inject.</param>
        /// <remarks>
        /// This constructor can be used to use view-model injection.
        /// </remarks>
        public ExampleView(ExampleViewModel viewModel)
            : base(viewModel)
        {
            InitializeComponent();
        }
    }
}
