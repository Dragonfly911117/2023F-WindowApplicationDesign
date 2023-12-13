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
            Dos[0] = _command.Count != 0;
            Dos[1] = true;
            Repaint();
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
            Dos[0] = true;
            Dos[1] = _undo.Count != 0;
            Repaint();

        }
    }
}
