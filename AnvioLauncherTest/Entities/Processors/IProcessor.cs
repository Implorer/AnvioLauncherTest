namespace AnvioLauncherTest.Entities.Processors
{
    internal interface IProcessor
    {
        string ExecutablePath { get; set; }
        string OptionalParameter { get; set; }
    }
}
