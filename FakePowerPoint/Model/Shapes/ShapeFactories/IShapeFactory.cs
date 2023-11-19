using System.Collections.Generic;

namespace FakePowerPoint
{
    public abstract class ShapeFactory
    {
        // Method to create a shape
        public abstract IShape CreateShape(List<int> coordinates);
    }
}
