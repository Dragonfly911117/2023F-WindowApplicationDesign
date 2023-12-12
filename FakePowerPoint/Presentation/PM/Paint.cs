using System.Drawing;
using FakePowerPoint.Properties;

namespace FakePowerPoint.Presentation.PM
{
    public partial class PresentationModel
    {
        Bitmap _bitmap;
        Size _size = new (int.Parse(Resources.DEFAULT_SLIDE_WIDTH), int.Parse(Resources.DEFAULT_SLIDE_HEIGHT));

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
