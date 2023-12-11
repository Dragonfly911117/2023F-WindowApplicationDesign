namespace FakePowerPoint.Model.Commands
{
    public class RemoveShape : Commands.Command
    {
        private int _index;
        private Shape.Shape _shape;

        public RemoveShape(Model receiver, int index)
            : base(receiver)
        {
            _index = index;
            _shape = Receiver.GetShapes()[index];
        }

        public override void Execute()
        {
            Receiver.RemoveShape(_index);
        }

        public override void UnExecute()
        {
            Receiver.AddShape(_shape.GetShapeType(), _shape.GetCoordinates(), _shape.GetColor(), _index);
        }
    }
}
