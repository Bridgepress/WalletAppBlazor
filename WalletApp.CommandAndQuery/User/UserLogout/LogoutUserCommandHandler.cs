using MediatR;
using WalletApp.CommandAndQuery.Commands;
using WalletApp.Domain.Interfaces;

namespace WalletApp.CommandAndQuery.User.UserLogout
{
    public class LogoutUserCommandHandler : ICommandHandler<LogoutUserCommand>
    {
        private readonly IMediator _mediator;
        private readonly IAppUserService _appUserService;

        public LogoutUserCommandHandler(IMediator mediator, IAppUserService appUserService)
        {
            _appUserService = appUserService;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(LogoutUserCommand request, CancellationToken cancellationToken)
        {
            await _appUserService.Logout();
            return Unit.Value;
        }
    }
}
