using WalletApp.Client.DTO.TypeIncome;
using WalletApp.CommandAndQuery.Commands;

namespace WalletApp.CommandAndQuery.TypeIncome.DeleteTypeIncome
{
    public class DeleteTypeIncomeCommand : BaseCommand<TypeIncomeDTO>
    {
        public Guid Id { get; }

        public DeleteTypeIncomeCommand(Guid id)
        {
            Id = id;
        }
    }
}
