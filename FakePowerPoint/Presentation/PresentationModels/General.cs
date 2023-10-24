using System;
using System.Windows.Forms;

namespace FakePowerPoint
{
    public partial class PresentationModel
    {
        public PresentationModel(Model model)
        {
            _model = model;
            var enumLength = Enum.GetValues(typeof(ShapeType)).Length;
            for (int i = 1; i < enumLength; i++) // skip undefined
            {
                Selected.Add(false);
            }
        }

        public void MouseDown(MouseEventArgs e)
        {
            // check if e.pos is in PAINT_GROUP
            if (e.X >= PAINT_OFFSET_X && e.X <= PAINT_OFFSET_X + PAINT_WIDTH && e.Y >= PAINT_OFFSET_Y &&
                e.Y <= PAINT_OFFSET_Y + PAINT_HEIGHT)
            {
                MouseDownOnPanel(e);
            }
        }

        public void MouseMove(MouseEventArgs e)
        { this.Cursor = Cursors.Default;
            if (e.X >= PAINT_OFFSET_X && e.X <= PAINT_OFFSET_X + PAINT_WIDTH && e.Y >= PAINT_OFFSET_Y &&
                e.Y <= PAINT_OFFSET_Y + PAINT_HEIGHT)
            {
                MouseMovingOnPanel(e);
            }
        }

        public void MouseUp(MouseEventArgs e)
        {
            if (e.X >= PAINT_OFFSET_X && e.X <= PAINT_OFFSET_X + PAINT_WIDTH && e.Y >= PAINT_OFFSET_Y &&
                e.Y <= PAINT_OFFSET_Y + PAINT_HEIGHT)
            {
                MouseUpOnPanel(e);
            }
        }

        private readonly Model _model;
    }
}
