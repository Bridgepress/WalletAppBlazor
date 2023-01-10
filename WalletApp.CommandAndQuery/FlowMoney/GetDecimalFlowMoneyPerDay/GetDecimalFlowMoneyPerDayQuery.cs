using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletApp.CommandAndQuery.Queries;

namespace WalletApp.CommandAndQuery.FlowMoney.GetDecimalFlowMoneyPerDay
{
    public class GetDecimalFlowMoneyPerDayQuery : IQuery<decimal>
    {
        public DateTime Date { get; }

        public GetDecimalFlowMoneyPerDayQuery(DateTime date)
        {
            Date = date;
        }
    }
}
