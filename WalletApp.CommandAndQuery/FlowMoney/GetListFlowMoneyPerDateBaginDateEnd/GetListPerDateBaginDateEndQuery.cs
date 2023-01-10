using WalletApp.Client.DTO.FlowMoney;
using WalletApp.CommandAndQuery.Queries;

namespace WalletApp.CommandAndQuery.FlowMoney.GetListFlowMoneyPerDateBaginDateEnd
{
    public class GetListPerDateBaginDateEndQuery : IQuery<IEnumerable<FlowMoneyDetailsDTO>>
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
