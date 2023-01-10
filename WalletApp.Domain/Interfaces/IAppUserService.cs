using WalletApp.Client.DTO.AppUser;

namespace WalletApp.Domain.Interfaces
{
    public interface IAppUserService
    {
        Task<UserDTO> AddAsync(RegisterDTO user);

        Task<UserDTO> LoginAsync(LoginDTO user);

        Task Logout();

        Task<bool> UserExists(string name);
    }
}
