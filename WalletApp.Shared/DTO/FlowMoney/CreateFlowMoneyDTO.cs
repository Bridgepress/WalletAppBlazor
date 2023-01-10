using System.ComponentModel.DataAnnotations;

namespace WalletApp.Client.DTO.FlowMoney
{
    public class CreateFlowMoneyDTO
    {
        [Required]
        [RegularExpression("^((?!00000000-0000-0000-0000-000000000000).)*$", ErrorMessage = "Cannot use default Guid")]
        public Guid TypeOfExpenseId { get; set; }
        [Range(0.01, Double.MaxValue,ErrorMessage = "There should be a positive number more than 0")]
        public decimal Amount { get; set; }
        public string? Comment { get; set; }
        public DateTime Date { get; set; } = default!;
    }
}
