using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using AnvioLauncherTest.Annotations;

namespace AnvioLauncherTest.Entities.Widgets
{    
    public class WidgetItem : INotifyPropertyChanged
    {
        public WidgetItem()
        {
        }

        public WidgetItem(string filePath)
        {
            this.FilePath = filePath;
        }

        private string _filePath;
        public string FilePath
        {
            get { return _filePath; }
            set
            {
                _filePath = value;
                OnPropertyChanged(nameof(FilePath));
                OnPropertyChanged(nameof(FileName));
            }
        }

        public string FileName => Path.GetFileName(FilePath);


        private Process _relatedProcess;
        [XmlIgnore]
        public Process RelatedProcess {
            get { return _relatedProcess; }
            set
            {
                _relatedProcess = value;
                OnPropertyChanged();
            } }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return FilePath;
        }
    }
}
