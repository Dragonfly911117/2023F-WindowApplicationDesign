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
            using (var graphics = Graphics.FromImage(_bitmap))
            {
                graphics.Clear(_paintGroup.BackColor);
                foreach (var shape in _model.Shapes)
                {
                    shape.Draw(graphics, PEN_WIDTH);
                }

                _tempShape?.Draw(Graphics.FromImage(_bitmap), PEN_WIDTH);
            }

            _paintGroup.Invalidate();
            _button.Invalidate();
        }

        // Sets a paint group.

        public void SetPaintGroup(GroupBox paintGroup)
        {
            _paintGroup = paintGroup;
            _bitmap = new Bitmap(paintGroup.Width, paintGroup.Height);
            _paintGroup.DrawToBitmap(_bitmap, _paintGroup.ClientRectangle);
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
            else
            {
                if (_selectedIndex != -1)
                {
                    if (_model.Shapes[_selectedIndex]
                        .IsPointOnShape(Cursor.Position - new Size(PAINT_OFFSET_X, PAINT_OFFSET_Y)))
                    {
                        _dragging = true;
                        _startPoint = new List<int> { _cursorPos.X - PAINT_OFFSET_X, _cursorPos.Y - PAINT_OFFSET_Y };
                    }
                }

                bool flag = true;
                for (int i = 0; i < _model.Shapes.Count; i++)
                {
                    _model.Shapes[i].Selected = false;
                    if (_model.Shapes[i].IsPointOnShape(Cursor.Position - new Size(PAINT_OFFSET_X, PAINT_OFFSET_Y)) &&
                        flag)
                    {
                        _selectedIndex = i;
                        _model.Shapes[_selectedIndex].Selected = true;
                        flag = false;
                    }
                }

                DrawEverything();
            }
        }

        // Handles the mouse movement event on the panel.

        private void MouseMovingOnPanel()
        {
            if (_shapeType != ShapeType.Undefined)
            {
                Cursor = Cursors.Cross;
                if (_startPoint != null)
                {
                    var endPosition = new List<int> { _cursorPos.X - PAINT_OFFSET_X, _cursorPos.Y - PAINT_OFFSET_Y };
                    _tempShape = ShapeFactory.CreateShape(_shapeType, _startPoint, endPosition);
                    DrawEverything();
                }
            }
            else
            {
                if (_dragging)
                {
                    var delta = new Point(_cursorPos.X - PAINT_OFFSET_X - _startPoint[0],
                        _cursorPos.Y - PAINT_OFFSET_Y - _startPoint[1]);
                    List<int> tempCoordinate = new List<int>();
                    foreach (var coordinate in _model.Shapes[_selectedIndex].Coordinates)
                    {
                        tempCoordinate.Add(coordinate.X + delta.X);
                        tempCoordinate.Add(coordinate.Y + delta.Y);
                    }

                    _tempShape = ShapeFactory.CreateShape(_model.Shapes[_selectedIndex].ShapeType, tempCoordinate);
                    DrawEverything();
                }
            }
        }

        // Handles the mouse up event on the panel.

        private void MouseUpOnPanel()
        {
            if (_startPoint == null)
            {
                return;
            }

            var endPosition = new List<int> { _cursorPos.X - PAINT_OFFSET_X, _cursorPos.Y - PAINT_OFFSET_Y };
            if (_shapeType != ShapeType.Undefined)
            {
                var shape = ShapeFactory.CreateShape(_shapeType, _startPoint, endPosition);
                _model.AddShape(shape);
                ResetShape();
            }
            else
            {
                if (_dragging)
                {
                    _model.RemoveShape(_selectedIndex);
                    _model.AddShape(_tempShape);
                    _tempShape = null;
                    _dragging = false;
                    _selectedIndex = -1;
                }
            }

            // Invalidate the current paint group to repaint the whole area
            DrawEverything();

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

        private Button _button;


        // Constants for Pen width and Paint offsets in x and y direction.

        private const int PEN_WIDTH = 5;

        private const int PAINT_OFFSET_X = 217;

        private const int PAINT_OFFSET_Y = 54;

        // Paint region size and position.

        int _selectedIndex = -1;
        bool _dragging = false;
        private readonly Rectangle _paintRegion = new Rectangle(PAINT_OFFSET_X, PAINT_OFFSET_Y, 1358, 1052);
    }
}
