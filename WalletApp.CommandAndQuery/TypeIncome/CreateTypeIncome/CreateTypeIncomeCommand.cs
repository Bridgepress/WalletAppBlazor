using WalletApp.Client.DTO.TypeIncome;
using WalletApp.CommandAndQuery.Commands;

namespace WalletApp.CommandAndQuery.TypeIncome.CreateTypeIncome
{
    public class CreateTypeIncomeCommand : BaseCommand<TypeIncomeDTO>
    {
        public string Name { get; }

        public CreateTypeIncomeCommand(string name)
        {
            Name = name;
        }
    }
}
