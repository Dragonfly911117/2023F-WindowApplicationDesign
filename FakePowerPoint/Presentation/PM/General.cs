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
        }

        public void AddShape(ShapeType shapeType)
        {
            _model.AddShape(shapeType);
            Repaint();
        }

        public void RemoveShape(int index)
        {
            _model.RemoveShape(index);
            Repaint();
        }
    }
}
