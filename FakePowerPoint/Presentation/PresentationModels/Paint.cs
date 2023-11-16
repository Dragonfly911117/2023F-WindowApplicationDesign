using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FakePowerPoint
{
    public partial class PresentationModel
    {
        // Iterates through each shape in the model and draws it.
        public void DrawEverything()
        {
            VerifyPaintGroup();

            foreach (var shape in _model.Shapes)
            {
                shape.Draw(Graphics.FromImage(_bitmap), PEN_WIDTH);
            }
            _tempShape?.Draw(Graphics.FromImage(_bitmap), PEN_WIDTH);
        }

        // Sets a paint group.
        public void SetPaintGroup(GroupBox paintGroup)
        {
            _paintGroup = paintGroup;
            _bitmap = new Bitmap(paintGroup.Width, paintGroup.Height);
            _paintGroup.BackgroundImage = _bitmap;
        }

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
                var endPosition = new List<int> { _cursorPos.X - PAINT_OFFSET_X, _cursorPos.Y - PAINT_OFFSET_Y };
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

            var endPosition = new List<int> { _cursorPos.X - PAINT_OFFSET_X, _cursorPos.Y - PAINT_OFFSET_Y };
            var shape = ShapeFactory.CreateShape(_shapeType, _startPoint, endPosition);
            _model.AddShape(shape);
            ResetShape();

            // Invalidate the current paint group to repaint the whole area
            // _paintGroup.Invalidate();
            this.DrawEverything();

            this.UpdateSelected();
        }

        // Resets the shape type, start point, and temporary shape.
        private void ResetShape()
        {
            _shapeType = ShapeType.Undefined;
            UpdateSelected();
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
        private Bitmap _bitmap;

        // Constants for Pen width and Paint offsets in x and y direction.
        private const int PEN_WIDTH = 5;
        private const int PAINT_OFFSET_X = 217;

        private const int PAINT_OFFSET_Y = 54;

        // Paint region size and position.
        private readonly Rectangle _paintRegion = new Rectangle(PAINT_OFFSET_X, PAINT_OFFSET_Y, 1358, 1052);
    }
}
