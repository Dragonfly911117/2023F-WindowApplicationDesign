using System;
using System.Drawing;
using System.Windows.Forms;

namespace FakePowerPoint
{
    public partial class PresentationModel
    {
        private Point _cursorPos = new Point(0, 0);
        private readonly Model _model;


        public PresentationModel(Model model)
        {
            _model = model;
            InitializeSelectionShape();
        }

        private void InitializeSelectionShape()
        {
            var enumLength = Enum.GetValues(typeof(ShapeType)).Length;
            for (var i = 1; i < enumLength; i++)
            {
                Selected.Add(false);
            }
        }

        public void MouseDown(MouseEventArgs e)
        {
            if (IsCursorInsidePaintGroup())
            {
                MouseDownOnPanel();
            }
        }

        public void MouseMove(MouseEventArgs e, Point pos)
        {
            _cursorPos = pos;
            this.Cursor = Cursors.Default;
            if (IsCursorInsidePaintGroup())
            {
                MouseMovingOnPanel();
            }
        }

        public void MouseUp(MouseEventArgs e)
        {
            if (IsCursorInsidePaintGroup())
            {
                MouseUpOnPanel();
            }
        }

        private bool IsCursorInsidePaintGroup() =>
            IsInsideRect(_cursorPos, PAINT_OFFSET_X, PAINT_OFFSET_X + _paintGroup.Width, PAINT_OFFSET_Y,
                    PAINT_OFFSET_Y + _paintGroup.Height);

        private bool IsInsideRect(Point pos, int x1, int x2, int y1, int y2) =>
            pos.X >= x1 && pos.X <= x2 && pos.Y >= y1 && pos.Y <= y2;
    }
}
