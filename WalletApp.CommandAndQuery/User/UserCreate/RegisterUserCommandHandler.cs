using MediatR;
using WalletApp.Client.DTO.AppUser;
using WalletApp.CommandAndQuery.Commands;
using WalletApp.Domain.Interfaces;

namespace WalletApp.CommandAndQuery.User.UserCreate
{
    public class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, UserDTO>
    {
        private readonly IMediator _mediator;
        private readonly IAppUserService _appUserService;

        public RegisterUserCommandHandler(IMediator mediator, IAppUserService appUserService)
        {
            _appUserService = appUserService;
            _mediator = mediator;
        }

        public async Task<UserDTO> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = new RegisterDTO { Name = request.Name, Password = request.Password };
            return await _appUserService.AddAsync(user);
        }
    }
}
