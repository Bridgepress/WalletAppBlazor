using System.ComponentModel.DataAnnotations;

namespace WalletApp.Client.DTO.AppUser
{
    public class RegisterDTO
    {
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{4,}$",
            ErrorMessage = "Password should have minimum 8 characters, at least 1 uppercase letter, 1 lowercase letter and 1 number.")]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The password and confirm password fields do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
