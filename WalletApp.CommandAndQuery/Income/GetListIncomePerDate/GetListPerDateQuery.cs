using WalletApp.Client.DTO.Income;
using WalletApp.CommandAndQuery.Queries;

namespace WalletApp.CommandAndQuery.Income.GetListIncomePerDate
{
    public class GetListPerDateQuery : IQuery<IEnumerable<IncomeDetailsDTO>>
    {
        public DateTime Date { get; }

        public GetListPerDateQuery(DateTime date)
        {
            Date = date;
        }
    }
}
