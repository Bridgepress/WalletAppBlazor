namespace WalletApp.Data.Entities
{ 
    public class TypeIncome : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public ICollection<Income> Incomes { get; set; } = default!;
    }
}
