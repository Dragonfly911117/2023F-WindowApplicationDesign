namespace FakePowerPoint.Presentation.PM
{
    public partial class PresentationModel
    {
        Model.Model _model;
        public PresentationModel(Model.Model model)
        {
            _model = model;
        }

        public void AddShape(string shapeSelectorText)
        {
            _model.AddShape(shapeSelectorText);
        }
    }
}
