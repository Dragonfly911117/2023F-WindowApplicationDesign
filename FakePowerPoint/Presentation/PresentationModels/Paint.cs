﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FakePowerPoint
{
    public partial class PresentationModel
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
            if (_paintGroup == null)
                throw new Exception("Paint group is not set");

            foreach (var shape in _model.Shapes)
                shape.Draw(this);

            if (_tempShape != null)
                _tempShape.Draw(this);
        }

        // brief: set the paint group for the drawer
        public void SetPaintGroup(GroupBox paintGroup)
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
            if (_shapeType == ShapeType.Line)
            {
                _shapeType = ShapeType.Undefined;
                this.Cursor = Cursors.Default;
            }

            this.Cursor = Cursors.Cross;
            _shapeType = ShapeType.Line;
        }

        public void DrawRectButtonClicked()
        {
            if (_shapeType == ShapeType.Rectangle)
            {
                _shapeType = ShapeType.Undefined;
                this.Cursor = Cursors.Default;
            }

            this.Cursor = Cursors.Cross;
            _shapeType = ShapeType.Rectangle;
        }

        public void DrawEclipseButtonClicked()
        {
            if (_shapeType == ShapeType.Eclipse)
            {
                _shapeType = ShapeType.Undefined;
                this.Cursor = Cursors.Default;
            }

            this.Cursor = Cursors.Cross;
            _shapeType = ShapeType.Eclipse;
        }

        public void MouseDownOnPanel(MouseEventArgs mouseEventArgs)
        {
            if (_shapeType != ShapeType.Undefined)
                _startPoint = new List<int> { mouseEventArgs.X, mouseEventArgs.Y };
        }

        public void MouseMovingOnPanel(MouseEventArgs mouseEventArgs)
        {
            if (_startPoint != null)
            {
                var tempCoordinates =
                    new List<int> { _startPoint[0], _startPoint[1], mouseEventArgs.X, mouseEventArgs.Y };
                _tempShape = ShapeFactory.CreateShape(_shapeType.ToString(), tempCoordinates);
                _paintGroup.Invalidate();
            }
        }

        public void MouseUpOnPanel(MouseEventArgs mouseEventArgs)
        {
            if (_startPoint == null || _shapeType == ShapeType.Undefined)
                return;

            var tempCoordinates = new List<int> { _startPoint[0], _startPoint[1], mouseEventArgs.X, mouseEventArgs.Y };
            var shape = ShapeFactory.CreateShape(_shapeType.ToString(), tempCoordinates);
            _model.AddShape(shape);
            _paintGroup.Invalidate();

            this.Cursor = Cursors.Default;
            _shapeType = ShapeType.Undefined;
            _startPoint = null;
            _tempShape = null;
        }

        public void UpdateMenuStripButtonsStates(ref List<ToolStripButton> buttons)
        {
            foreach (var button in buttons)
                button.Checked = false;

            if (_shapeType == ShapeType.Undefined)
                return;

            // see also: ShapeType enum above for its int values
            buttons[(int)(_shapeType - 1)].Checked = true;
        }


        private List<int> _startPoint = null;
        private IShape _tempShape = null;
        private ShapeType _shapeType = ShapeType.Undefined;


        private GroupBox _paintGroup = null;
        private const string REMOVE = "Remove";
        private const int PEN_WIDTH = 5;

        private const int OFFSET_X = 217;
        private const int OFFSET_Y = 29;
        private const int MAX_X = 1358;
        private const int MAX_Y = 1052;
    }
}
