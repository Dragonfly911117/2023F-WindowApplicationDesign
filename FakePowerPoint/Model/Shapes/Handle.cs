using System.Collections.Generic;
using System.Drawing;

namespace FakePowerPoint
{
    public class Handle
    {
        private readonly Point _coordinate;
        private readonly SolidBrush _brush;
        private readonly Pen _pen;

        // Constructor that initializes the handle with a specific coordinate
        public Handle(Point coordinate)
        {
            _coordinate = coordinate;
            Selected = false;
            _brush = new SolidBrush(Color.White);
            _pen = new Pen(Color.White, 1);
        }

        // Property indicating whether the handle is selected or not
        public bool Selected { get; set; }

        // Method to draw the handle on a given Graphics object
        public void Draw(Graphics graphics)
        {
            int x = _coordinate.X - 2, y = _coordinate.Y - 2, size = 4;

            // Draw an ellipse outline representing the handle
            graphics.DrawEllipse(_pen, x, y, size, size);

            // Fill the ellipse with a solid color to visualize the handle
            graphics.FillEllipse(_brush, x, y, size, size);
        }
    }
}
