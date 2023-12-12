using System.Collections.Generic;
using FakePowerPoint.Model.Commands;

namespace FakePowerPoint.Presentation.PM
{
    public partial class PresentationModel
    {
        readonly Stack<Command> _command = new();
        readonly Stack<Command> _undo = new();

        public void Undo()
        {
            if (_command.Count == 0)
            {
                return;
            }
            var command = _command.Pop();
            command.UnExecute();
            _undo.Push(command);
            _dos[0] = _command.Count != 0;
            _dos[1] = true;
        }

        public void Redo()
        {
            if (_undo.Count == 0)
            {
                return;
            }
            var command = _undo.Pop();
            command.Execute();
            _command.Push(command);
            _dos[0] = true;
            _dos[1] = _undo.Count != 0;

        }
    }
}
