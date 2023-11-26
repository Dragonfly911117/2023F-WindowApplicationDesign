using System.Collections.Generic;
using System.Drawing;
using FakePowerPoint;
using Rectangle = System.Drawing.Rectangle;

namespace FakeUnitTest;



public class FakeGraphics : IGraphics
{
    public void DrawRectangle(Pen pen, Rectangle rectangle)
    {
        throw new System.NotImplementedException();
    }

    public void DrawEllipse(Pen pen, int x, int y, int width, int height)
    {
        throw new System.NotImplementedException();
    }

    public void DrawEllipse(Pen pen, Rectangle rectangle)
    {
        throw new System.NotImplementedException();
    }

    public void DrawLine(Pen pen, int x1, int y1, int x2, int y2)
    {
        throw new System.NotImplementedException();
    }

    public void FillEllipse(Brush brush, int x, int y, int width, int height)
    {
        throw new System.NotImplementedException();
    }

    public void Clear(Color color)
    {
        throw new System.NotImplementedException();
    }
}
