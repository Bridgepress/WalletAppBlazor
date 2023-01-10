using MediatR;
using WalletApp.Client.DTO.FlowMoney;
using WalletApp.CommandAndQuery.Queries;
using WalletApp.Domain.Interfaces;

namespace WalletApp.CommandAndQuery.FlowMoney.GetListFlowMoneyPerDay
{
    public class GetListFlowMoneyPerDayQueryHandler : IQueryHandler<GetListFlowMoneyPerDayQuery, IEnumerable<FlowMoneyDetailsDTO>>
    {
        private readonly IMediator _mediator;
        private readonly IFlowMoneyService _flowMoneyService;

        public GetListFlowMoneyPerDayQueryHandler(IMediator mediator, IFlowMoneyService flowMoneyService)
        {
            _flowMoneyService = flowMoneyService;
            _mediator = mediator;
        }

        public async Task<IEnumerable<FlowMoneyDetailsDTO>> Handle(GetListFlowMoneyPerDayQuery request, CancellationToken cancellationToken)
        {
            return await _flowMoneyService.GetListFlowMoneyPerDate(request.Date);
        }
    }
}
