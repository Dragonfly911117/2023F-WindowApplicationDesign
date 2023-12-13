using System.Drawing;

namespace FakePowerPoint.Model.Commands
{
    public class MoveShape : Command
    {
        int _index;
        Size _offset;
        public MoveShape(Model receiver, int index, Size offset)
            : base(receiver)
        {
            _index = index;
            _offset = offset;
        }

        public override void Execute()
        {
            Receiver.MoveShape(_index, _offset);
        }

        public override void UnExecute()
        {
            Receiver.MoveShape(_index, new Size(-_offset.Width, -_offset.Height));
        }
    }
}
