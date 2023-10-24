using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace FakePowerPoint
{
    public class Rectangle : IShape, INotifyPropertyChanged
    {
        private const string COLOR = "Color";
        private Color _color;
        private ShapeType _shapeType;
        private List<Tuple<int, int>> _coordinates;

        public event PropertyChangedEventHandler PropertyChanged;

        public ShapeType ShapeType
        {
            get => _shapeType;
            set => throw new InvalidOperationException("The shape type cannot be changed");
        }

        public string Coordinates
        {
            get => GetCoordinates();
            set => throw new InvalidOperationException("The coordinates cannot be changed directly");
        }

        public Color Color
        {
            get => _color;
            set
            {
                if (_color != value)
                {
                    _color = value;
                    OnPropertyChanged();
                }
            }
        }

        public Rectangle(int x1 = 0, int x2 = 0, int y1 = 0, int y2 = 0)
        {
            _color = Color.FromArgb(255, 132, 120, 222);
            _shapeType = ShapeType.Rectangle;
            _coordinates = new List<Tuple<int, int>>();
            _coordinates.Add(new Tuple<int, int>(x1, y1));
            _coordinates.Add(new Tuple<int, int>(x2, y2));
        }

        public void Draw(PresentationModel drawer)
        {
            drawer.DrawRectangle(Color, ConvertToRectangle());
        }

        public string GetCoordinates()
        {
            return $"({_coordinates[0].Item1}, {_coordinates[0].Item2}),\n({_coordinates[1].Item1}, {_coordinates[1].Item2})";
        }

        private System.Drawing.Rectangle ConvertToRectangle()
        {
            var x1 = Math.Min(_coordinates[0].Item1, _coordinates[1].Item1);
            var x2 = Math.Max(_coordinates[0].Item1, _coordinates[1].Item1);
            var y1 = Math.Min(_coordinates[0].Item2, _coordinates[1].Item2);
            var y2 = Math.Max(_coordinates[0].Item2, _coordinates[1].Item2);
            return new System.Drawing.Rectangle(x1, y1, x2 - x1, y2 - y1);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
