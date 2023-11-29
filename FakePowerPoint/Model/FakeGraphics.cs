using System.Collections.Generic;
using System.Drawing;


namespace FakePowerPoint
{
    public interface IGraphics
    {
        void DrawRectangle(Pen pen, System.Drawing.Rectangle rectangle);

        void DrawEllipse(Pen pen, int x, int y, int width, int height);

        void DrawEllipse(Pen pen, System.Drawing.Rectangle rectangle);

        void DrawLine(Pen pen, int x1, int y1, int x2, int y2);
        void FillEllipse(Brush brush, int x, int y, int width, int height);
        void Clear(Color color);

    }

    public class TheOnlyTrueGraphics : IGraphics
    {
        private Graphics _graphics;

        public TheOnlyTrueGraphics(Graphics graphics)
        {
            _graphics = graphics;
        }

        public void SetGraphic(System.Drawing.Graphics graphics)
        {
            _graphics = graphics;
        }


        public void DrawRectangle(Pen pen, System.Drawing.Rectangle rectangle)
        {
            _graphics.DrawRectangle(pen, rectangle);
        }

        public void DrawEllipse(Pen pen, int x, int y, int width, int height)
        {
            _graphics.DrawEllipse(pen, x, y, width, height);
        }

        public void DrawLine(Pen pen, int x1, int y1, int x2, int y2)
        {
            _graphics.DrawLine(pen, x1, y1, x2, y2);
        }

        public void FillEllipse(Brush brush, int x, int y, int width, int height)
        {
            _graphics.FillEllipse(brush, x, y, width, height);
        }

        public void Clear(Color color)
        {
            _graphics.Clear(color);
        }

        public void DrawEllipse(Pen pen, System.Drawing.Rectangle rectangle)
        {
            _graphics.DrawEllipse(pen, rectangle);
        }

        public static IGraphics FormFromImage(Image image)
        {
            return new TheOnlyTrueGraphics(Graphics.FromImage(image));
        }
    }
}
