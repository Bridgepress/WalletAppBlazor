using WalletApp.CommandAndQuery.Queries;
using WalletApp.Domain.DTO.TypeOfExpense;

namespace WalletApp.CommandAndQuery.TypeOfExpense.GetAllTypeOfExpense
{
    public class GetAllTypeOfExpenseQuery : IQuery<IEnumerable<TypeOfExpenseDetatilsDTO>>
    {
        public GetAllTypeOfExpenseQuery()
        {
        }
    }
}
