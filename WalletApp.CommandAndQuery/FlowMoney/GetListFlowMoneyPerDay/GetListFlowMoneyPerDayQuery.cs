using WalletApp.Client.DTO.FlowMoney;
using WalletApp.CommandAndQuery.Queries;

namespace WalletApp.CommandAndQuery.FlowMoney.GetListFlowMoneyPerDay
{
    public class GetListFlowMoneyPerDayQuery : IQuery<IEnumerable<FlowMoneyDetailsDTO>>
    {
        public DateTime Date { get; }

        public GetListFlowMoneyPerDayQuery(DateTime date)
        {
            Date = date;
        }
    }
}
