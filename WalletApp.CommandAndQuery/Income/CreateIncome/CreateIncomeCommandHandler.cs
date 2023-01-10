using MediatR;
using WalletApp.Client.DTO.Income;
using WalletApp.CommandAndQuery.Commands;
using WalletApp.Domain.Interfaces;

namespace WalletApp.CommandAndQuery.Income.CreateIncome
{
    public class CreateIncomeCommandHandler : ICommandHandler<CreateIncomeCommand, CreateIncomeDTO>
    {
        private readonly IMediator _mediator;
        private readonly IIncomeService _incomeService;

        public CreateIncomeCommandHandler(IMediator mediator, IIncomeService incomeService)
        {
            _incomeService = incomeService;
            _mediator = mediator;
        }

        public async Task<CreateIncomeDTO> Handle(CreateIncomeCommand request, CancellationToken cancellationToken)
        {
            var income = new CreateIncomeDTO { TypeIncomeId = request.TypeIncomeId, Amount = request.Amount, Comment = request.Comment, Date = request.Date };
            return await _incomeService.AddAsync(income);
        }
    }
}

