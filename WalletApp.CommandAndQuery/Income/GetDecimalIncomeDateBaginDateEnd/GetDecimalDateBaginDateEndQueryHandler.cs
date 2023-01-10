using MediatR;
using WalletApp.CommandAndQuery.Queries;
using WalletApp.Domain.Interfaces;

namespace WalletApp.CommandAndQuery.Income.GetDecimalIncomeDateBaginDateEnd
{
    internal class GetDecimalDateBaginDateEndQueryHandler : IQueryHandler<GetDecimalDateBaginDateEndQuery, decimal>
    {
        private readonly IMediator _mediator;
        private readonly IIncomeService _incomeService;

        public GetDecimalDateBaginDateEndQueryHandler(IMediator mediator, IIncomeService incomeService)
        {
            _incomeService = incomeService;
            _mediator = mediator;
        }

        public async Task<decimal> Handle(GetDecimalDateBaginDateEndQuery request, CancellationToken cancellationToken)
        {
            return await _incomeService.GetDecimalIncomeDateBaginDateEnd(request.DateBegin, request.DateEnd);
        }
    }
}
