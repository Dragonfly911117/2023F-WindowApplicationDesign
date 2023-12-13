﻿using System;
using System.Drawing;
using FakePowerPoint.Model.Commands;
using FakePowerPoint.Model.Enums;
using FakePowerPoint.Model.Shape;
using FakePowerPoint.Properties;

namespace FakePowerPoint.Presentation.PM
{
    public partial class PresentationModel
    {
        Model.Model _model;
        public PresentationModel(Model.Model model)
        {
            _model = model;
            _coordinates = null;
            _slidePanelRectangle = new Rectangle(0, 0, int.Parse(Resources.DEFAULT_SLIDE_WIDTH), int.Parse(Resources.DEFAULT_SLIDE_HEIGHT));
            InitializeSelectionShape();
            InitializeDo();
        }

        public void AddShape(ShapeType shapeType)
        {
            var command = new AddShape(_model, shapeType);
            command.Execute();
            Dos[0] = true;
            _undo.Clear();
            Dos[1] = false;
            _command.Push(command);
            Repaint();
        }

        public void RemoveShape(int index)
        {
            var command = new RemoveShape(_model, index);
            command.Execute();
            Dos[0] = true;
            _undo.Clear();
            Dos[1] = false;
            _command.Push(command);
            Repaint();
        }

        public void Resize(Rectangle slidePanelSize)
        {
            _slidePanelRectangle = slidePanelSize;
            // _model.Resize();
        }
    }
}
