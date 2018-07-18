using System.Collections.ObjectModel;
using System.Configuration;

namespace AnvioLauncherTest.Entities.Widgets
{
    [SettingsSerializeAs(SettingsSerializeAs.Xml)]
    public class WidgetItemCollection : ObservableCollection<WidgetItem>
    {
    }
}
