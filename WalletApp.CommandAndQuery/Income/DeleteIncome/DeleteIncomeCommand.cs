using WalletApp.Client.DTO.Income;
using WalletApp.CommandAndQuery.Commands;

namespace WalletApp.CommandAndQuery.Income.DeleteIncome
{
    public class DeleteIncomeCommand : BaseCommand<IncomeDTO>
    {
        public Guid Id { get; }

        public DeleteIncomeCommand(Guid id)
        {
            Id = id;
        }
    }
}
