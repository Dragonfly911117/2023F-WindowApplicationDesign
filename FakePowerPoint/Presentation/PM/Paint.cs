using System.Drawing;

namespace FakePowerPoint.Presentation.PM
{
    public partial class PresentationModel
    {
        Bitmap _bitmap;

        public void Repaint()
        {
            _model.Repaint();
            SlideBitmap = _model.GetCurrentSlideBitmap();
        }
    }
}
