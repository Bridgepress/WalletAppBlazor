using WalletApp.Data.Entities;

namespace WalletApp.Domain.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(AppUser user);
    }
}
