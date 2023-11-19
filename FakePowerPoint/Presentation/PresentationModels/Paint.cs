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

        public void DrawEverything()
        {
            VerifyPaintGroup();
            var graphics = CreateGraphicsFromBitmap();

            _tempShape?.Draw(graphics, PEN_WIDTH);
            DrawShapesOnGraphics(graphics);

            InvalidateControls();
        }

        private Graphics CreateGraphicsFromBitmap()
        {
            var graphics = Graphics.FromImage(_bitmap);
            graphics.Clear(_paintGroup.BackColor);
            return graphics;
        }

        private void DrawShapesOnGraphics(Graphics graphics)
        {
            foreach (var shape in _model.Shapes.Reverse())
            {
                shape?.Draw(graphics, PEN_WIDTH);
            }
        }

        private void InvalidateControls()
        {
            _paintGroup.Invalidate();
            _button.Invalidate();
        }

        public void SetPaintGroup(GroupBox paintGroup)
        {
            _paintGroup = paintGroup;
            CreateBitmapForPaintGroup();
        }

        private void CreateBitmapForPaintGroup()
        {
            _bitmap = new Bitmap(_paintGroup.Width, _paintGroup.Height);
            _paintGroup.DrawToBitmap(_bitmap, _paintGroup.ClientRectangle);
            _paintGroup.BackgroundImage = _bitmap;
        }

        public void DrawShapeButtonClicked(ShapeType shapeType)
        {
            HandleShapeButtonClick(shapeType);
        }

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

        private void UpdateShapeTypeAndSelection(ShapeType shapeType)
        {
            _shapeType = shapeType;
            UpdateSelected();
        }

        private void MouseDownOnPanel()
        {
            if (_shapeType != ShapeType.Undefined)
            {
                StartDrawingShape();
            }
            else
            {
                StartDraggingShape();
            }

            DrawEverything();
        }

        private void StartDrawingShape()
        {
            _startPoint = new List<int> { _cursorPos.X - PAINT_OFFSET_X, _cursorPos.Y - PAINT_OFFSET_Y };
            Cursor = Cursors.Cross;
        }

        private void MouseMovingOnPanel()
        {
            if (_shapeType != ShapeType.Undefined)
            {
                HandlePotentialShapeDrawing();
            }
            else
            {
                HandleShapeDragging();
            }
        }


        private void MouseUpOnPanel()
        {
            if (_startPoint == null) return;

            if (_shapeType != ShapeType.Undefined)
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

        private void VerifyPaintGroup()
        {
            if (_paintGroup == null)
                throw new Exception("Paint group is not set");
        }

        private void DeleteSelectedShape()
        {
            if (_selectedIndex != -1)
            {
                RemoveShape(_selectedIndex);
                _selectedIndex = -1;
                DrawEverything();
            }
        }

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

        private void DeselectShape(int i)
        {
            _model.Shapes[i].Selected = false;
        }

        private bool ShouldSelectShape(int i, Point cursorPoint)
        {
            return _model.Shapes[i].IsPointOnShape(cursorPoint);
        }

        private void SelectShape(int i)
        {
            _selectedIndex = i;
            _model.Shapes[_selectedIndex].Selected = true;
        }

        private Point CreateCursorPoint()
        {
            return new Point(_cursorPos.X - PAINT_OFFSET_X, _cursorPos.Y - PAINT_OFFSET_Y);
        }

        private void HandlePotentialShapeDrawing()
        {
            Cursor = Cursors.Cross;
            if (_startPoint != null)
            {
                CreateAndDrawTempShape();
            }
        }

        private void CreateAndDrawTempShape()
        {
            var endPosition = CreateCursorPositionList();
            _tempShape = ShapeFactory.CreateShape(_shapeType, _startPoint, endPosition);
            DrawEverything();
        }

        private List<int> CreateCursorPositionList()
        {
            return new List<int> { _cursorPos.X - PAINT_OFFSET_X, _cursorPos.Y - PAINT_OFFSET_Y };
        }

        private void HandleShapeDragging()
        {
            if (_dragging)
            {
                UpdateTempShapeForDragging();
                DrawEverything();
            }
        }

        private void UpdateTempShapeForDragging()
        {
            var delta = GetShapeShiftDelta();
            var tempCoordinate = ComputeShapeAfterShiftCoordinates(delta);
            _tempShape = ShapeFactory.CreateShape(_model.Shapes[_selectedIndex].ShapeType, tempCoordinate);
        }

        private Point GetShapeShiftDelta()
        {
            return new Point(_cursorPos.X - PAINT_OFFSET_X - _startPoint[0],
                _cursorPos.Y - PAINT_OFFSET_Y - _startPoint[1]);
        }

        private Tuple<Point, Point> ComputeShapeAfterShiftCoordinates(Point shift)
        {
            return new Tuple<Point, Point>(
                new Point(_model.Shapes[_selectedIndex].Coordinates[0].X + shift.X,
                    _model.Shapes[_selectedIndex].Coordinates[0].Y + shift.Y),
                new Point(_model.Shapes[_selectedIndex].Coordinates[1].X + shift.X,
                    _model.Shapes[_selectedIndex].Coordinates[1].Y + shift.Y));
        }

        private void HandleShapeCreation()
        {
            _model.AddShape(CreateFinalShape());
            ResetShape();
        }

        private IShape CreateFinalShape()
        {
            var endPosition = CreateCursorPositionList();
            return ShapeFactory.CreateShape(_shapeType, _startPoint, endPosition);
        }

        private void HandleShapeDraggingCompletion()
        {
            if (_dragging)
            {
                _model.AddShape(_tempShape);
                RemoveShape(_selectedIndex);
                ResetShape();
            }
        }

        private void ResetShape()
        {
            _shapeType = ShapeType.Undefined;
            UpdateSelected();
            _startPoint = null;
            _tempShape = null;
            _dragging = false;
            ClearShapeSelection();
        }

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
