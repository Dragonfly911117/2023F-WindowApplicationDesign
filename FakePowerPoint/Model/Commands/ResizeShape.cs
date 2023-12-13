using System;
using System.Drawing;
using FakePowerPoint.Model.Enums;

namespace FakePowerPoint.Model.Commands
{
    public class ResizeShape : Command
    {
        int _index;
        Size _size;
        HandlePosition _handlePosition;

        public ResizeShape(Model receiver, int index, Size size, HandlePosition handlePosition): base(receiver)
        {
            _index = index;
            _size = size;
            _handlePosition = handlePosition;
        }

        public override void Execute()
        {
            Receiver.ResizeShape(_index, _size, _handlePosition);
        }

        public override void UnExecute()
        {
            Receiver.ResizeShape(_index, new Size(-_size.Width, -_size.Height), _handlePosition);
        }
    }
}
