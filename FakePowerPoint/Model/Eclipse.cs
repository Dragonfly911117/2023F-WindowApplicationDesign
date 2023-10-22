using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace FakePowerPoint
{
    public class Eclipse : IShape
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
        public Eclipse(int x1 = 0, int x2 = 0, int y1 = 0, int y2 = 0)
        {
            // random color but not green-ish nor used by the other shapes
            this._color = Color.FromArgb(255, 132, 120, 112);
            this._shapeType = ShapeType.Eclipse;
            this._coordinates = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(x1, y1), new Tuple<int, int>(x2, y2)
            };
        }

        // brief: Draw the shape

        public void Draw(Info drawer)
        {
            drawer.DrawEclipse(Color, ConvertToRectangle());
        }

        // brief: Get the coordinates of the shape

        public string GetCoordinates()
        {
            return
                $"({_coordinates[0].Item1}, {_coordinates[0].Item2}),\n({_coordinates[1].Item1}, {_coordinates[1].Item2})";
        }

        // brief: Convert the coordinates to a rectangle

        private System.Drawing.Rectangle ConvertToRectangle()
        {
            return new System.Drawing.Rectangle(_coordinates[0].Item1, _coordinates[0].Item2,
                _coordinates[1].Item1 - _coordinates[0].Item1, _coordinates[1].Item2 - _coordinates[0].Item2);
        }

        void OnPropertyChanged(String propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private Color _color;
        private ShapeType _shapeType;
        private List<Tuple<int, int>> _coordinates;

        private const String COLOR = "Color";
        private const String COORDINATES = "Coordinates";
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
