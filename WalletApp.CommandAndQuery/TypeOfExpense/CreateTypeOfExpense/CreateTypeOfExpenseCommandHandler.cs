using MediatR;
using WalletApp.Client.DTO.TypeOfExpense;
using WalletApp.CommandAndQuery.Commands;
using WalletApp.Domain.Interfaces;

namespace WalletApp.CommandAndQuery.TypeOfExpense.CreateTypeOfExpense
{
    public class CreateTypeOfExpenseCommandHandler : ICommandHandler<CreateTypeOfExpenseCommand, TypeOfExpenseDTO>
    {
        private readonly IMediator _mediator;
        private readonly ITypeOfExpenseService _typeOfExpenseService;

        public CreateTypeOfExpenseCommandHandler(IMediator mediator, ITypeOfExpenseService typeOfExpenseService)
        {
            _typeOfExpenseService = typeOfExpenseService;
            _mediator = mediator;
        }

        public async Task<TypeOfExpenseDTO> Handle(CreateTypeOfExpenseCommand request, CancellationToken cancellationToken)
        {
            var typeOfExpenseDTO = new TypeOfExpenseDTO { Name = request.Name };
            return await _typeOfExpenseService.AddAsync(typeOfExpenseDTO);
        }
    }
}
