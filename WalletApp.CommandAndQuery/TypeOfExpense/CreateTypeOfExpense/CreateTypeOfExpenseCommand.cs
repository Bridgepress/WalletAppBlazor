using WalletApp.Client.DTO.TypeOfExpense;
using WalletApp.CommandAndQuery.Commands;

namespace WalletApp.CommandAndQuery.TypeOfExpense.CreateTypeOfExpense
{
    public class CreateTypeOfExpenseCommand : BaseCommand<TypeOfExpenseDTO>
    {
        public string Name { get; }

        public CreateTypeOfExpenseCommand(string name)
        {
            Name = name;
        }
    }
}
