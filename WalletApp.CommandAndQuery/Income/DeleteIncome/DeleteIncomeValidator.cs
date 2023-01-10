using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletApp.CommandAndQuery.Income.CreateIncome;

namespace WalletApp.CommandAndQuery.Income.DeleteIncome
{
    public class DeleteIncomeValidator : AbstractValidator<DeleteIncomeCommand>
    {
        public DeleteIncomeValidator()
        {
            RuleFor(s => s.Id).Must((id) => id != Guid.Empty);
        }
    }
}
