using MediatR;
using WalletApp.Client.DTO.TypeOfExpense;
using WalletApp.CommandAndQuery.Commands;
using WalletApp.Domain.Interfaces;

namespace WalletApp.CommandAndQuery.TypeOfExpense.DeleteTypeOfExpense
{
    public class DeleteTypeOfExpenseCommandHandler : ICommandHandler<DeleteTypeOfExpenseCommand, TypeOfExpenseDTO>
    {
        private readonly IMediator _mediator;
        private readonly ITypeOfExpenseService _typeOfExpenseService;

        public DeleteTypeOfExpenseCommandHandler(IMediator mediator, ITypeOfExpenseService typeOfExpenseService)
        {
            _typeOfExpenseService = typeOfExpenseService;
            _mediator = mediator;
        }

        public async Task<TypeOfExpenseDTO> Handle(DeleteTypeOfExpenseCommand request, CancellationToken cancellationToken)
        {
            var typeOfExpenseDTO = new DeleteTypeOfExpenseDTO { Id = request.Id };
            return await _typeOfExpenseService.DeleteAsync(typeOfExpenseDTO.Id);
        }
    }
}
