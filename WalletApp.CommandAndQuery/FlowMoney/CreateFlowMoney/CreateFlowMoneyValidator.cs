using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletApp.CommandAndQuery.FlowMoney.CreateFlowMoney
{
    internal class CreateFlowMoneyValidator : AbstractValidator<CreateFlowMoneyCommand>
    {
        public CreateFlowMoneyValidator()
        {
            RuleFor(s => s.TypeOfExpenseId).NotEmpty();
            RuleFor(s => s.Date).NotEmpty();
        }
    }
}
