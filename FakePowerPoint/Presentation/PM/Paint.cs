using System.Drawing;
using FakePowerPoint.Model.Enums;
using FakePowerPoint.Properties;

namespace FakePowerPoint.Presentation.PM
{
    public partial class PresentationModel
    {
        Bitmap _bitmap;
        ShapeType _shapeType = ShapeType.Undefined;

        public void Repaint()
        {
            _model.Repaint();
            SlideBitmap = _model.GetCurrentSlideBitmap();
        }

        public Size NormalizeSize(Size slidePanelSize)
        {
            const double ASPECT_RATIO = 16.0 / 9.0;
            slidePanelSize.Height = (int)(slidePanelSize.Width / ASPECT_RATIO);

            return slidePanelSize;
        }
    }
}
