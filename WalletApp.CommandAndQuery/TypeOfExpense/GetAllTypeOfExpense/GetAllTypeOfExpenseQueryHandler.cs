using MediatR;
using WalletApp.CommandAndQuery.Queries;
using WalletApp.Domain.DTO.TypeOfExpense;
using WalletApp.Domain.Interfaces;

namespace WalletApp.CommandAndQuery.TypeOfExpense.GetAllTypeOfExpense
{
    public class GetAllTypeOfExpenseQueryHandler : IQueryHandler<GetAllTypeOfExpenseQuery, IEnumerable<TypeOfExpenseDetatilsDTO>>
    {
        private readonly IMediator _mediator;
        private readonly ITypeOfExpenseService _typeOfExpenseService;

        public GetAllTypeOfExpenseQueryHandler(IMediator mediator, ITypeOfExpenseService typeOfExpenseService)
        {
            _typeOfExpenseService = typeOfExpenseService;
            _mediator = mediator;
        }

        public async Task<IEnumerable<TypeOfExpenseDetatilsDTO>> Handle(GetAllTypeOfExpenseQuery request, CancellationToken cancellationToken)
        {
            return await _typeOfExpenseService.GetAllEnumerable();
        }
    }
}
