using System.ComponentModel.DataAnnotations;

namespace WalletApp.Client.DTO.AppUser
{
    public class CreateAppUserDTO
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string Name { get; set; } = default!;
        [StringLength(20, MinimumLength = 4)]
        public byte[] PasswordHash { get; set; } = default!;
        [StringLength(20, MinimumLength = 4)]
        public byte[] PasswordSalt { get; set; } = default!;
    }
}
