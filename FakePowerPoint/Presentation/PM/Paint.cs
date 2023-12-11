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

        public Size NormalizeSize(Size slidePanelSize)
        {
            var aspectRatio = 16.0 / 9.0;



            if (slidePanelSize.Width > (slidePanelSize.Height * aspectRatio))
            {
                slidePanelSize.Width = (int)(slidePanelSize.Height * aspectRatio);
            }
            else
            {
                slidePanelSize.Height = (int)(slidePanelSize.Width / aspectRatio);
            }

            return slidePanelSize;
        }
    }
}
