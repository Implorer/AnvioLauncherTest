using System.Windows;
using System.Windows.Threading;
using AnvioLauncherTest.Extensions;
using AnvioLauncherTest.Properties;

namespace AnvioLauncherTest
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Settings.Default.UpgradeIfRequired();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            Settings.Default.Save();
        }

        private void App_OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            Logger.LogError(e.Exception, "Unhandled exception");
            WidgetExtension.TerminateRelatedProcesses();
        }
    }
}
