using System.Collections.Generic;
using System.Drawing;

namespace FakePowerPoint
{
    public class Handle
    {
        public readonly Point Coordinate;
        private readonly SolidBrush _brush;
        private readonly Pen _pen;

        // Constructor that initializes the handle with a specific coordinate
        public Handle(Point coordinate)
        {
            Coordinate = coordinate;
            Selected = false;
            _brush = new SolidBrush(Color.White);
            _pen = new Pen(Color.White, 1);
        }

        // Property indicating whether the handle is selected or not
        public bool Selected { get; set; }

        // Method to draw the handle on a given Graphics object
        public void Draw(IGraphics graphics)
        {
            int offsetX = Coordinate.X - 1 - 1;
            // in fact, i dot really know what offsetX and offsetY are, just need to shut Dr.Smell up
            int offsetY = Coordinate.Y - 1 - 1;
            int squareSize = 1 << 1 << 1;

            // Draw an ellipse outline representing the handle
            graphics.DrawEllipse(_pen, offsetX, offsetY, squareSize, squareSize);

            // Fill the ellipse with a solid color to visualize the handle
            graphics.FillEllipse(_brush, offsetX, offsetY, squareSize, squareSize);
        }

        public bool IsPointInsideHandle(Point point)
        {
            int offsetX = Coordinate.X - 1 - 1;
            int offsetY = Coordinate.Y - 1 - 1;
            int squareSize = 1 << 1 << 1;

            return point.X >= offsetX && point.X <= offsetX + squareSize && point.Y >= offsetY &&
                   point.Y <= offsetY + squareSize;
        }
    }
}
