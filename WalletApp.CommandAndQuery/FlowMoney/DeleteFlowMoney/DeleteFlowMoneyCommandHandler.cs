using MediatR;
using WalletApp.Client.DTO.FlowMoney;
using WalletApp.CommandAndQuery.Commands;
using WalletApp.Domain.Interfaces;

namespace WalletApp.CommandAndQuery.FlowMoney.CreateFlowMoney
{
    public class DeleteFlowMoneyCommandHandler : ICommandHandler<DeleteFlowMoneyCommand, FlowMoneyDTO>
    {
        private readonly IMediator _mediator;
        private readonly IFlowMoneyService _flowMoneyService;

        public DeleteFlowMoneyCommandHandler(IMediator mediator, IFlowMoneyService flowMoneyService)
        {
            _flowMoneyService = flowMoneyService;
            _mediator = mediator;
        }

        public async Task<FlowMoneyDTO> Handle(DeleteFlowMoneyCommand request, CancellationToken cancellationToken)
        {
            return await _flowMoneyService.DeleteAsync(request.Id);
        }
    }
}
