namespace AnvioLauncherTest.Properties
{
    public static class SettingsExtension
    {
        internal static void UpgradeIfRequired(this Settings settings)
        {
            if (!settings.IsUpgradeRequired)
                return;

            settings.Upgrade();
            settings.IsUpgradeRequired = false;
            settings.Save();
        }
    }
}
