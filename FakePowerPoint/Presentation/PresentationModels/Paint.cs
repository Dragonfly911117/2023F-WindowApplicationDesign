using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FakePowerPoint
{
    public partial class PresentationModel
    {
        private List<int> _startPoint;
        private IShape _tempShape;
        private ShapeType _shapeType;
        private GroupBox _paintGroup;
        private Bitmap _bitmap;
        private Button _button;
        private int _selectedIndex = -1;
        private bool _dragging = false;

        private readonly Rectangle _paintRegion =
            new Rectangle(PAINT_OFFSET_X, PAINT_OFFSET_Y, CANVAS_WIDTH, CANVAS_HEIGHT);

        private const int PEN_WIDTH = 5;
        private const int PAINT_OFFSET_X = 217;
        private const int PAINT_OFFSET_Y = 54;
        private const int CANVAS_WIDTH = 1358;
        private const int CANVAS_HEIGHT = 1052;

        // Draws all shapes and temporary shape on the paint group
        public void DrawEverything()
        {
            VerifyPaintGroup();
            var graphics = CreateGraphicsFromBitmap();

            _tempShape?.Draw(graphics, PEN_WIDTH);
            DrawShapesOnGraphics(graphics);

            InvalidateControls();
        }

        // Creates a graphics object from the bitmap
        private Graphics CreateGraphicsFromBitmap()
        {
            var graphics = Graphics.FromImage(_bitmap);
            graphics.Clear(_paintGroup.BackColor);
            return graphics;
        }

        // Draws shapes on the provided graphics object
        private void DrawShapesOnGraphics(Graphics graphics)
        {
            foreach (var shape in _model.Shapes.Reverse())
            {
                shape?.Draw(graphics, PEN_WIDTH);
            }
        }

        // Invalidates the paint group and button to trigger redraw
        private void InvalidateControls()
        {
            _paintGroup.Invalidate();
            _button.Invalidate();
        }

        // Sets the paint group and creates a bitmap for it
        public void SetPaintGroup(GroupBox paintGroup)
        {
            _paintGroup = paintGroup;
            CreateBitmapForPaintGroup();
        }

        // Creates a bitmap for the paint group
        private void CreateBitmapForPaintGroup()
        {
            _bitmap = new Bitmap(_paintGroup.Width, _paintGroup.Height);
            _paintGroup.DrawToBitmap(_bitmap, _paintGroup.ClientRectangle);
            _paintGroup.BackgroundImage = _bitmap;
        }

        // Handles the button click for drawing shapes
        public void DrawShapeButtonClicked(ShapeType shapeType)
        {
            HandleShapeButtonClick(shapeType);
        }

        // Handles the logic for the shape button click
        private void HandleShapeButtonClick(ShapeType shapeType)
        {
            if (_shapeType == shapeType)
            {
                ResetShape();
            }
            else
            {
                UpdateShapeTypeAndSelection(shapeType);
            }
        }

        // Updates the selected shapeType
        private void UpdateShapeTypeAndSelection(ShapeType shapeType)
        {
            _shapeType = shapeType;
            UpdateSelected();
        }

        // Handles the mouse down event on the panel
        private void MouseDownOnPanel()
        {
            if (_shapeType != ShapeType.Selection)
            {
                StartDrawingShape();
            }
            else
            {
                StartDraggingShape();
            }

            DrawEverything();
        }

        // Starts drawing a new shape
        private void StartDrawingShape()
        {
            _startPoint = new List<int> { _cursorPos.X - PAINT_OFFSET_X, _cursorPos.Y - PAINT_OFFSET_Y };
            Cursor = Cursors.Cross;
        }

        // Handles mouse movement on the panel
        private void MouseMovingOnPanel()
        {
            if (_shapeType != ShapeType.Selection)
            {
                HandlePotentialShapeDrawing();
            }
            else
            {
                HandleShapeDragging();
            }
        }

        // Handles mouse up event on the panel
        private void MouseUpOnPanel()
        {
            if (_startPoint == null) return;

            if (_shapeType != ShapeType.Selection)
            {
                HandleShapeCreation();
            }
            else
            {
                HandleShapeDraggingCompletion();
            }

            DrawEverything();
            UpdateSelected();
        }

        // Verifies that the paint group is set, throws an exception if not
        private void VerifyPaintGroup()
        {
            if (_paintGroup == null)
                throw new Exception("Paint group is not set");
        }

        // Deletes the selected shape
        private void DeleteSelectedShape()
        {
            if (_selectedIndex != -1)
            {
                RemoveShape(_selectedIndex);
                _selectedIndex = -1;
                DrawEverything();
            }
        }

        // Initializes dragging a shape
        private void StartDraggingShape()
        {
            if (_selectedIndex != -1)
            {
                InitializeDrag();
            }
            else
            {
                SelectShapeUnderCursor();
            }
        }

        // Initializes dragging a selected shape
        private void InitializeDrag()
        {
            // Check if selected shape has the cursor point on it
            var cursorPoint = CreateCursorPoint();
            if (_model.Shapes[_selectedIndex].IsPointOnShape(cursorPoint))
            {
                _dragging = true;
                _startPoint = new List<int> { cursorPoint.X, cursorPoint.Y };
            }
            else
            {
                ResetShape();
            }
        }

        // Selects a shape under the cursor
        private void SelectShapeUnderCursor()
        {
            var cursorPoint = CreateCursorPoint();
            var flag = true;
            for (int i = 0; i < _model.Shapes.Count && flag; i++)
            {
                DeselectShape(i);
                if (ShouldSelectShape(i, cursorPoint))
                {
                    SelectShape(i);
                    flag = false;
                }
            }
        }

        // Deselects a shape at the given index
        private void DeselectShape(int i)
        {
            _model.Shapes[i].Selected = false;
        }

        // Checks whether a shape should be selected based on the cursor point
        private bool ShouldSelectShape(int i, Point cursorPoint)
        {
            return _model.Shapes[i].IsPointOnShape(cursorPoint);
        }

        // Selects a shape at the given index
        private void SelectShape(int i)
        {
            _selectedIndex = i;
            _model.Shapes[_selectedIndex].Selected = true;
        }

        // Creates a point from the cursor position
        private Point CreateCursorPoint()
        {
            return new Point(_cursorPos.X - PAINT_OFFSET_X, _cursorPos.Y - PAINT_OFFSET_Y);
        }

        // Handles potential shape drawing based on current state
        private void HandlePotentialShapeDrawing()
        {
            Cursor = Cursors.Cross;
            if (_startPoint != null)
            {
                CreateAndDrawTempShape();
            }
        }

        // Creates and draws a temporary shape
        private void CreateAndDrawTempShape()
        {
            CreateTempShape();
            DrawEverything();
        }

        // Creates a temporary shape
        private void CreateTempShape()
        {
            var tempList = new List<int>();
            tempList.AddRange(_startPoint);
            tempList.AddRange(CreateCursorPositionList());
            _tempShape = _model.CreateShape(_shapeType, tempList);
        }

        // Creates a list of integers representing cursor position
        private List<int> CreateCursorPositionList()
        {
            return new List<int> { _cursorPos.X - PAINT_OFFSET_X, _cursorPos.Y - PAINT_OFFSET_Y };
        }

        // Handles shape dragging logic
        private void HandleShapeDragging()
        {
            if (_dragging)
            {
                UpdateTempShapeForDragging();
                DrawEverything();
            }
        }

        // Updates temporary shape during dragging
        private void UpdateTempShapeForDragging()
        {
            var delta = GetShapeShiftDelta();
            var tempCoordinate = ComputeShapeAfterShiftCoordinates(delta);
            _tempShape =_model.CreateShape(_model.Shapes[_selectedIndex].ShapeType, tempCoordinate);
        }

        // Calculates the shift in position for a shape being dragged
        private Point GetShapeShiftDelta()
        {
            return new Point(_cursorPos.X - PAINT_OFFSET_X - _startPoint[0],
                _cursorPos.Y - PAINT_OFFSET_Y - _startPoint[1]);
        }

        // Computes new shape coordinates after shifting
        private List<int> ComputeShapeAfterShiftCoordinates(Point shift)
        {
            return new List<int>
            {
                _model.Shapes[_selectedIndex].Coordinates[0].X + shift.X,
                _model.Shapes[_selectedIndex].Coordinates[0].Y + shift.Y,
                _model.Shapes[_selectedIndex].Coordinates[1].X + shift.X,
                _model.Shapes[_selectedIndex].Coordinates[1].Y + shift.Y
            };
        }

        // Handles shape creation based on current state
        private void HandleShapeCreation()
        {
            _model.AddShape(CreateFinalShape());
            ResetShape();
        }

        // Creates the final shape based on current drawing parameters
        private IShape CreateFinalShape()
        {
            var endPosition = new List<int>();
            endPosition.AddRange(_startPoint);
            endPosition.AddRange(CreateCursorPositionList());
            return _model.CreateShape(_shapeType, endPosition);
        }

        // Handles completion of shape dragging
        private void HandleShapeDraggingCompletion()
        {
            if (_dragging)
            {
                _model.AddShape(_tempShape);
                RemoveShape(_selectedIndex);
                ResetShape();
            }
        }

        // Resets shape-related variables
        private void ResetShape()
        {
            _shapeType = ShapeType.Selection;
            UpdateSelected();
            _startPoint = null;
            _tempShape = null;
            _dragging = false;
            ClearShapeSelection();
        }

        // Clears the selection of a shape
        private void ClearShapeSelection()
        {
            if (_selectedIndex != -1)
            {
                _model.Shapes[_selectedIndex].Selected = false;
                _selectedIndex = -1;
            }
        }
    }
}
