using WalletApp.Client.DTO.Income;
using WalletApp.CommandAndQuery.Commands;

namespace WalletApp.CommandAndQuery.Income.CreateIncome
{
    public class CreateIncomeCommand : BaseCommand<CreateIncomeDTO>
    {
        public Guid TypeIncomeId { get; } = default!;
        public decimal Amount { get; }
        public string? Comment { get; }
        public DateTime Date { get; } = default!;

        public CreateIncomeCommand(Guid typeIncomeId, decimal amount, string? comment, DateTime date)
        {
            TypeIncomeId = typeIncomeId;
            Amount = amount;
            Comment = comment;
            Date = date;
        }
    }
}
