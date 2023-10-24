using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FakePowerPoint
{
    public partial class PresentationModel
    {
        // Draws a rectangle with a specified color and rectangle attributes.
        public void DrawRectangle(Color color, System.Drawing.Rectangle rectangle) =>
            DrawShape(color, (g, p) => g.DrawRectangle(p, rectangle));

        // Draws a line with a specified color and coordinates.
        public void DrawLine(Color color, List<Tuple<int, int>> coordinates) =>
            DrawShape(color, (g, p) =>
            {
                g.DrawLine(p, coordinates[0].Item1, coordinates[0].Item2, coordinates[1].Item1, coordinates[1].Item2);
            });

        // Draws an ellipse with a specified color and rectangle attributes.
        public void DrawEclipse(Color color, System.Drawing.Rectangle rectangle) =>
            DrawShape(color, (g, p) => g.DrawEllipse(p, rectangle));

        // Draws a shape with a specified color and draw action.
        private void DrawShape(Color color, Action<Graphics, Pen> drawAction)
        {
            using (var myPen = new Pen(color, PEN_WIDTH))
            using (var graphics = _paintGroup.CreateGraphics())
            {
                drawAction(graphics, myPen);
            }
        }

        // Iterates through each shape in the model and draws it.
        public void DrawEverything()
        {
            VerifyPaintGroup();

            foreach (var shape in _model.Shapes)
                shape.Draw(this);

            if (_tempShape != null)
                _tempShape.Draw(this);
        }

        // Sets a paint group.
        public void SetPaintGroup(GroupBox paintGroup) => _paintGroup = paintGroup;

        /* Manages the button clicked event for the shape:
         * if the shape type is already selected, the shape is reset;
         * otherwise, the shape type is updated, and selected shape is updated. */
        public void DrawShapeButtonClicked(ShapeType shapeType)
        {
            if (_shapeType == shapeType)
            {
                ResetShape();

                return;
            }

            _shapeType = shapeType;
            this.UpdateSelected();
        }

        // Handles the mouse down event on the panel.
        private void MouseDownOnPanel()
        {
            if (_shapeType != ShapeType.Undefined)
            {
                _startPoint = new List<int> { _cursorPos.X - PAINT_OFFSET_X, _cursorPos.Y - PAINT_OFFSET_Y };
                this.Cursor = Cursors.Cross;
            }
        }

        // Handles the mouse movement event on the panel.
        private void MouseMovingOnPanel()
        {
            if (_shapeType != ShapeType.Undefined)
            {
                this.Cursor = Cursors.Cross;
            }

            if (_startPoint != null)
            {
                var endPosition = new List<int> {_cursorPos.X - PAINT_OFFSET_X, _cursorPos.Y - PAINT_OFFSET_Y};
                _tempShape = ShapeFactory.CreateShape(_shapeType, _startPoint, endPosition);
                _paintGroup.Invalidate();
            }
        }

        // Handles the mouse up event on the panel.
        private void MouseUpOnPanel()
        {
            if (_startPoint == null || _shapeType == ShapeType.Undefined)
            {
                return;
            }

            var endPosition = new List<int> {_cursorPos.X - PAINT_OFFSET_X, _cursorPos.Y - PAINT_OFFSET_Y};
            var shape = ShapeFactory.CreateShape(_shapeType, _startPoint, endPosition);
            _model.AddShape(shape);
            ResetShape();

            // Invalidate the current paint group to repaint the whole area
            _paintGroup.Invalidate();

            this.UpdateSelected();
        }

        // Resets the shape type, start point, and temporary shape.
        private void ResetShape()
        {
            _shapeType = ShapeType.Undefined;
            _startPoint = null;
            _tempShape = null;
        }

        // Verifies that a paint group is set; if it's not, an exception is thrown.
        private void VerifyPaintGroup()
        {
            if (_paintGroup == null)
                throw new Exception("Paint group is not set");
        }

        // The variables and constants used in this class.
        private List<int> _startPoint;
        private IShape _tempShape;
        private ShapeType _shapeType;
        private GroupBox _paintGroup;

        // Constants for Pen width and Paint offsets in x and y direction.
        private const int PEN_WIDTH = 5;
        private const int PAINT_OFFSET_X = 217;
        private const int PAINT_OFFSET_Y = 54;
        // Paint region size and position.
        private readonly Rectangle _paintRegion = new Rectangle(PAINT_OFFSET_X, PAINT_OFFSET_Y, 1358, 1052);
    }
}
