using System.Collections.Generic;

namespace FakePowerPoint
{
    public class EclipseFactory : ShapeFactory
    {
        // Method to create a shape
        public override IShape CreateShape(List<int> coordinates)
        {
            var x1 = coordinates[0];
            var y1 = coordinates[1];
            var x2 = coordinates[2];
            var y2 = coordinates[3];
            return new Eclipse(x1, x2, y1, y2);
        }
    }
}
