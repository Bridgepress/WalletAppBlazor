using Microsoft.AspNetCore.Identity;
using WalletApp.Data.Entities;
using WalletApp.Domain.Interfaces;

namespace WalletApp.Domain.Data
{
    public class InitializerUser : IInitializerUser
    {
        private WalletAppDbContext _context;
        private UserManager<AppUser> _userManager;

        public InitializerUser(WalletAppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task Initialize(AppUser appUser)
        {
            var addUser = _userManager.Users.FirstOrDefault(u => u.UserName == appUser.UserName);
            _context.AddRange(new List<TypeOfExpense>
            {
                new TypeOfExpense
                {
                    Name = "Без категории",
                    AppUser = appUser,

                },
                new TypeOfExpense
                {
                     Name = "Еда",
                    AppUser = appUser,
                },
                new TypeOfExpense
                {
                    Name = "Кафе",
                    AppUser = appUser,
                },
                new TypeOfExpense
                {
                    Name = "Одежда",
                    AppUser = appUser,
                },
                new TypeOfExpense
                {
                    Name = "Подарки",
                    AppUser = appUser,
                },
            });
            _context.AddRange(new List<TypeIncome>
            {
                new TypeIncome
                {
                    Name = "Банковские проценты",
                    AppUser = appUser,
                },
                new TypeIncome
                {
                    Name = "Работа",
                    AppUser = appUser,
                },
                new TypeIncome
                {
                    Name = "Прочие источники",
                    AppUser = appUser,
                }
            });
            _context.SaveChangesAsync();
        }
    }
}
