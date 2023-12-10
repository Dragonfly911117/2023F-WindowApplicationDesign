using System.Drawing;

namespace FakePowerPoint.Presentation.PM;

public partial class PresentationModel
{
    Bitmap _bitmap;

    public void Repaint(out Bitmap bitmap)
    {
        _model.Repaint();
        bitmap = _bitmap = _model.GetCurrentSlideBitmap();
    }
}
