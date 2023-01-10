using MediatR;
using WalletApp.CommandAndQuery.Queries;
using WalletApp.Domain.Interfaces;

namespace WalletApp.CommandAndQuery.FlowMoney.GetDecimalFlowMoneyPerDateBaginDateEnd
{
    public class GetDecimalPerDateBaginDateEndQueryHandler : IQueryHandler<GetDecimalPerDateBaginDateEndQuery, decimal>
    {
        private readonly IMediator _mediator;
        private readonly IFlowMoneyService _flowMoneyService;

        public GetDecimalPerDateBaginDateEndQueryHandler(IMediator mediator, IFlowMoneyService flowMoneyService)
        {
            _flowMoneyService = flowMoneyService;
            _mediator = mediator;
        }

        public async Task<decimal> Handle(GetDecimalPerDateBaginDateEndQuery request, CancellationToken cancellationToken)
        {
            return await _flowMoneyService.GetDecimalFlowMoneyPerDateBaginDateEnd(request.DateBegin, request.DateEnd);
        }
    }
}
