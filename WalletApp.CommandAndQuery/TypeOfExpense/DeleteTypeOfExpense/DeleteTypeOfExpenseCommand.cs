using WalletApp.Client.DTO.TypeOfExpense;
using WalletApp.CommandAndQuery.Commands;

namespace WalletApp.CommandAndQuery.TypeOfExpense.DeleteTypeOfExpense
{
    public class DeleteTypeOfExpenseCommand : BaseCommand<TypeOfExpenseDTO>
    {
        public Guid Id { get; }

        public DeleteTypeOfExpenseCommand(Guid id)
        {
            Id = id;
        }
    }
}
