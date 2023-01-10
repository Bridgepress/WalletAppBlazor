namespace WalletApp.Client.DTO.Income
{
    public class IncomeDetailsDTO
    {
        public Guid Id { get; set; }
        public string TypeIncome { get; set; } = default!;
        public decimal Amount { get; set; }
        public string? Comment { get; set; }
        public DateTime Date { get; set; } = default!;
    }
}
