using MediatR;
using WalletApp.Client.DTO.FlowMoney;
using WalletApp.CommandAndQuery.Commands;
using WalletApp.Domain.Interfaces;

namespace WalletApp.CommandAndQuery.FlowMoney.CreateFlowMoney
{
    public class CreateFlowMoneyCommandHandler : ICommandHandler<CreateFlowMoneyCommand, CreateFlowMoneyDTO>
    {
        private readonly IMediator _mediator;
        private readonly IFlowMoneyService _flowMoneyService;

        public CreateFlowMoneyCommandHandler(IMediator mediator, IFlowMoneyService flowMoneyService)
        {
            _flowMoneyService = flowMoneyService;
            _mediator = mediator;
        }

        public async Task<CreateFlowMoneyDTO> Handle(CreateFlowMoneyCommand request, CancellationToken cancellationToken)
        {
            var flowMoney = new CreateFlowMoneyDTO { TypeOfExpenseId = request.TypeOfExpenseId, Amount = request.Amount, Comment = request.Comment, Date = request.Date };
            return await _flowMoneyService.AddAsync(flowMoney);
        }
    }
}
