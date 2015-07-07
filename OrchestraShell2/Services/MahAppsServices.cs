using Catel;
using Catel.MVVM;
using Catel.Services;
using global::MahApps.Metro.Controls;
using Orchestra.Models;
using Orchestra.Services;
using OrchestraShell2.Views;
using Orchestra;
using OrchestraShell2.ViewModels;
using System.Windows;
using Catel.IoC;
namespace OrchestraShell2.Services
{
    public class MahAppsService : IMahAppsService
    {
        #region Fields
        private readonly ICommandManager _commandManager;
        private readonly IMessageService _messageService;
        private readonly IUIVisualizerService _uiVisualizerService;
        private readonly IAuthenticationProvider _authenticationProvider;
        #endregion

        #region Constructors
        public MahAppsService(ICommandManager commandManager, IMessageService messageService, IUIVisualizerService uiVisualizerService, IAuthenticationProvider authenticationProvicer)
        {
            Argument.IsNotNull(() => commandManager);
            Argument.IsNotNull(() => messageService);
            Argument.IsNotNull(() => uiVisualizerService);

            _commandManager = commandManager;
            _messageService = messageService;
            _uiVisualizerService = uiVisualizerService;
            _authenticationProvider = authenticationProvicer;
        }
        #endregion

        #region IMahAppsService Members
        public WindowCommands GetRightWindowCommands()
        {
            var windowCommands = new WindowCommands();

            //var refreshButton = WindowCommandHelper.CreateWindowCommandButton("appbar_refresh_counterclockwise_down", "refresh");
            //refreshButton.Command = _commandManager.GetCommand("File.Refresh");
            //_commandManager.RegisterAction("File.Refresh", () => _messageService.Show("Refresh"));
            //windowCommands.Items.Add(refreshButton);

            //var saveButton = WindowCommandHelper.CreateWindowCommandButton("appbar_save", "save");
            //saveButton.Command = _commandManager.GetCommand("File.Save");
            //_commandManager.RegisterAction("File.Save", () => _messageService.Show("Save"));
            //windowCommands.Items.Add(saveButton);

            //var showWindowButton = WindowCommandHelper.CreateWindowCommandButton("appbar_new_window", "show window");
            //showWindowButton.Command = new Command(() => _uiVisualizerService.ShowDialog<ExampleDialogViewModel>());
            //windowCommands.Items.Add(showWindowButton);

            return windowCommands;
        }

        public FlyoutsControl GetFlyouts()
        {
            return null;
        }

        public FrameworkElement GetMainView()
        {
            //Mod to example. Workaround of "lack" of call of the proper constructor of the view model
            //Creates an instance with the proper constructor of the viewmodel that asks for the injection 
            //of the visualizer service and the authentication service. 
            var mainwindowViewModel = TypeFactory.Default.CreateInstanceWithParametersAndAutoCompletion<MainWindowViewModel>(_uiVisualizerService, _authenticationProvider);
            //Injects the viewmodel into the mainwindow.
            return new MainWindow(mainwindowViewModel);


            //Still need to proper understand why isnt the right constructor called when the custom services
            //are already registered on the default service locator. Why catel does not create the new instance of
            //the mainwindow with the registered services?
        }

        public AboutInfo GetAboutInfo()
        {
            return new AboutInfo();
        }
        #endregion
    }
}