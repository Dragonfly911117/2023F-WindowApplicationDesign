﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace FakePowerPoint
{
    public partial class PresentationModel
    {
        // To store the coordinates of the mouse cursor
        protected Point CursorPos = new Point(0, 0);
        // Model instance for the presentation
        protected Model Model;

        // Presentation model constructor accepting a model instance as parameter
        public PresentationModel(Model model)
        {
            Model = model;
            InitializeSelectionShape();
        }

        // Initialize shape selection
        private void InitializeSelectionShape()
        {
            var enumLength = Enum.GetValues(typeof(ShapeType)).Length;
            // Default mode
            Selected.Add(true);
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
            CursorPos = pos;
            Cursor = Cursors.Default;
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
            IsInsideRect(CursorPos, PAINT_OFFSET_X, PAINT_OFFSET_X + _paintGroupWidth, PAINT_OFFSET_Y,
                    PAINT_OFFSET_Y + _paintGroupHeight);

        // Check if x and y values of a given point is inside the rectangle area defined by (x1, y1) (x2, y2)
        protected bool IsInsideRect(Point pos, int x1, int x2, int y1, int y2) =>
            pos.X >= x1 && pos.X <= x2 && pos.Y >= y1 && pos.Y <= y2;

        // Handle the mouse down event on the panel
        public void KeyDown(Keys eKeyCode)
        {
            if (eKeyCode == Keys.Delete)
            {
                DeleteSelectedShape();
            }
        }
    }
}
