using System.ComponentModel;
using System.Windows;
using AnvioLauncherTest.Extensions;

namespace AnvioLauncherTest.UI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();            
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            Logger.LogMessage("Program closing");
            WidgetExtension.TerminateRelatedProcesses();
        }
    }
}
