using WalletApp.Client.DTO.FlowMoney;
using WalletApp.CommandAndQuery.Commands;

namespace WalletApp.CommandAndQuery.FlowMoney.CreateFlowMoney
{
    public class DeleteFlowMoneyCommand : BaseCommand<FlowMoneyDTO>
    {
        public Guid Id { get; }

        public DeleteFlowMoneyCommand(Guid id)
        {
            Id = id;
        }
    }
}
