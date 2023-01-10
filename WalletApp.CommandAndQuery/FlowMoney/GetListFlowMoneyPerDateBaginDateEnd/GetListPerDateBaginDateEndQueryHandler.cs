using MediatR;
using WalletApp.Client.DTO.FlowMoney;
using WalletApp.CommandAndQuery.Queries;
using WalletApp.Domain.Interfaces;

namespace WalletApp.CommandAndQuery.FlowMoney.GetListFlowMoneyPerDateBaginDateEnd
{
    public class GetListPerDateBaginDateEndQueryHandler : IQueryHandler<GetListPerDateBaginDateEndQuery, IEnumerable<FlowMoneyDetailsDTO>>
    {
        private readonly IMediator _mediator;
        private readonly IFlowMoneyService _flowMoneyService;

        public GetListPerDateBaginDateEndQueryHandler(IMediator mediator, IFlowMoneyService flowMoneyService)
        {
            _flowMoneyService = flowMoneyService;
            _mediator = mediator;
        }

        public async Task<IEnumerable<FlowMoneyDetailsDTO>> Handle(GetListPerDateBaginDateEndQuery request, CancellationToken cancellationToken)
        {
            return await _flowMoneyService.GetListFlowMoneyPerDateBaginDateEnd(request.DateBegin, request.DateEnd);
        }
    }
}
