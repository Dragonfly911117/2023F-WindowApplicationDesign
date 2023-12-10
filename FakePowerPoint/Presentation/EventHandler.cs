using System;

namespace FakePowerPoint.Presentation
{
    public partial class Form1
    {
        void HandleAddShapeButtonClicked()
        {
            _presentationModel.AddShape(_shapeSelector.Text);
        }

        void HandleRepaint(object sender, EventArgs e)
        {
            // _presentationModel.Repaint(_graphics);
        }
    }
}
