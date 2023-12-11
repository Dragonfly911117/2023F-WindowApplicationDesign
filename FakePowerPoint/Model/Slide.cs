using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FakePowerPoint.Model
{
    public class Slide
    {
        Bitmap _bitmap;
        BindingList<Shape.Shape> _shapes;
        Graphics _graphics;
        Size _size;

        public Slide(Size size)
        {
            _bitmap = new Bitmap(size.Width, size.Height);
            _shapes = new BindingList<Shape.Shape>();
            _graphics = Graphics.FromImage(_bitmap);
            _size = size;
        }

        void Resize(Size size) // TODO: Get size from view
        {
            foreach (var shape in _shapes)
            {
                shape.Resize(size);
            }

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

        public void RemoveShape(int index)
        {
            _shapes.RemoveAt(index);
            Draw();
        }

        public void Draw()
        {
            _graphics.Clear(Color.Black);
            foreach (var shape in _shapes)
            {
                shape.Draw(_graphics);
            }
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

        public BindingList<Shape.Shape> GetShapes()
        {
            return _shapes;
        }

        public void SetShapes(BindingList<Shape.Shape> value)
        {
            _shapes = value;
        }
    }
}
