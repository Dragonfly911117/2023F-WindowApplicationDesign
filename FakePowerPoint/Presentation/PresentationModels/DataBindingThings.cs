using System;
using System.Collections.Generic;
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
        public ObservableList<bool> Selected { get; set; } = new ObservableList<bool>();

        private void UpdateSelected()
        {
            for (int i = 0; i < Selected.Count; i++)
            {
                Selected[i] = false;
            }

            // run if _shapeType is not undefined
            var index = (int)_shapeType;
            if (index == 0) return;
            Selected[index-1] = true;
        }

        public class ObservableList<T> : List<T>
        {
            public event Action<int, T> ItemUpdated;

            public new T this[int index]
            {
                get => base[index];
                set
                {
                    base[index] = value;
                    ItemUpdated?.Invoke(index, value);
                }
            }
        }
    }
}
