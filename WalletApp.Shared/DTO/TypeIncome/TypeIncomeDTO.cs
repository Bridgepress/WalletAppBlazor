﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletApp.Client.DTO.TypeIncome
{
    public class TypeIncomeDTO
    {
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string Name { get; set; } = default!;
    }
}
