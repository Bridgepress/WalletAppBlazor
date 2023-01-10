using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletApp.CommandAndQuery.FlowMoney.GetDecimalFlowMoneyPerDay;
using WalletApp.CommandAndQuery.Queries;
using WalletApp.Domain.Interfaces;

namespace WalletApp.CommandAndQuery.Income.GetDecimalIncomePerDate
{
    internal class GetDecimalPerDateQueryHandler : IQueryHandler<GetDecimalPerDateQuery, decimal>
    {
        private readonly IMediator _mediator;
        private readonly IIncomeService _incomeService;

        public GetDecimalPerDateQueryHandler(IMediator mediator, IIncomeService incomeService)
        {
            _incomeService = incomeService;
            _mediator = mediator;
        }

        public async Task<decimal> Handle(GetDecimalPerDateQuery request, CancellationToken cancellationToken)
        {
            return await _incomeService.GetDecimalIncomePerDate(request.Date);
        }
    }
}
