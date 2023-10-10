using System;
using System.Collections.Generic;
using System.Drawing;

namespace FakePowerPoint
{
    public class Line : IShape
    {
        public Color Color { get; set; } = Color.FromArgb(255, 123, 0, 33);
        public ShapeType ShapeType { get; set; } = ShapeType.Line;
        public List<Tuple<int, int>> Coordinates { get; set; } = new List<Tuple<int, int>>();

        // brief: Constructor
        public Line()
        {
            // make top left and bottom right  random from x = 0~1920, y = 0~1080
            var x1 = GenerateRandomNumber(0, 1358);
            var y1 = GenerateRandomNumber(0, 1052);
            var x2 = GenerateRandomNumber(0, 1358);
            var y2 = GenerateRandomNumber(0, 1052);

            Coordinates.Add(new Tuple<int, int>(x1, y1));
            Coordinates.Add(new Tuple<int, int>(x2, y2));
        }

        // brief: Draw the shape
        public void Draw(IShapeDrawer drawer)
        {
            drawer.DrawLine(Color, Coordinates);
        }

        // brief: Get the coordinates of the shape
        public string GetCoordinates()
        {
            return
                $"({Coordinates[0].Item1}, {Coordinates[0].Item2}),\n({Coordinates[1].Item1}, {Coordinates[1].Item2})";
        }
        // brief: Generate a random number
        private int GenerateRandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }
        private  readonly Random _random = new Random();
    }
}
