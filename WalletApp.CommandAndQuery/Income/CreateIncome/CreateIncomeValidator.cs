using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletApp.CommandAndQuery.FlowMoney.CreateFlowMoney;

namespace WalletApp.CommandAndQuery.Income.CreateIncome
{
    public class CreateIncomeValidator : AbstractValidator<CreateIncomeCommand>
    {
        public CreateIncomeValidator()
        {
            RuleFor(s => s.TypeIncomeId).NotEmpty();
            RuleFor(s => s.Date).NotEmpty();
        }
    }
}
