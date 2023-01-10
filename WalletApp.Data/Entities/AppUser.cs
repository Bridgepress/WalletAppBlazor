using Microsoft.AspNetCore.Identity;

namespace WalletApp.Data.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public ICollection<AppUserRole> UserRoles  { get; set; }
        public ICollection<TypeOfExpense> TypeOfExpenses { get; set; }
        public ICollection<TypeIncome> TypeIncomes { get; set; }
        public ICollection<Income> Incomes { get; set; }
        public ICollection<FlowMoney> FlowMoney { get; set; }
    }
}
