using System.Drawing;
using System.Windows.Forms;
using FakePowerPoint.Model.Commands;
using FakePowerPoint.Model.Enums;
using FakePowerPoint.Properties;

namespace FakePowerPoint.Presentation.PM
{
    public partial class PresentationModel
    {
        public void HandleMouseDown(Point point)
        {
            if (IfInSlidePanel(point))
            {
                if (IfInDrawingMode())
                {
                    var normalizedPoint = NormalizePoint(point);
                    DropPen(normalizedPoint);
                }
                else if (IfInSelectionMode())
                {
                    var normalizedPoint = NormalizePoint(point);
                    SelectShape(normalizedPoint);
                }
            }
            else
            {
                if (IfInDrawingMode())
                {
                    _coordinates = null;
                    _tempShape = null;
                    Repaint();
                }
            }
        }

        public void HandleMouseUp(Point point)
        {
            if (IfInSlidePanel(point))
            {
                if (IfInDrawingMode())
                {
                    var normalizedPoint = NormalizePoint(point);
                    PickUpThePen(normalizedPoint);
                }
            }
            else
            {
                if (IfInDrawingMode())
                {
                    _coordinates = null;
                    _tempShape = null;
                    Repaint();
                }
            }
        }

        public void HandleMouseMove(Point point)
        {
            Cursor = Cursors.Default;
            if (IfInSlidePanel(point))
            {
                if (IfInDrawingMode())
                {
                    Cursor = Cursors.Cross;
                    var normalizedPoint = NormalizePoint(point);
                    DrawShape(normalizedPoint);
                }
            }
            else
            {
                if (IfInDrawingMode())
                {
                    _coordinates = null;
                    _tempShape = null;
                    // Repaint();
                }
            }
        }

        bool IfInSelectionMode()
        {
            return _shapeType == ShapeType.Undefined;
        }

        public Point NormalizePoint(Point point)
        {
            point = new Point(point.X - _slidePanelRectangle.X, point.Y - _slidePanelRectangle.Y);
            var bitmapSize = new Size(int.Parse(Resources.DEFAULT_WINDOW_WIDTH),
                int.Parse(Resources.DEFAULT_WINDOW_HEIGHT));
            var ratio = (double)bitmapSize.Width / _slidePanelRectangle.Width;
            return new Point((int)(point.X * ratio), (int)(point.Y * ratio));
        }

        bool IfInSlidePanel(Point point)
        {
            return point.X >= _slidePanelRectangle.X &&
                   point.X <= _slidePanelRectangle.X + _slidePanelRectangle.Width &&
                   point.Y >= _slidePanelRectangle.Y && point.Y <= _slidePanelRectangle.Y + _slidePanelRectangle.Height;
        }

        bool IfInDrawingMode()
        {
            return _shapeType != ShapeType.Undefined;
        }
    }
}
