using MediatR;
using WalletApp.Client.DTO.TypeIncome;
using WalletApp.CommandAndQuery.Commands;
using WalletApp.Domain.Interfaces;

namespace WalletApp.CommandAndQuery.TypeIncome.CreateTypeIncome
{
    public class CreateTypeIncomeCommandHandler : ICommandHandler<CreateTypeIncomeCommand, TypeIncomeDTO>
    {
        private readonly IMediator _mediator;
        private readonly ITypeIncomeService _typeIncomeService;

        public CreateTypeIncomeCommandHandler(IMediator mediator, ITypeIncomeService typeIncomeService)
        {
            _typeIncomeService = typeIncomeService;
            _mediator = mediator;
        }

        public async Task<TypeIncomeDTO> Handle(CreateTypeIncomeCommand request, CancellationToken cancellationToken)
        {
            var typeIncome = new TypeIncomeDTO { Name = request.Name };
            return await _typeIncomeService.AddAsync(typeIncome);
        }
    }
}
