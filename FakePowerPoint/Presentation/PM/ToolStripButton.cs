using System;
using System.Collections.Generic;
using FakePowerPoint.Model.Enums;

namespace FakePowerPoint.Presentation.PM
{
    public partial class PresentationModel
    {
        ObservableList<bool> _selected = new ObservableList<bool>();
        ObservableList<bool> _dos = new ObservableList<bool>();

        public ObservableList<bool> Dos => _dos;

        public ObservableList<bool> Selected => _selected;

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
                    if (EqualityComparer<T>.Default.Equals(base[index], value))
                        return;
                    base[index] = value;
                    // Trigger ItemUpdated event
                    ItemUpdated?.Invoke(index, value);
                }
            }
        }

        public void UpdateSelected(int index = 0)
        {
            // Iterates through the Selected list and unselects any selected item
            for (var i = 0; i < Selected.Count; i++)
            {
                ShowSelectedOrUpdate(i, false);
            }

            // ensures _shapeType has been defined before using it
            _shapeType = (ShapeType)index;

            // Select the item at the specific index
            ShowSelectedOrUpdate(index, true);
            UnselectShapes();
            Repaint();
        }

        void ShowSelectedOrUpdate(int index, bool value)
        {
            _selected[index] = value;
        }

        void InitializeSelectionShape()
        {
            var enumLength = Enum.GetValues(typeof(ShapeType)).Length;
            // Default mode
            Selected.Add(true);
            // Adds a false to the Selected List for every shape type except for the first one
            for (var i = 1; i < enumLength; i++)
            {
                Selected.Add(false);
            }
        }

        void InitializeDo()
        {
            _dos.Add(false);
            _dos.Add(false);
        }
    }
}
