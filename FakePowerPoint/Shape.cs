using System;
using System.Drawing;

namespace FakePowerPoint
{
    public class Shape
    {
        protected Shape()
        {
            Color = Color.FromArgb(153, 132, 120, 222);
            CenterCoordinate = new Tuple<int, int>(0, 0);
        }

        protected Shape(Color color, Tuple<int, int> centerCoordinate)
        {
            Color = color;
            CenterCoordinate = centerCoordinate;
        }

        public virtual void Draw(Graphics graphics)
        {
        }

        protected Color Color { get; set; }
        protected Tuple<int, int> CenterCoordinate { get; set; }
    }
}
