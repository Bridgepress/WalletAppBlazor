using WalletApp.Client.DTO.Income;
using WalletApp.CommandAndQuery.Queries;

namespace WalletApp.CommandAndQuery.Income.GetListIncomePerDateBaginDateEnd
{
    public class GetListPerDateBaginDateEndQuery : IQuery<IEnumerable<IncomeDetailsDTO>>
    {
        public DateTime DateBegin { get; }
        public DateTime DateEnd { get; }

        public GetListPerDateBaginDateEndQuery(DateTime dateBegin, DateTime dateEnd)
        {
            DateBegin = dateBegin;
            DateEnd = dateEnd;
        }
    }
}
