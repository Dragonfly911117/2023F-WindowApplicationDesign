using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FakePowerPoint.Model.Enums;
using FakePowerPoint.Properties;

namespace FakePowerPoint.Model
{
    public class Slide
    {
        Bitmap _bitmap;
        BindingList<Shape.Shape> _shapes;
        Size _size;

        public Slide()
        {
            _size = new Size(int.Parse(Resources.DEFAULT_WINDOW_WIDTH), int.Parse(Resources.DEFAULT_WINDOW_HEIGHT));
            _bitmap = new Bitmap(_size.Width, _size.Height);
            _shapes = new BindingList<Shape.Shape>();
        }

        public void Resize()
        {
            Draw();
        }

        public void AddShape(Shape.Shape shape, int index = -1)
        {
            if (index > _shapes.Count)
            {
                throw new IndexOutOfRangeException();
            }
            index = index == -1 ? _shapes.Count : index;
            _shapes.Insert(index, shape);
            Draw();
        }

        public void RemoveShape(int index)
        {
            _shapes.RemoveAt(index);
            Draw();
        }
        public void RemoveShape(Shape.Shape shape)
        {
            _shapes.Remove(shape);
            Draw();
        }

        public void Draw()
        {
            var graphics = Graphics.FromImage(_bitmap);
            graphics.Clear(Color.Black);
            foreach (var shape in _shapes)
            {
                shape.Draw(graphics);
            }
            graphics.Dispose();
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

        public int GetShapeIndex(Point normalizedPoint)
        {
            UnselectShapes();
            for (var i = _shapes.Count - 1; i >= 0; i--)
            {
                if (!_shapes[i].IfShapeClicked(normalizedPoint))
                    continue;
                _shapes[i].SetSelected(true);
                return i;
            }
            return -1;
        }

        public void UnselectShapes()
        {
            foreach (var shape in _shapes)
            {
                shape.SetSelected(false);
            }
        }

        public void ResizeShape(int index, Size size, HandlePosition handlePosition)
        {
            _shapes[index].Resize(size, handlePosition);
            Draw();
        }

        public void MoveShape(int index, Size offset)
        {
            _shapes[index].Move(offset);
            Draw();
        }
    }
}
