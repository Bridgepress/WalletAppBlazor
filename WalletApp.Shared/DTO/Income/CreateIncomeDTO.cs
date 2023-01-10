using System.ComponentModel.DataAnnotations;

namespace WalletApp.Client.DTO.Income
{
    public class CreateIncomeDTO
    {
        [Required(ErrorMessage = "Selected Type")]
        public Guid TypeIncomeId { get; set; } = default!;
        [Range(0.01, Double.MaxValue, ErrorMessage = "There should be a positive number more than 0")]
        public decimal Amount { get; set; }
        public string? Comment { get; set; }
        public DateTime Date { get; set; } = default!;
    }
}
