using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletApp.CommandAndQuery.Queries;

namespace WalletApp.CommandAndQuery.Income.GetDecimalIncomeDateBaginDateEnd
{
    public class GetDecimalDateBaginDateEndQuery : IQuery<decimal>
    {
        public DateTime DateBegin { get; }
        public DateTime DateEnd { get; }

        public GetDecimalDateBaginDateEndQuery(DateTime dateBegin, DateTime dateEnd)
        {
            DateBegin = dateBegin;
            DateEnd = dateEnd;
        }
    }
}
