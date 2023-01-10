using MediatR;
using WalletApp.Client.DTO.TypeIncome;
using WalletApp.CommandAndQuery.Queries;
using WalletApp.Domain.Interfaces;

namespace WalletApp.CommandAndQuery.TypeIncome.GetAllTypeIncome
{
    public class GetAllTypeIncomeQueryHandler : IQueryHandler<GetAllTypeIncomeQuery, IEnumerable<TypeIncomeDetailsDTO>>
    {
        private readonly IMediator _mediator;
        private readonly ITypeIncomeService _service;

        public GetAllTypeIncomeQueryHandler(IMediator mediator, ITypeIncomeService service)
        {
            _service = service;
            _mediator = mediator;
        }

        public async Task<IEnumerable<TypeIncomeDetailsDTO>> Handle(GetAllTypeIncomeQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetAllEnumerable();
        }
    }
}
