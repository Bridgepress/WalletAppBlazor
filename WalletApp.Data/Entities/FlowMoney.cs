namespace WalletApp.Data.Entities
{
    public class FlowMoney : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid TypeOfExpenseId { get; set; }
        public TypeOfExpense TypeOfExpense { get; set; } = default!;
        public decimal Amount { get; set; }
        public string? Comment { get; set; }
        public DateTime Date { get; set; } = default!;
    }
}
