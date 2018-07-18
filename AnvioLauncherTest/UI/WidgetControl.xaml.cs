using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using AnvioLauncherTest.Entities.Widgets;
using AnvioLauncherTest.Extensions;

namespace AnvioLauncherTest.UI
{
    /// <summary>
    /// Interaction logic for WidgetControl.xaml
    /// </summary>
    public partial class WidgetControl : UserControl
    {

        public WidgetControl()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty WidgetItemProperty = DependencyProperty.Register(nameof(WidgetItem),typeof(WidgetItem),typeof(WidgetControl));

        public WidgetItem WidgetItem
        {
            get { return (WidgetItem)GetValue(WidgetItemProperty); }
            set { SetValue(WidgetItemProperty, value); }
        }

        private void BtnOpenFile_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            Logger.LogMessage($"Running process for {WidgetItem}");
            WidgetItem.SetProcessAndRun();
        }

        private void BtnCloseFile_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            Logger.LogMessage($"Start process kill for {WidgetItem}");
            WidgetItem.KillRelatedProcess();
        }
    }
}
