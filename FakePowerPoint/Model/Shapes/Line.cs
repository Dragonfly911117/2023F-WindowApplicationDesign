using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace FakePowerPoint
{
    public class Line : IShape
    {
        public ShapeType ShapeType
        {
            get => _shapeType;
            set => throw new InvalidOperationException("The shape type cannot be changed");
        }

        public String Coordinates
        {
            get => GetCoordinates();
            set => throw new InvalidOperationException("The coordinates cannot be changed directly");
        }

        public Color Color
        {
            get => this._color;
            set
            {
                this._color = value;
                OnPropertyChanged(COLOR);
            }
        }

        // brief: Constructor
        public Line(int x1 = 0, int x2 = 0, int y1 = 0, int y2 = 0)
        {
            this._color = Color.FromArgb(255, 123, 0, 33);
            this._shapeType = ShapeType.Line;
            this._coordinates = new List<Tuple<int, int>>();
            _coordinates.Add(new Tuple<int, int>(x1, y1));
            _coordinates.Add(new Tuple<int, int>(x2, y2));
        }

        // brief: Draw the shape
        public void Draw(Info drawer)
        {
            drawer.DrawLine(Color, _coordinates);
        }

        public string GetCoordinates()
        {
            return
                $"({_coordinates[0].Item1}, {_coordinates[0].Item2}),\n({_coordinates[1].Item1}, {_coordinates[1].Item2})";
        }

        // brief: Get the coordinates of the shape

        void OnPropertyChanged(String propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private Color _color;
        private readonly ShapeType _shapeType;
        private readonly List<Tuple<int, int>> _coordinates;

        private const String COLOR = "Color";
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
