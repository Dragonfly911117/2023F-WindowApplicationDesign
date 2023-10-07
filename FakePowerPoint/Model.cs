using System.Collections.Generic;

namespace FakePowerPoint
{
    public class Model
    {
        public void AddShape(IShape shape)
        {
            _shapes.Add(shape);
        }

        public Model()
        {
        }

        private List<IShape> _shapes = new List<IShape>();
    }
}
