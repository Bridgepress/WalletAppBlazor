namespace WalletApp.Data.Entities
{
    public class TypeOfExpense : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public ICollection<FlowMoney> FlowMoneys { get; set; } = default!;
    }
}
