namespace WalletApp.Data.Entities
{
    public class Income : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid TypeIncomeId{ get; set; }
        public TypeIncome TypeIncome { get; set; } = default!;
        public decimal Amount { get; set; }
        public string? Comment { get; set; }
        public DateTime Date { get; set; } = default!;
    }
}
