using System;
using System.IO;
using System.Linq;
using AnvioLauncherTest.Entities.Widgets;
using AnvioLauncherTest.Properties;
using AnvioLauncherTest.UI;

namespace AnvioLauncherTest.Extensions
{
    internal static class WidgetExtension
    {
        internal static void SetProcessAndRun(this WidgetItem widget)
        {
            try
            {
                if (widget == null)
                    throw new ArgumentNullException(nameof(widget));

                if (widget.RelatedProcess != null)
                    throw new ArgumentException("The process is already running");

                if (!File.Exists(widget.FilePath))
                {
                    Logger.LogMessage($"Specified widget path is no longer exists.");
                    widget.RemoveWidgetFromCollection();
                    return;
                }

                var process = Settings.Default.CurrentProcessor.ProcessFile(widget.FilePath);

                if (process == null)
                {
                    Logger.LogMessage($"No process was assigned to {widget}");
                    return;
                }

                process.EnableRaisingEvents = true;
                process.Exited += (sender, args) =>
                {
                    widget.RelatedProcess = null;
                    Logger.LogMessage($"Process for {widget} was terminated");
                };

                widget.RelatedProcess = process;
                Logger.LogMessage($"New related process assigned for {widget}");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        internal static void KillRelatedProcess(this WidgetItem widget)
        {
            try
            {
                widget.RelatedProcess.Kill();
            }
            catch (InvalidOperationException ioe)
            {
                Logger.LogError(ioe, "The process has already exited");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        internal static void AddNewWidgetToCollection()
        {
            try
            {
                var filePath = FileSelectionDialog.GetFile();

                if (String.IsNullOrEmpty(filePath))
                {
                    Logger.LogMessage("Aborted: no file selected");
                    return;
                }

                if (!File.Exists(filePath))
                {
                    Logger.LogMessage("Aborted: file no longer exists");
                    return;
                }

                if (Settings.Default.WidgetItemCollection.Any(r => r.FilePath == filePath))
                {
                    Logger.LogMessage("Aborted: specified widget is alreday exists");
                }
                else
                {
                    var newItem = new WidgetItem(filePath);
                    Settings.Default.WidgetItemCollection.Add(newItem);
                    Logger.LogMessage($"Added new widget for {filePath}");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            
        }

        internal static void RemoveWidgetFromCollection(this WidgetItem widget)
        {
            try
            {
                Logger.LogMessage("Removing widget from collection...");
                Settings.Default.WidgetItemCollection.Remove(widget);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        internal static void TerminateRelatedProcesses()
        {
            Logger.LogMessage("Start killing related processes");
            foreach (var item in Properties.Settings.Default.WidgetItemCollection)
            {
                item.KillRelatedProcess();
            }
            Logger.LogMessage("All processes were terminated");
        }
    }
}

