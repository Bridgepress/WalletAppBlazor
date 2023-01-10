using System.ComponentModel.DataAnnotations;

namespace WalletApp.Client.DTO.Income
{
    public class IncomeDTO
    {
        [RegularExpression(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$")]
        [Required(ErrorMessage = "Selected Type")]
        public Guid TypeIncomeId { get; set; } = default!;
        public decimal Amount { get; set; }
        public string? Comment { get; set; }
        public DateTime Date { get; set; } = default!;
    }
}
