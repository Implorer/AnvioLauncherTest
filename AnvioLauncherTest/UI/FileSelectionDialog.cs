using System.IO;

namespace AnvioLauncherTest.UI
{
    internal static class FileSelectionDialog
    {
        internal static string GetFile()
        {
            var dialog = new System.Windows.Forms.OpenFileDialog
            {
                Filter = @"Txt files|*.txt",
                Multiselect = false,
                InitialDirectory = Properties.Settings.Default.InitialFileSelectionDialogDirectory ?? string.Empty
            };

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Properties.Settings.Default.InitialFileSelectionDialogDirectory = Path.GetDirectoryName(dialog.FileName);
                return dialog.FileName;
            }

            return null;
        }
    }
}
