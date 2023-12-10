using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FakePowerPoint.Model
{
    public class Slide
    {
        Bitmap _bitmap;
        readonly List<Shape.Shape> _shapes;

        public Slide(Size size)
        {
            _bitmap = new Bitmap(size.Width, size.Height);
            _shapes = new List<Shape.Shape>();
        }

        void Resize(Size size)
        {
            _shapes.ForEach(shape => shape.Resize(size));
            _bitmap = new Bitmap(size.Width, size.Height);
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
            using var graphics = Graphics.FromImage(_bitmap);
            graphics.Clear(Color.Black);
            _shapes.ForEach (shape => shape.Draw(graphics));
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
            return _bitmap.Size;
        }

        public Bitmap GetBitmap()
        {
            return _bitmap;
        }
    }
}
