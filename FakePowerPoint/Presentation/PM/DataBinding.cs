using System;
using System.Windows.Forms;
using FakePowerPoint.Model.Enums;

namespace FakePowerPoint.Presentation.PM
{
    public partial class PresentationModel
    {
        public void BindShapeSelectComboBox(ref ComboBox comboBox)
        {
             var temp = Enum.GetValues( typeof(ShapeType));
            for (var i = 1; i < temp.Length; i++)
            {
                comboBox.Items.Add(temp.GetValue(i));
            }
        }
        public void BindSlideBackgroundBitmap(ref Button button, ref Panel panel)
        {
            button.BackgroundImage = _bitmap;
            button.BackgroundImageLayout = ImageLayout.Stretch;
            panel.BackgroundImage = _bitmap;
            panel.BackgroundImageLayout = ImageLayout.Stretch;
        }
    }
}
