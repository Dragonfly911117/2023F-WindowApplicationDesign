using FakePowerPoint.Model.Enums;

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
    }
}
