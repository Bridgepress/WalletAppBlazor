using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WalletApp.Data.Entities;

namespace WalletApp.Domain.Data
{
    public class WalletAppDbContext : IdentityDbContext<AppUser, AppRole, Guid,
            IdentityUserClaim<Guid>, AppUserRole, IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>,
            IdentityUserToken<Guid>>
    {
        public WalletAppDbContext(DbContextOptions<WalletAppDbContext> options) : base(options)
        {
        }

        public DbSet<FlowMoney> FlowMoneys { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<TypeIncome> TypeIncomes { get; set; }
        public DbSet<TypeOfExpense> TypeOfExpenses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<AppUser>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();
            builder.Entity<AppRole>()
               .HasMany(ur => ur.UserRoles)
               .WithOne(u => u.Role)
               .HasForeignKey(ur => ur.RoleId)
               .IsRequired();
            builder.Entity<TypeOfExpense>()
                .HasMany(c=>c.FlowMoneys)
                .WithOne(c=>c.TypeOfExpense)
                .HasForeignKey(c=>c.TypeOfExpenseId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
