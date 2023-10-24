using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace FakePowerPoint
{
    public partial class PresentationModel : INotifyPropertyChanged
    {
        // Use of automatic property syntax
        public event PropertyChangedEventHandler PropertyChanged;

        private Cursor _cursor = Cursors.Default;

        public Cursor Cursor
        {
            get => _cursor;
            set
            {
                if (_cursor != value)
                {
                    _cursor = value;
                    NotifyPropertyChanged(nameof(Cursor)); // use nameof instead of string literal
                }
            }
        }

        // brief: Constructor
        public ObservableList<bool> Selected { get; private set; } = new ObservableList<bool>();

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void UpdateSelected()
        {
            for (int i = 0; i < Selected.Count; i++)
            {
                ShowSelectedOrUpdate(i, false);
            }

            // run if _shapeType is not undefined
            var index = (int)_shapeType;
            if (index == 0) return;

            ShowSelectedOrUpdate(index-1, true);
        }

        private void ShowSelectedOrUpdate(int index, bool value)
        {
            Selected[index] = value;
        }

        public class ObservableList<T> : List<T>
        {
            // Use of automatic property syntax
            public event Action<int, T> ItemUpdated;

            public new T this[int index]
            {
                get => base[index];
                set
                {
                    if (!EqualityComparer<T>.Default.Equals(base[index], value))
                    {
                        base[index] = value;
                        ItemUpdated?.Invoke(index, value);
                    }
                }
            }
        }
    }
}
