using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletApp.Data.DTO.AppUser
{
    public class ApiRegisterDTO
    {
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string Name { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 4)]
        public string Password { get; set; }

    }
}
