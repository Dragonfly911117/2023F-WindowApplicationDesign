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
    }
}
