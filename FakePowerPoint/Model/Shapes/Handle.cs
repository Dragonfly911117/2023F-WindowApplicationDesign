using System.Collections.Generic;
using System.Drawing;

namespace FakePowerPoint
{
    public class Handle
    {
        public Handle(Point coordinate)
        {
            Coordinate = coordinate;
            Selected = false;
        }
        public Point Coordinate { get; set; }
        public bool Selected { get; set; }
    }
}
