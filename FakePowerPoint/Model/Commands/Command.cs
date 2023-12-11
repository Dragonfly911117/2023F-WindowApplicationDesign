namespace FakePowerPoint.Model.Commands
{
    public abstract class Command
    {
        protected Model Receiver;

        protected Command(Model receiver)
        {
            Receiver = receiver;
        }

        public abstract void Execute();
        public abstract void UnExecute();
    }
}
