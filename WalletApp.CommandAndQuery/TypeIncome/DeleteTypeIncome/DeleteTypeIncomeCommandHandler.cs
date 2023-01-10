using MediatR;
using WalletApp.Client.DTO.TypeIncome;
using WalletApp.CommandAndQuery.Commands;
using WalletApp.Domain.Interfaces;

namespace WalletApp.CommandAndQuery.TypeIncome.DeleteTypeIncome
{
    public class DeleteTypeIncomeCommandHandler : ICommandHandler<DeleteTypeIncomeCommand, TypeIncomeDTO>
    {
        private readonly IMediator _mediator;
        private readonly ITypeIncomeService _service;

        public DeleteTypeIncomeCommandHandler(IMediator mediator, ITypeIncomeService service)
        {
            _service = service;
            _mediator = mediator;
        }

        public async Task<TypeIncomeDTO> Handle(DeleteTypeIncomeCommand request, CancellationToken cancellationToken)
        {
            var typeIncome = new DeleteTypeIncomeDTO { Id = request.Id };
            return await _service.DeleteAsync(typeIncome.Id);
        }
    }
}
