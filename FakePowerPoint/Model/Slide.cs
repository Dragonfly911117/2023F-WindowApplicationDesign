using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FakePowerPoint.Model
{
    public class Slide
    {
        Bitmap _bitmap;
        readonly List<Shape.Shape> _shapes;
        Graphics _graphics;
        Size _size;

        public Slide(Size size)
        {
            _bitmap = new Bitmap(size.Width, size.Height);
            _shapes = new List<Shape.Shape>();
            _graphics = Graphics.FromImage(_bitmap);
            _size = size;
        }

        void Resize(Size size) // TODO: Get size from view
        {
            _shapes.ForEach(shape => shape.Resize(size));
            _bitmap = new Bitmap(size.Width, size.Height);
            _graphics?.Dispose();
            _graphics = Graphics.FromImage(_bitmap);
            _size = size;
            Draw();
        }

        public void AddShape(Shape.Shape shape)
        {
            _shapes.Add(shape);
            Draw();
        }

        public void RemoveShape(Shape.Shape shape)
        {
            _shapes.Remove(shape);
        }

        public void Draw()
        {
            _graphics.Clear(Color.Black);
            _shapes.ForEach(shape => shape.Draw(_graphics));
        }

        public Panel ToPanel()
        {
            var panel = new Panel();
            panel.BackgroundImage = _bitmap;
            panel.BackgroundImageLayout = ImageLayout.Stretch;
            return panel;
        }

        public Button ToButton()
        {
            var button = new Button();
            button.BackgroundImage = _bitmap;
            button.BackgroundImageLayout = ImageLayout.Stretch;
            return button;
        }

        public Size GetSize()
        {
            return _size;
        }

        public Bitmap GetBitmap()
        {
            return _bitmap;
        }
    }
}
