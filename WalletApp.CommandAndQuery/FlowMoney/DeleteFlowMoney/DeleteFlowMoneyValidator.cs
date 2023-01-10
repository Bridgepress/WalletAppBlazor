using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletApp.CommandAndQuery.FlowMoney.CreateFlowMoney;

namespace WalletApp.CommandAndQuery.FlowMoney.DeleteFlowMoney
{
    public class DeleteFlowMoneyValidator : AbstractValidator<DeleteFlowMoneyCommand>
    {
        public DeleteFlowMoneyValidator()
        {
            RuleFor(s=>s.Id).Must((id)=>id!=Guid.Empty);
        }
    }
}
