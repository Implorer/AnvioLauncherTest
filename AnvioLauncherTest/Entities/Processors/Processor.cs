using System;

namespace AnvioLauncherTest.Entities.Processors
{
    public class Processor : IProcessor
    {
        public Processor()
        {
        }

        public Processor(string executablePath, string optionalParameter)
        {
            this.ExecutablePath = executablePath;
            this.OptionalParameter = optionalParameter;
        }

        public string ExecutablePath { get; set; }
        public string OptionalParameter { get; set; }

        public string GetArguments => $"{OptionalParameter ?? string.Empty} {Properties.Settings.Default.FileNameParameter}";
    }
}
