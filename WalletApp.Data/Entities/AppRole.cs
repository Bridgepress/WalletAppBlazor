using Microsoft.AspNetCore.Identity;

namespace WalletApp.Data.Entities
{ 
    public class AppRole : IdentityRole<Guid>
    {
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}
