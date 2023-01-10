using MediatR;
using WalletApp.Client.DTO.AppUser;
using WalletApp.CommandAndQuery.Commands;
using WalletApp.Domain.Interfaces;

namespace WalletApp.CommandAndQuery.User.UserLogin
{
    public class LoginUserCommandHandler : ICommandHandler<LoginUserCommand, UserDTO>
    {
        private readonly IMediator _mediator;
        private readonly IAppUserService _appUserService;

        public LoginUserCommandHandler(IMediator mediator, IAppUserService appUserService)
        {
            _appUserService = appUserService;
            _mediator = mediator;
        }

        public async Task<UserDTO> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = new LoginDTO { Name = request.Name, Password = request.Password };
            return await _appUserService.LoginAsync(user);
        }
    }
}
