namespace OrchestraShell2.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Catel.MVVM;
    using Catel.Data;
    using Catel.Services;
    using System.Collections.ObjectModel;
    using Catel;
    using OrchestraShell2.Authentication;
    using Catel.IoC;

    /// <summary>
    /// UserControl view model.
    /// </summary>
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly UIVisualizerService _uiVisualizerService;
        private readonly IAuthenticationProvider _authenticationProvider;
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        #region Constructor

        public MainWindowViewModel(UIVisualizerService uiVisualizerService, IAuthenticationProvider authenticationProvider)
        {
            Argument.IsNotNull(() => authenticationProvider);
            Argument.IsNotNull(() => uiVisualizerService);
            _uiVisualizerService = uiVisualizerService;
            _authenticationProvider = authenticationProvider;
            RoleCollection = new ObservableCollection<string>(new[] { "Read-Only", "Administrator" });
            ShowView = new Command(OnShowViewExecute, OnShowViewCanExecute, "ShowView");
        }

        #endregion

        #region Properties
        public override string Title { get { return "Authentication example"; } }

        public static readonly PropertyData RoleCollectionProperty = RegisterProperty("RoleCollection", typeof(ObservableCollection<string>), null);

        public ObservableCollection<string> RoleCollection
        {
            get { return GetValue<ObservableCollection<string>>(RoleCollectionProperty); }
            set { SetValue(RoleCollectionProperty, value); }
        }

        public  static readonly PropertyData SelectedRoleProperty = RegisterProperty("SelectedRole", typeof(string), null,
            (sender, e) => ((MainWindowViewModel)sender).OnSelectedRoleChanged());

        public string SelectedRole
        {
            get { return GetValue<string>(SelectedRoleProperty); }
            set { SetValue(SelectedRoleProperty, value); }
        }
        #endregion

        #region Methods

        private void OnSelectedRoleChanged()
        {
            ((AuthenticationProvider)_authenticationProvider).Role = SelectedRole;
        }
        #endregion

        #region Commands
        public Command ShowView { get; private set; }

        public bool OnShowViewCanExecute()
        {
            return !string.IsNullOrEmpty(SelectedRole);
        }

        public void OnShowViewExecute()
        {
            _uiVisualizerService.ShowDialog(new ExampleViewModel());
        }
        #endregion
    }
}
