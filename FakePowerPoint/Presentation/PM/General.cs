using System;
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
            this._coordinates = null;
            _slidePanelRectangle = new Rectangle(0, 0, int.Parse(Resources.DEFAULT_SLIDE_WIDTH), int.Parse(Resources.DEFAULT_SLIDE_HEIGHT));
            InitializeSelectionShape();
        }

        public void AddShape(ShapeType shapeType)
        {
            var command = new AddShape(_model, shapeType);
            command.Execute();
            _undo.Clear();
            _command.Push(command);
            Repaint();
        }

        public void RemoveShape(int index)
        {
            var command = new RemoveShape(_model, index);
            command.Execute();
            _undo.Clear();
            _command.Push(command);
            Repaint();
        }

        public void Resize(Rectangle slidePanelSize)
        {
            _slidePanelRectangle = slidePanelSize;
            _model.Resize();
        }
    }
}
