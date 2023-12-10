using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using FakePowerPoint.Model.Enums;

namespace FakePowerPoint.Presentation.PM
{
    public partial class PresentationModel : INotifyPropertyChanged
    {
        public Bitmap SlideBitmap
        {
            get => _bitmap;
            set
            {
                _bitmap = value;
                OnPropertyChanged();
            }
        }

        public void BindShapeSelectComboBox(ref ComboBox comboBox)
        {
            var temp = Enum.GetValues(typeof(ShapeType));
            for (var i = 1; i < temp.Length; i++)
            {
                comboBox.Items.Add(temp.GetValue(i));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
