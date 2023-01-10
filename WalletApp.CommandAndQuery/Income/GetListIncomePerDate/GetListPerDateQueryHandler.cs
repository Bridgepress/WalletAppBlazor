using MediatR;
using WalletApp.Client.DTO.Income;
using WalletApp.CommandAndQuery.Queries;
using WalletApp.Domain.Interfaces;

namespace WalletApp.CommandAndQuery.Income.GetListIncomePerDate
{
    public class GetListPerDateQueryHandler : IQueryHandler<GetListPerDateQuery, IEnumerable<IncomeDetailsDTO>>
    {
        private readonly IMediator _mediator;
        private readonly IIncomeService _incomeService;

        public GetListPerDateQueryHandler(IMediator mediator, IIncomeService incomeService)
        {
            _incomeService = incomeService;
            _mediator = mediator;
        }

        public async Task<IEnumerable<IncomeDetailsDTO>> Handle(GetListPerDateQuery request, CancellationToken cancellationToken)
        {
            return await _incomeService.GetListIncomePerDate(request.Date);
        }
    }
}
