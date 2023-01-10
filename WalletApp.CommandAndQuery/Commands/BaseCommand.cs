using System.Windows.Input;

namespace WalletApp.CommandAndQuery.Commands
{
    public abstract class BaseCommand : ICommand
    {
        public Guid Id { get; }

        public BaseCommand()
        {
            Id = Guid.NewGuid();
        }

        protected BaseCommand(Guid Id)
        {
            this.Id = Id;
        }
    }

    public abstract class BaseCommand<TResult> : ICommand<TResult>
    {
        public Guid Id { get; }

        protected BaseCommand()
        {
            this.Id = Guid.NewGuid();
        }

        protected BaseCommand(Guid id)
        {
            Id = id;
        }
    }
}
