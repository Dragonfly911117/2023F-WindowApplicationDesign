using System.Drawing;
using FakePowerPoint;
using Rectangle = System.Drawing.Rectangle;

namespace FakeUnitTest;

// this is the fake class that stores input data instead of drawing it
public class FakeGraphics : IGraphics
{
    public Pen NotPen;
    public Rectangle NotRectangle;
    public Brush Brush;
    public int X;
    public int Y;
    public int Width;
    public int Height;
    public int X1;
    public int Y1;
    public int X2;
    public int Y2;
    public Color Color;


    public void DrawRectangle(Pen pen, Rectangle rectangle)
    {
        this.NotPen = pen;
        this.NotRectangle = rectangle;
    }

    public void DrawEllipse(Pen pen, int x, int y, int width, int height)
    {
        this.NotPen = pen;
        this.X = x;
        this.Y = y;
        this.Width = width;
        this.Height = height;
    }

    public void DrawEllipse(Pen pen, Rectangle rectangle)
    {
        this.NotPen = pen;
        this.NotRectangle = rectangle;
    }

    public void DrawLine(Pen pen, int x1, int y1, int x2, int y2)
    {
        this.NotPen = pen;
        this.X1 = x1;
        this.Y1 = y1;
        this.X2 = x2;
        this.Y2 = y2;
    }

    public void FillEllipse(Brush brush, int x, int y, int width, int height)
    {
        this.Brush = brush;
        this.X = x;
        this.Y = y;
        this.Width = width;
        this.Height = height;
    }

    public void Clear(Color color)
    {
        this.Color = color;
    }
}
