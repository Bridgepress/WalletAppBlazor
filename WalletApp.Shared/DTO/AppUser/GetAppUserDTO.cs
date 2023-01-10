

namespace WalletApp.Client.DTO.AppUser
{
    public class GetAppUserDTO 
    {
        public string Name { get; set; } = default!;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
