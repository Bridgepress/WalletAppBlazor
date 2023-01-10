using WalletApp.Client.DTO.FlowMoney;
using WalletApp.CommandAndQuery.Commands;

namespace WalletApp.CommandAndQuery.FlowMoney.CreateFlowMoney
{
    public class CreateFlowMoneyCommand : BaseCommand<CreateFlowMoneyDTO>
    {
        public Guid TypeOfExpenseId { get; } = default!;
        public decimal Amount { get; }
        public string? Comment { get; }
        public DateTime Date { get; } = default!;

        public CreateFlowMoneyCommand(Guid typeOfExpenseId, decimal amount, string? comment, DateTime date)
        {
            TypeOfExpenseId = typeOfExpenseId;
            Amount = amount;
            Comment = comment;
            Date = date;
        }
    }
}
