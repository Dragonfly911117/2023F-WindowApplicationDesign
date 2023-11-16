using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace FakePowerPoint
{
    public partial class PresentationModel : INotifyPropertyChanged
    {
        // Defines an event to be triggered when property changed
        public event PropertyChangedEventHandler PropertyChanged;

        // Holds the current state of the cursor
        private Cursor _cursor = Cursors.Default;

        // Property for Cursor, handles Property Changed Event if value changed
        public Cursor Cursor
        {
            get => _cursor;
            set
            {
                // check if new assignment is not the same as old value
                if (_cursor != value)
                {
                    _cursor = value;
                    //trigger PropertyChanged event
                    NotifyPropertyChanged(nameof(Cursor));
                }
            }
        }

        // Observable list for selection states
        public ObservableList<bool> Selected { get; private set; } = new ObservableList<bool>();

        // Method to trigger property changed events
        private void NotifyPropertyChanged(string propertyName)
        {
            // Triggered when a property value has changed
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Method to update selected items
        private void UpdateSelected()
        {
            // Iterates through the Selected list and unselects any selected item
            for (int i = 0; i < Selected.Count; i++)
            {
                ShowSelectedOrUpdate(i, false);
            }

            // ensures _shapeType has been defined before using it
            var index = (int)_shapeType;

            // Select the item at the specific index
            ShowSelectedOrUpdate(index, true);
        }

        // Updates the selection state of the item at the specified index
        private void ShowSelectedOrUpdate(int index, bool value)
        {
            Selected[index] = value;
        }

        // Class that represents a list and handles item updated events
        public class ObservableList<T> : List<T>
        {
            // Defines an event to be triggered when an item is updated
            public event Action<int, T> ItemUpdated;

            // Overrides the indexer, handles ItemUpdated Event if value changed
            public new T this[int index]
            {
                get => base[index];
                set
                {
                    // check if new assignment is not the same as old value
                    if (!EqualityComparer<T>.Default.Equals(base[index], value))
                    {
                        base[index] = value;
                        // Trigger ItemUpdated event
                        ItemUpdated?.Invoke(index, value);
                    }
                }
            }
        }
        public void BindSlideBackground(Button button1)
        {
            _button = button1;
            _button.BackgroundImage = _bitmap;
            _button.Invalidate();
        }
    }
}
