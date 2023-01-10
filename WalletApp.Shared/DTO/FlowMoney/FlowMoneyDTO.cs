using System.ComponentModel.DataAnnotations;

namespace WalletApp.Client.DTO.FlowMoney
{
    public class FlowMoneyDTO
    {
        public Guid TypeOfExpenseId { get; set; } = default!;
        public decimal Amount { get; set; }
        public string? Comment { get; set; }
        public DateTime Date { get; set; } = default!;
    }
}
