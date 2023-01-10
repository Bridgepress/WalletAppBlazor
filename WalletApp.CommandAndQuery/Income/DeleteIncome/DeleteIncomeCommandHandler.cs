using MediatR;
using WalletApp.Client.DTO.Income;
using WalletApp.CommandAndQuery.Commands;
using WalletApp.Domain.Interfaces;

namespace WalletApp.CommandAndQuery.Income.DeleteIncome
{
    internal class DeleteIncomeCommandHandler : ICommandHandler<DeleteIncomeCommand, IncomeDTO>
    {
        private readonly IMediator _mediator;
        private readonly IIncomeService _incomeService;

        public DeleteIncomeCommandHandler(IMediator mediator, IIncomeService incomeService)
        {
            _incomeService = incomeService;
            _mediator = mediator;
        }

        public async Task<IncomeDTO> Handle(DeleteIncomeCommand request, CancellationToken cancellationToken)
        {
            return await _incomeService.DeleteAsync(request.Id);
        }
    }
}
