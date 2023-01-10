using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletApp.CommandAndQuery.Queries;

namespace WalletApp.CommandAndQuery.Income.GetDecimalIncomePerDate
{
    public class GetDecimalPerDateQuery : IQuery<decimal>
    {
        public DateTime Date { get; }

        public GetDecimalPerDateQuery(DateTime date)
        {
            Date = date;
        }
    }
}
