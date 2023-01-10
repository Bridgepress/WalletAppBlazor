using WalletApp.Client.DTO.AppUser;
using WalletApp.CommandAndQuery.Commands;

namespace WalletApp.CommandAndQuery.User.UserCreate
{
    public class RegisterUserCommand : BaseCommand<UserDTO>
    {
        public string Name { get; }
        public string Password { get; }

        public RegisterUserCommand(string name, string password)
        {
            Name = name;
            Password = password;
        }
    }
}
