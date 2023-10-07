﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;

namespace FakePowerPoint
{
    public class Rectangle : IShape
    {
        public Color Color { get; set; } = Color.FromArgb(255, 132, 120, 222);
        public ShapeType ShapeType { get; set; } = ShapeType.Rectangle;
        public List<Tuple<int, int>> Coordinates { get; set; } = new List<Tuple<int, int>>();

        public Rectangle()
        {
            // make top left and bottom right  random from x = 0~1358, y = 0~1052
            var x1 = Utilities.RandomNumber(0, 1358);
            var y1 = Utilities.RandomNumber(0, 1052);
            var x2 = Utilities.RandomNumber(0, 1358);
            var y2 = Utilities.RandomNumber(0, 1052);

            Coordinates.Add(new Tuple<int, int>(x1, y1));
            Coordinates.Add(new Tuple<int, int>(x2, y2));
        }

        public void Draw(IShapeDrawer drawer)
        {
            drawer.DrawRectangle(Color, ConvertToRectangle());
        }

        public String GetCoordinates()
        {
            return
                $"({Coordinates[0].Item1}, {Coordinates[0].Item2}),\n({Coordinates[1].Item1}, {Coordinates[1].Item2})";
        }

        private System.Drawing.Rectangle ConvertToRectangle()
        {
            return new System.Drawing.Rectangle(Coordinates[0].Item1, Coordinates[0].Item2, Coordinates[1].Item1 - Coordinates[0].Item1, Coordinates[1].Item2 - Coordinates[0].Item2);
        }
    }
}
