using System.Drawing;
using FakePowerPoint.Model.Commands;
using FakePowerPoint.Model.Enums;
using FakePowerPoint.Model.Shape;

namespace FakePowerPoint.Presentation.PM
{
    public partial class PresentationModel
    {
        Model.Model _model;
        public PresentationModel(Model.Model model)
        {
            _model = model;
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

        public void Resize(Size slidePanelSize)
        {
            _slidePanelSize = slidePanelSize;
            _model.Resize();
        }
    }
}
