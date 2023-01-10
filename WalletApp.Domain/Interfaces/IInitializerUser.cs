using WalletApp.Data.Entities;

namespace WalletApp.Domain.Interfaces
{
    public interface IInitializerUser
    {
        public Task Initialize(AppUser appUser);
    }
}
