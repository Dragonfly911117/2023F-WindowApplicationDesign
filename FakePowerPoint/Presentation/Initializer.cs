using System.Windows.Forms;

namespace FakePowerPoint.Presentation
{
    public partial class Form1 : Form
    {
        void BindThings()
        {
            _presentationModel.BindShapeSelectComboBox(ref _shapeSelector);
        }
    }
}
