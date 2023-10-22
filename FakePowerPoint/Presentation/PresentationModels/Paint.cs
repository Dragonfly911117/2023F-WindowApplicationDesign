using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace FakePowerPoint
{
    public partial class Info
    {
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
                shape.Draw(this);
            }
        }

        // brief: set the paint group for the drawer
        public void SetPaintGroup(System.Windows.Forms.GroupBox paintGroup)
        {
            _paintGroup = paintGroup;
        }

        public void DrawEclipse(Color color, System.Drawing.Rectangle convertToRectangle)
        {
            var myPen = new Pen(color, PEN_WIDTH);
            var graphics = _paintGroup.CreateGraphics();
            graphics.DrawEllipse(myPen, convertToRectangle);
            myPen.Dispose();
            graphics.Dispose();
        }

        public void DrawLineButtonClicked()
        {
            throw new NotImplementedException();
        }

        public void DrawRectButtonClicked()
        {
            throw new NotImplementedException();
        }

        public void DrawEclipseButtonClicked()
        {
            throw new NotImplementedException();
        }


        private System.Windows.Forms.GroupBox _paintGroup = null;
        private const string REMOVE = "Remove";
        private const int PEN_WIDTH = 5;
    }
}
