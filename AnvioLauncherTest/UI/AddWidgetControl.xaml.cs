using System.IO;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using AnvioLauncherTest.Entities.Widgets;
using AnvioLauncherTest.Extensions;

namespace AnvioLauncherTest.UI
{
    public partial class AddWidgetControl : UserControl
    {
        public AddWidgetControl()
        {
            InitializeComponent();
        }

        private void Add_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            Logger.LogMessage($"Start adding new widget");
            WidgetExtension.AddNewWidgetToCollection();
        }
    }
}
