using System;
using System.Drawing;
using System.Windows.Forms;

namespace FakePowerPoint
{
    public partial class PresentationModel
    {
        public PresentationModel(Model model)
        {
            _model = model;
            var enumLength = Enum.GetValues(typeof(ShapeType)).Length;
            for (var i = 1; i < enumLength; i++) // skip undefined
            {
                Selected.Add(false);
            }
        }

        public void MouseDown(MouseEventArgs e)
        {
            // check if e.pos is in PAINT_GROUP
            if (IsInsideRect(_cursorPos, PAINT_OFFSET_X, PAINT_OFFSET_X + _paintGroup.Width, PAINT_OFFSET_Y,
                    PAINT_OFFSET_Y + _paintGroup.Height))
            {
                MouseDownOnPanel();
            }
        }

        public void MouseMove(MouseEventArgs e, Point pos)
        {
            this.Cursor = Cursors.Default;
            this._cursorPos = pos;
            if (IsInsideRect(_cursorPos, PAINT_OFFSET_X, PAINT_OFFSET_X + _paintGroup.Width, PAINT_OFFSET_Y,
                    PAINT_OFFSET_Y + _paintGroup.Height))
            {
                MouseMovingOnPanel();
                // this.Cursor = Cursors.Cross;
            }
        }

        public void MouseUp(MouseEventArgs e)
        {
            if (IsInsideRect(_cursorPos, PAINT_OFFSET_X, PAINT_OFFSET_X + _paintGroup.Width, PAINT_OFFSET_Y,
                    PAINT_OFFSET_Y + _paintGroup.Height))
            {
                MouseUpOnPanel();
            }
        }

        private bool IsInsideRect(Point pos, int x1, int x2, int y1, int y2)
        {
            return pos.X >= x1 && pos.X <= x2 && pos.Y >= y1 && pos.Y <= y2;
        }

        private Point _cursorPos = new Point(0, 0);
        private readonly Model _model;
    }
}
