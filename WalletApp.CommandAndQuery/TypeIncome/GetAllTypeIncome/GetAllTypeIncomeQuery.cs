using WalletApp.Client.DTO.TypeIncome;
using WalletApp.CommandAndQuery.Queries;

namespace WalletApp.CommandAndQuery.TypeIncome.GetAllTypeIncome
{
    public class GetAllTypeIncomeQuery : IQuery<IEnumerable<TypeIncomeDetailsDTO>>
    {
        public GetAllTypeIncomeQuery()
        {
        }
    }
}
