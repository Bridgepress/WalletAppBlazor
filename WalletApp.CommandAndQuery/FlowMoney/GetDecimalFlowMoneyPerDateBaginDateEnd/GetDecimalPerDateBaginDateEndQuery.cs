using WalletApp.CommandAndQuery.Queries;

namespace WalletApp.CommandAndQuery.FlowMoney.GetDecimalFlowMoneyPerDateBaginDateEnd
{
    public class GetDecimalPerDateBaginDateEndQuery : IQuery<decimal>
    {
        public DateTime DateBegin { get; }
        public DateTime DateEnd { get; }

        public GetDecimalPerDateBaginDateEndQuery(DateTime dateBegin, DateTime dateEnd)
        {
            DateBegin = dateBegin;
            DateEnd = dateEnd;
        }
    }
}
