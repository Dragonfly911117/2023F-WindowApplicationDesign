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
                var normalizedPoint = NormalizePoint(point);
                if (IfInDrawingMode())
                {
                    DropPen(normalizedPoint);
                }
                else if (IfInSelectionMode())
                {
                    if (_selectedShapeIndex == -1)
                    {
                        SelectShape(normalizedPoint);
                    }
                    else
                    {
                        OperateShape(normalizedPoint);
                    }
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
                var normalizedPoint = NormalizePoint(point);
                if (IfInDrawingMode())
                {
                    PickUpThePen(normalizedPoint);
                }
                else if (IfInSelectionMode())
                {
                    if (_selectedShapeIndex != -1)
                    {
                        if (_coordinates != null)
                        {
                            OperateShape(normalizedPoint, true);
                            _model.Repaint();
                        }
                    }
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
                var normalizedPoint = NormalizePoint(point);
                if (IfInDrawingMode())
                {
                    Cursor = Cursors.Cross;
                    DrawShape(normalizedPoint);
                }
                else if (IfInSelectionMode())
                {
                    if (_selectedShapeIndex != -1)
                    {
                        var temp = _model.GetShapes()[_selectedShapeIndex].IfHandleClicked(normalizedPoint);
                        if (temp != HandlePosition.Undefined)
                        {
                            Cursor = temp switch
                            {
                                HandlePosition.BottomLeft => Cursors.SizeNESW,
                                HandlePosition.BottomRight => Cursors.SizeNWSE,
                                HandlePosition.TopRight => Cursors.SizeNESW,
                                HandlePosition.TopLeft => Cursors.SizeNWSE,
                                HandlePosition.BottomMiddle => Cursors.SizeNS,
                                HandlePosition.TopMiddle => Cursors.SizeNS,
                                HandlePosition.MiddleLeft => Cursors.SizeWE,
                                HandlePosition.MiddleRight => Cursors.SizeWE,
                                _ => Cursor
                            };
                        }
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
        }

        bool IfInSelectionMode()
        {
            return _shapeType == ShapeType.Undefined;
        }

        Point NormalizePoint(Point point)
        {
            point = new Point(point.X - _slidePanelRectangle.X, point.Y - _slidePanelRectangle.Y);
            var bitmapSize = _model.GetCurrentSlideBitmap().Size;
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
