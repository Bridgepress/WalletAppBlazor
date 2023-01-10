using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WalletApp.Client.DTO.AppUser;
using WalletApp.CommandAndQuery.User.UserCreate;
using WalletApp.CommandAndQuery.User.UserLogin;
using WalletApp.CommandAndQuery.User.UserLogout;
using WalletApp.Data.DTO.AppUser;

namespace WalletApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AppUserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> registerUser([FromBody] ApiRegisterDTO request)
        {
            var user = await _mediator.Send(new RegisterUserCommand(request.Name, request.Password));
            if (user == null)
            {
                return Unauthorized();
            }
            return Created(string.Empty, user);
        }

        [HttpPost("Login")]
        public async Task<UserDTO> loginUser([FromBody] LoginDTO request)
        {
            var user = await _mediator.Send(new LoginUserCommand(request.Name, request.Password));
            return user;
        }

        [HttpPost("Logout")]
        public async Task logout()
        {
            await _mediator.Send(new LogoutUserCommand());
        }
    }
}
