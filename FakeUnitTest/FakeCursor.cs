using System.Drawing;
using System.Windows.Forms;

namespace FakeUnitTest;

public class FakeCursor
{
    public Point Position { get; set; }

    public FakeCursor()
    {
        Position = new Point(0, 0);
    }

    public MouseEventArgs Down(Point pos)
    {
        Position = pos;
        return new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0);
    }

    public MouseEventArgs Move(Point pos)
    {
        Position = pos;
        return new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0);
    }

    public MouseEventArgs Up(Point pos)
    {
        Position = pos;
        return new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0);
    }
}
