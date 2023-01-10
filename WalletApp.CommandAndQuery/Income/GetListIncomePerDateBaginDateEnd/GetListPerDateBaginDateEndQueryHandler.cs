using MediatR;
using WalletApp.Client.DTO.Income;
using WalletApp.CommandAndQuery.Queries;
using WalletApp.Domain.Interfaces;

namespace WalletApp.CommandAndQuery.Income.GetListIncomePerDateBaginDateEnd
{
    public class GetListPerDateBaginDateEndQueryHandler : IQueryHandler<GetListPerDateBaginDateEndQuery, IEnumerable<IncomeDetailsDTO>>
    {
        private readonly IMediator _mediator;
        private readonly IIncomeService _incomeService;

        public GetListPerDateBaginDateEndQueryHandler(IMediator mediator, IIncomeService incomeService)
        {
            _incomeService = incomeService;
            _mediator = mediator;
        }

        public async Task<IEnumerable<IncomeDetailsDTO>> Handle(GetListPerDateBaginDateEndQuery request, CancellationToken cancellationToken)
        {
            return await _incomeService.GetListIncomePerDateBaginDateEnd(request.DateBegin, request.DateEnd);
        }
    }
}
