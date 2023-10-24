using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FakePowerPoint
{
    public partial class PresentationModel
    {
        public void DrawRectangle(Color color, System.Drawing.Rectangle rectangle)
        {
            var myPen = new Pen(color, PEN_WIDTH);
            var graphics = _paintGroup.CreateGraphics();
            graphics.DrawRectangle(myPen, rectangle);
            myPen.Dispose();
            graphics.Dispose();
        }

        // brief: Draw a line on the paint region
        public void DrawLine(Color color, List<Tuple<int, int>> coordinates)
        {
            var myPen = new Pen(color, PEN_WIDTH);
            var graphics = _paintGroup.CreateGraphics();
            graphics.DrawLine(myPen, coordinates[0].Item1, coordinates[0].Item2, coordinates[1].Item1,
                coordinates[1].Item2);
            myPen.Dispose();
            graphics.Dispose();
        }

        public void DrawEverything()
        {
            if (_paintGroup == null)
                throw new Exception("Paint group is not set");

            foreach (var shape in _model.Shapes)
                shape.Draw(this);

            if (_tempShape != null)
                _tempShape.Draw(this);
        }

        // brief: set the paint group for the drawer
        public void SetPaintGroup(GroupBox paintGroup)
        {
            _paintGroup = paintGroup;
        }

        public void DrawEclipse(Color color, System.Drawing.Rectangle convertToRectangle)
        {
            var myPen = new Pen(color, PEN_WIDTH);
            var graphics = _paintGroup.CreateGraphics();
            graphics.DrawEllipse(myPen, convertToRectangle);
            myPen.Dispose();
            graphics.Dispose();
        }

        public void DrawLineButtonClicked()
        {
            if (_shapeType == ShapeType.Line)
            {
                _shapeType = ShapeType.Undefined;
                this.Cursor = Cursors.Default;
                this.UpdateSelected();
                return;
            }

            _shapeType = ShapeType.Line;
            this.UpdateSelected();
        }

        public void DrawRectButtonClicked()
        {
            if (_shapeType == ShapeType.Rectangle)
            {
                _shapeType = ShapeType.Undefined;
                this.Cursor = Cursors.Default;
                this.UpdateSelected();
                return;
            }

            _shapeType = ShapeType.Rectangle;
            this.UpdateSelected();
        }

        public void DrawEclipseButtonClicked()
        {
            if (_shapeType == ShapeType.Eclipse)
            {
                _shapeType = ShapeType.Undefined;
                this.Cursor = Cursors.Default;
                this.UpdateSelected();
                return;
            }

            _shapeType = ShapeType.Eclipse;
            this.UpdateSelected();
        }

        public void MouseDownOnPanel()
        {
            if (_shapeType != ShapeType.Undefined)
            {
                _startPoint = new List<int> { _cursorPos.X - PAINT_OFFSET_X, _cursorPos.Y - PAINT_OFFSET_Y };
                this.Cursor = Cursors.Cross;
            }
        }

        public void MouseMovingOnPanel()
        {
            if (_shapeType != ShapeType.Undefined)
            {
                this.Cursor = Cursors.Cross;
            }

            if (_startPoint != null)
            {
                var tempCoordinates = new List<int>
                {
                    _startPoint[0], _startPoint[1], _cursorPos.X - PAINT_OFFSET_X, _cursorPos.Y - PAINT_OFFSET_Y
                };
                _tempShape = ShapeFactory.CreateShape(_shapeType.ToString(), tempCoordinates);
                _paintGroup.Invalidate();
                // _tempShape.Draw(this);
            }
        }

        public void MouseUpOnPanel()
        {
            if (_startPoint == null || _shapeType == ShapeType.Undefined)
            {
                return;
            }

            var tempCoordinates = new List<int>
            {
                _startPoint[0], _startPoint[1], _cursorPos.X - PAINT_OFFSET_X, _cursorPos.Y - PAINT_OFFSET_Y
            };
            var shape = ShapeFactory.CreateShape(_shapeType.ToString(), tempCoordinates);
            _model.AddShape(shape);

            this.Cursor = Cursors.Default;
            _shapeType = ShapeType.Undefined;
            _startPoint = null;
            _tempShape = null;
            _paintGroup.Invalidate();
            this.UpdateSelected();
        }


        private List<int> _startPoint = null;
        private IShape _tempShape = null;
        private ShapeType _shapeType = ShapeType.Undefined;


        private GroupBox _paintGroup = null;
        private const string REMOVE = "Remove";
        private const int PEN_WIDTH = 5;

        private const int PAINT_OFFSET_X = 217;
        private const int PAINT_OFFSET_Y = 54;
        private Rectangle _paintRegion = new Rectangle(PAINT_OFFSET_X, PAINT_OFFSET_Y, 1358, 1052);
    }
}
