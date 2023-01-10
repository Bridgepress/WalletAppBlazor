using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletApp.CommandAndQuery.FlowMoney.GetDecimalFlowMoneyPerDateBaginDateEnd;
using WalletApp.CommandAndQuery.Queries;
using WalletApp.Domain.Interfaces;

namespace WalletApp.CommandAndQuery.FlowMoney.GetDecimalFlowMoneyPerDay
{
    public class GetDecimalFlowMoneyPerDayQueryHandler : IQueryHandler<GetDecimalFlowMoneyPerDayQuery, decimal>
    {
        private readonly IMediator _mediator;
        private readonly IFlowMoneyService _flowMoneyService;

        public GetDecimalFlowMoneyPerDayQueryHandler(IMediator mediator, IFlowMoneyService flowMoneyService)
        {
            _flowMoneyService = flowMoneyService;
            _mediator = mediator;
        }

        public async Task<decimal> Handle(GetDecimalFlowMoneyPerDayQuery request, CancellationToken cancellationToken)
        {
            return await _flowMoneyService.GetDecimalFlowMoneyPerDate(request.Date);
        }
    }
}
