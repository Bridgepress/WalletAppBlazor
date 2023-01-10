namespace WalletApp.Client.DTO.FlowMoney
{
    public class FlowMoneyDetailsDTO
    {
        public Guid Id { get; set; }
        public string TypeOfExpense { get; set; } = default!;
        public decimal Amount { get; set; }
        public string? Comment { get; set; }
        public DateTime Date { get; set; } = default!;
    }
}
