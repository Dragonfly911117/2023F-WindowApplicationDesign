using System;
using System.Drawing;

namespace FakePowerPoint.Presentation
{
    public partial class Form1
    {
        void BindEventHandlers()
        {
            _addShapeButton.Click += HandleAddShapeButtonClicked;
            Paint += HandleRepaint;
        }

        void HandleAddShapeButtonClicked(object sender, EventArgs e)
        {
            _presentationModel.AddShape(_shapeSelector.Text);
        }

        void HandleRepaint(object sender, EventArgs e)
        {
            _presentationModel.Repaint(out var bitmap);
            _slidePanel.BackgroundImage = bitmap;
        }
    }
}
