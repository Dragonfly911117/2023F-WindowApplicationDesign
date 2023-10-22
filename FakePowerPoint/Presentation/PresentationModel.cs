﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakePowerPoint
{
    public interface IShapeDrawer
    {
        // brief: Draw everything on the paint region
        public void DrawEverything();

        // brief: Draw a rectangle on the paint region
        public void DrawRectangle(Color color, System.Drawing.Rectangle rectangle);

        // brief: Draw a line on the paint region
        void DrawLine(Color color, List<Tuple<int, int>> coordinates);

        // brief: set the paint group for the drawer
        void SetPaintGroup(System.Windows.Forms.GroupBox paintGroup);
    }


    public class PresentationModel : IShapeDrawer
    {
        public PresentationModel(Model model)
        {
            this._model = model;
        }

        // brief: Draw a rectangle on the paint region
        public void DrawRectangle(Color color, System.Drawing.Rectangle rectangle)
        {
            var myPen = new Pen(color, PEN_WIDTH);
            var graphics = _paintGroup.CreateGraphics();
            graphics.DrawRectangle(myPen, rectangle);
            myPen.Dispose();
            graphics.Dispose();
        }

        // brief: Draw a line on the paint region
        public void DrawLine(Color color, List<Tuple<int, int>> coordinates)
        {
            var myPen = new Pen(color, PEN_WIDTH);
            var graphics = _paintGroup.CreateGraphics();
            graphics.DrawLine(myPen, coordinates[0].Item1, coordinates[0].Item2, coordinates[1].Item1,
                coordinates[1].Item2);
            myPen.Dispose();
            graphics.Dispose();
        }

        public void DrawEverything()
        {
            if (this._paintGroup == null)
            {
                throw new Exception("Paint group is not set");
            }

            foreach (var shape in _model.Shapes)
            {
                shape.Item3.Draw(this);
            }
        }

        // brief: set the paint group for the drawer
        public void SetPaintGroup(System.Windows.Forms.GroupBox paintGroup)
        {
            _paintGroup = paintGroup;
        }

        // brief: Add a shape to the data grid
        public void AddShape(string shapeType)
        {
            var shape = ShapeFactory.CreateShape(shapeType);
            _model.AddShape(shapeType); // TODO: make the list store the shape instead of the String type
        }

        // brief: Remove a shape from the paint region
        public void RemoveShape(int index)
        {
            _model.RemoveShape(index);
        }

        public List<String> ShapeTypes
        {
            get { return _model.ShapeTypes; }
        }


        private System.Windows.Forms.GroupBox _paintGroup = null;
        private readonly Model _model;
        private const string REMOVE = "Remove";
        private const int PEN_WIDTH = 5;
    }
}