using WalletApp.Client.DTO.AppUser;
using WalletApp.CommandAndQuery.Commands;

namespace WalletApp.CommandAndQuery.User.UserLogin
{
    public class LoginUserCommand : BaseCommand<UserDTO>
    {
        public string Name { get; }
        public string Password { get; }

        public LoginUserCommand(string name, string password)
        {
            Name = name;
            Password = password;
        }
    }
}
