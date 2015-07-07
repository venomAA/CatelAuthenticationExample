namespace OrchestraShell2
{
    using System.Windows;

    using Catel;
    using Catel.IoC;
    using Catel.MVVM;
    using Catel.Data;
    using Catel.Windows;
    using Catel.Services;
    using Orchestra.Services;
    using Orchestra;
    using Services;
    using Orchestra.Views;
    using ViewModels;
    using Views;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Application.Startup"/> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.StartupEventArgs"/> that contains the event data.</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            var serviceLocator = ServiceLocator.Default;
            serviceLocator.RegisterType<IMahAppsService, MahAppsService>();
            serviceLocator.RegisterType<IAuthenticationProvider, Authentication.AuthenticationProvider>();
            var shellService = serviceLocator.ResolveType<IShellService>();

            // Overide style of Catel please wait service
            serviceLocator.RegisterType<IPleaseWaitService, Orchestra.Services.PleaseWaitService>();
            shellService.CreateWithSplash<ShellWindow>();
        }
    }
}