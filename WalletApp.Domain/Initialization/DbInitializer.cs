using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using WalletApp.Data.Entities;

namespace WalletApp.Domain.Data
{
    public class DbInitializer
    {
        public static async Task Initialize(IServiceProvider services, UserManager<AppUser> userManager,
            RoleManager<AppRole> roleManager)
        {
            WalletAppDbContext context = services.GetRequiredService<WalletAppDbContext>();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            if (!context.TypeOfExpenses.Any())
            {
                var admin = new AppUser
                {
                    UserName = "admin"
                };
                await userManager.CreateAsync(admin, "Pa$$w0rd");
                await userManager.AddClaimAsync(admin, new System.Security.Claims.Claim("Admin", "Admin"));
                await userManager.AddClaimAsync(admin, new System.Security.Claims.Claim("Member", "Member"));
                var addUser = userManager.Users.FirstOrDefault(admin => admin.UserName == "admin");
                TypeOfExpense type1 = new TypeOfExpense
                {
                    Name = "Без категории",
                    AppUser = admin,

                };
                TypeOfExpense type2 = new TypeOfExpense
                {
                    Name = "Еда",
                    AppUser = admin,
                };
                TypeOfExpense type3 = new TypeOfExpense
                {
                    Name = "Кафе",
                    AppUser = admin,
                };
                TypeOfExpense type4 = new TypeOfExpense
                {
                    Name = "Одежда",
                    AppUser = admin,
                };
                TypeOfExpense type5 = new TypeOfExpense
                {
                    Name = "Подарки",
                    AppUser = admin,
                };
                context.AddRange(new List<FlowMoney>
                {
                    new FlowMoney
                    {
                        Amount=2000,
                        Comment="dasdasdas",
                        Date=DateTime.Now,
                        TypeOfExpense = type1,
                        AppUser = admin,
                    },
                    new FlowMoney
                    {
                        Amount=4000,
                        Comment="",
                        Date=new DateTime(2022,12,1),
                        TypeOfExpense = type2,
                        AppUser = admin,
                    },
                    new FlowMoney
                    {
                       Amount=5000,
                        Comment="dasdasdas",
                        Date=new DateTime(2022,11,2),
                        TypeOfExpense = type3,
                        AppUser = admin,
                    },
                    new FlowMoney
                    {
                        Amount=1000,
                        Comment="dasdasdas",
                        Date=new DateTime(2022,11,5),
                        TypeOfExpense = type4,
                        AppUser = admin,
                    },
                    new FlowMoney
                    {
                        Amount=2050,
                        Comment="dasdasdas",
                        Date=new DateTime(2022,12,10),
                        TypeOfExpense = type5,
                        AppUser = admin,
                    },
                     new FlowMoney
                    {
                        Amount=2000,
                        Comment="1",
                        Date=DateTime.Now.AddDays(-1),
                        TypeOfExpense = type1,
                        AppUser = admin,
                    },
                      new FlowMoney
                    {
                        Amount=2000,
                        Comment="2",
                        Date=DateTime.Now.AddDays(-2),
                        TypeOfExpense = type4,
                        AppUser = admin,
                    },
                       new FlowMoney
                    {
                        Amount=2000,
                        Comment="3",
                        Date=DateTime.Now.AddDays(-1),
                        TypeOfExpense = type3,
                        AppUser = admin,
                    },
                        new FlowMoney
                    {
                        Amount=2000,
                        Comment="4",
                        Date=DateTime.Now.AddDays(-3),
                        TypeOfExpense = type2,
                        AppUser = admin,
                    },
                         new FlowMoney
                    {
                        Amount=2000,
                        Comment="5",
                        Date=DateTime.Now.AddDays(-2),
                        TypeOfExpense = type5,
                        AppUser = admin,
                    },
                          new FlowMoney
                    {
                        Amount=2000,
                        Comment="6",
                        Date=DateTime.Now.AddDays(-1),
                        TypeOfExpense = type4,
                        AppUser = admin,
                    },
                           new FlowMoney
                    {
                        Amount=2000,
                        Comment="7",
                        Date=DateTime.Now,
                        TypeOfExpense = type4,
                        AppUser = admin,
                    },
                            new FlowMoney
                    {
                        Amount=2000,
                        Comment="8",
                        Date=DateTime.Now.AddDays(-3),
                        TypeOfExpense = type2,
                        AppUser = admin,
                    },
                             new FlowMoney
                    {
                        Amount=2000,
                        Comment="9",
                        Date=DateTime.Now.AddDays(-1),
                        TypeOfExpense = type5,
                        AppUser = admin,
                    },
                              new FlowMoney
                    {
                        Amount=2000,
                        Comment="10",
                        Date=DateTime.Now.AddDays(-3),
                        TypeOfExpense = type4,
                        AppUser = admin,
                    },
                               new FlowMoney
                    {
                        Amount=2000,
                        Comment="11",
                        Date=DateTime.Now,
                        TypeOfExpense = type3,
                        AppUser = admin,
                    },
                                new FlowMoney
                    {
                        Amount=2000,
                        Comment="12",
                        Date=DateTime.Now.AddDays(-1),
                        TypeOfExpense = type2,
                        AppUser = admin,
                    }
                });
                await context.SaveChangesAsync();
                TypeIncome typeIn1 = new TypeIncome
                {
                    Name = "Банковские проценты",
                    AppUser = admin,
                };
                TypeIncome typeIn2 = new TypeIncome
                {
                    Name = "Работа",
                    AppUser = admin,
                };
                TypeIncome typeIn3 = new TypeIncome
                {
                    Name = "Прочие источники",
                    AppUser = admin,
                };
                context.AddRange(new List<Income>
                {
                   new Income
                    {
                        Amount=2000,
                        Comment="dasdasdas",
                       Date=DateTime.Now,
                        TypeIncome = typeIn1,
                        AppUser = admin,
                    },
                    new Income
                    {
                        Amount=4000,
                        Comment="",
                        Date=new DateTime(2022,12,1),
                        TypeIncome = typeIn1,
                        AppUser = admin,
                    },
                    new Income
                    {
                       Amount=5000,
                        Comment="dasdasdas",
                        Date=new DateTime(2022,11,2),
                        TypeIncome = typeIn2,
                        AppUser = admin,
                    },
                    new Income
                    {
                        Amount=1000,
                        Comment="dasdasdas",
                        Date=new DateTime(2022,11,5),
                        TypeIncome = typeIn3,
                        AppUser = admin,
                    },
                    new Income
                    {
                        Amount=2050,
                        Comment="dasdasdas",
                        Date=new DateTime(2022,12,10),
                        TypeIncome = typeIn2,
                        AppUser = admin,
                    },
                     new Income
                    {
                        Amount=1000,
                        Comment="1",
                        Date=DateTime.Now.AddDays(-3),
                        TypeIncome = typeIn3,
                        AppUser = admin,
                    },
                      new Income
                    {
                        Amount=1000,
                        Comment="2",
                        Date=DateTime.Now.AddDays(-3),
                        TypeIncome = typeIn3,
                        AppUser = admin,
                    },
                       new Income
                    {
                        Amount=1000,
                        Comment="3",
                        Date=DateTime.Now,
                        TypeIncome = typeIn2,
                        AppUser = admin,
                    },
                        new Income
                    {
                        Amount=1000,
                        Comment="4",
                        Date=DateTime.Now,
                        TypeIncome = typeIn1,
                        AppUser = admin,
                    },
                         new Income
                    {
                        Amount=1000,
                        Comment="5",
                        Date=DateTime.Now,
                        TypeIncome = typeIn3,
                        AppUser = admin,
                    },
                          new Income
                    {
                        Amount=1000,
                        Comment="6",
                        Date=DateTime.Now,
                        TypeIncome = typeIn2,
                        AppUser = admin,
                    },
                           new Income
                    {
                        Amount=1000,
                        Comment="7",
                         Date=DateTime.Now,
                        TypeIncome = typeIn3,
                        AppUser = admin,
                    },
                            new Income
                    {
                        Amount=1000,
                        Comment="8",
                        Date=DateTime.Now,
                        TypeIncome = typeIn3,
                        AppUser = admin,
                    },
                             new Income
                    {
                        Amount=1000,
                        Comment="9",
                       Date=DateTime.Now.AddDays(-2),
                        TypeIncome = typeIn2,
                        AppUser = admin,
                    },
                              new Income
                    {
                        Amount=1000,
                        Comment="10",
                        Date=DateTime.Now.AddDays(-1),
                        TypeIncome = typeIn3,
                        AppUser = admin,
                    },
                               new Income
                    {
                        Amount=1000,
                        Comment="11",
                       Date=DateTime.Now.AddDays(-2),
                        TypeIncome = typeIn2,
                        AppUser = admin,
                    },
                                new Income
                    {
                        Amount=1000,
                        Comment="12",
                        Date=DateTime.Now.AddDays(-3),
                        TypeIncome = typeIn1,
                        AppUser = admin,
                    },
                                 new Income
                    {
                        Amount=1000,
                        Comment="13",
                        Date = DateTime.Now,
                        TypeIncome = typeIn2,
                        AppUser = admin,
                    },
                                  new Income
                    {
                        Amount=1000,
                        Comment="14",
                        Date=DateTime.Now.AddDays(-3),
                        TypeIncome = typeIn1,
                        AppUser = admin,
                    },
                                   new Income
                    {
                        Amount=1000,
                        Comment="15",
                        Date=DateTime.Now.AddDays(-1),
                        TypeIncome = typeIn1,
                        AppUser = admin,
                    },
                                    new Income
                    {
                        Amount=1000,
                        Comment="16",
                        Date=DateTime.Now.AddDays(-1),
                        TypeIncome = typeIn3,
                        AppUser = admin,
                    },
                                     new Income
                    {
                        Amount=1000,
                        Comment="17",
                        Date=DateTime.Now.AddDays(-2),
                        TypeIncome = typeIn2,
                        AppUser = admin,
                    },
                });
                await context.SaveChangesAsync();
            }
        }
    }
}
