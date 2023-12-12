using System.Drawing;
using FakePowerPoint.Properties;

namespace FakePowerPoint.Presentation.PM
{
    public partial class PresentationModel
    {
        Size _slidePanelSize = new (int.Parse(Resources.DEFAULT_SLIDE_WIDTH), int.Parse(Resources.DEFAULT_SLIDE_HEIGHT));
        public void HandleMouseDown(Point point)
        {
            point = NormalizePoint(point);

        }

        public void HandleMouseUp(Point point)
        {

        }

        public void HandleMouseMove(Point point)
        {

        }

        public Point NormalizePoint(Point point)
        {
            var BitmapSize = new Size(int.Parse(Resources.DEFAULT_WINDOW_WIDTH), int.Parse(Resources.DEFAULT_WINDOW_HEIGHT));
            var ratio = (double)BitmapSize.Width / _slidePanelSize.Width;
            return new Point((int)(point.X / ratio), (int)(point.Y / ratio));
        }
    }
}
