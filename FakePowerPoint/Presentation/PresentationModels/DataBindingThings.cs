using System.ComponentModel;
using System.Windows.Forms;

namespace FakePowerPoint
{
    public partial class PresentationModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Cursor Cursor
        {
            get => _cursor;
            set
            {
                _cursor = value;
                NotifyPropertyChanged("Cursor");
            }
        }

        private Cursor _cursor = Cursors.Default;

        // brief: Constructor
    }
}
