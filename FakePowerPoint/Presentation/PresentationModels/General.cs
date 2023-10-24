using System;
using System.Drawing;
using System.Windows.Forms;

namespace FakePowerPoint
{
    public partial class PresentationModel
    {
        // To store the coordinates of the mouse cursor
        private Point _cursorPos = new Point(0, 0);
        // Model instance for the presentation
        private readonly Model _model;

        // Presentation model constructor accepting a model instance as parameter
        public PresentationModel(Model model)
        {
            _model = model;
            InitializeSelectionShape();
        }

        // Initialize shape selection
        private void InitializeSelectionShape()
        {
            var enumLength = Enum.GetValues(typeof(ShapeType)).Length;
            // Adds a false to the Selected List for every shape type except for the first one
            for (var i = 1; i < enumLength; i++)
            {
                Selected.Add(false);
            }
        }

        // Handle the mouse down event
        public void MouseDown(MouseEventArgs e)
        {
            // Check if the cursor is inside the area where drawings can be made
            if (IsCursorInsidePaintGroup())
            {
                MouseDownOnPanel();
            }
        }

        // Handle the mouse move event
        public void MouseMove(MouseEventArgs e, Point pos)
        {
            // Update the cursor position
            _cursorPos = pos;
            this.Cursor = Cursors.Default;
            // Check if the cursor is inside the area where drawings can be made
            if (IsCursorInsidePaintGroup())
            {
                MouseMovingOnPanel();
            }
        }

        // Handle the mouse up event
        public void MouseUp(MouseEventArgs e)
        {
            // Check if the cursor is inside the area where drawings can be made
            if (IsCursorInsidePaintGroup())
            {
                MouseUpOnPanel();
            }
        }

        // Check if cursor position is inside the area where drawings can be made
        private bool IsCursorInsidePaintGroup() =>
            IsInsideRect(_cursorPos, PAINT_OFFSET_X, PAINT_OFFSET_X + _paintGroup.Width, PAINT_OFFSET_Y,
                    PAINT_OFFSET_Y + _paintGroup.Height);

        // Check if x and y values of a given point is inside the rectangle area defined by (x1, y1) (x2, y2)
        private bool IsInsideRect(Point pos, int x1, int x2, int y1, int y2) =>
            pos.X >= x1 && pos.X <= x2 && pos.Y >= y1 && pos.Y <= y2;
    }
}
