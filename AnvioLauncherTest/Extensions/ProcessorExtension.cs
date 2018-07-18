using System;
using System.Diagnostics;
using AnvioLauncherTest.Entities.Processors;

namespace AnvioLauncherTest.Extensions
{
    public static class ProcessorExtension
    {
        public static Process ProcessFile(this Processor processor, string filePath)
        {
            try
            {
                if (processor == null)
                    throw new ArgumentNullException(nameof(processor));

                if (string.IsNullOrEmpty(filePath))
                    throw new ArgumentNullException(nameof(processor));

                var args = processor.GetArguments.Replace(Properties.Settings.Default.FileNameParameter, filePath);
                var process = Process.Start(processor.ExecutablePath, args);

                return process;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return null;
            }
            
        }

    }
}
