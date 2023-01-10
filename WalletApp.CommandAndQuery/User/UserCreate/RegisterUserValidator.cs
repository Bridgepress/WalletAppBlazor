using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletApp.CommandAndQuery.FlowMoney.CreateFlowMoney;

namespace WalletApp.CommandAndQuery.User.UserCreate
{
    internal class RegisterUserValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserValidator()
        {
            RuleFor(s => s.Name)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(20);
            RuleFor(s => s.Password)
                .NotEmpty()
                .MinimumLength(6);
        }
    }
}
