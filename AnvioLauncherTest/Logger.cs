using System;
using System.Diagnostics;
using System.IO;

namespace AnvioLauncherTest
{
    internal static class Logger
    {
        private static readonly object Lock = new object();

        private static readonly DateTime InitDateTime = DateTime.UtcNow;

        private static string GetLogFileName => InitDateTime.ToString("yyyy-MM-dd_HH-mm-ss-FFFF");

        public static void LogMessage(string msg)
        {
            var logFilePath = Path.Combine(Path.GetTempPath(), GetLogFileName + ".txt");            

            lock (Lock)
            {
                using (var sw = File.AppendText(logFilePath))
                {
                    string logLine = $"{DateTime.UtcNow:G}: {msg}";
                    sw.WriteLine(logLine);
                }
            }
        }

        public static void LogError(Exception exception, string additionalInfo = "")
        {
            var frame = new StackFrame(1);
            var method = frame.GetMethod();
            var typeName = method?.DeclaringType?.Name ?? string.Empty;
            var methodName = method?.Name ?? string.Empty;

            var msgInfo = !string.IsNullOrEmpty(additionalInfo)
                ? $"{additionalInfo}\r\n{exception.StackTrace}"
                : $"{exception.StackTrace}";

            var message = $"Source: {typeName}.{methodName}; Descrioption: {exception.GetType()}({exception.Message}); Message: {msgInfo}";

            LogMessage(message);
        }
    }

}
