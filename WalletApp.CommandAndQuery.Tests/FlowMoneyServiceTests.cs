using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WalletApp.CommandAndQuery.FlowMoney.GetListFlowMoneyPerDay;
using WalletApp.Data.Entities;
using WalletApp.Domain.AutoMapperProfiles;
using WalletApp.Domain.Cache;
using WalletApp.Domain.Interfaces;
using WalletApp.Domain.Repositories;
using WalletApp.Domain.Services;
using WalletApp.Shared.Services;

namespace WalletApp.CommandAndQuery.Tests
{
    [TestClass]
    public class FlowMoneyServiceTests
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManagerMock;
        private readonly Mock<IRepository<WalletApp.Data.Entities.FlowMoney>> _repositoryMock;
        private readonly Mock<IRepository<WalletApp.Data.Entities.TypeOfExpense>> _repositoryTypeExpenseMock;
        private readonly IMemoryCache _memoryCacheMock;
        private readonly Mock<ICurrentUserService> _currentUserServiceMock;

        public FlowMoneyServiceTests()
        {
            var services = new ServiceCollection();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IAppUserService, AppUserService>();
            services.AddScoped<IFlowMoneyService, FlowMoneyService>();
            services.AddScoped<IIncomeService, IncomeService>();
            services.AddScoped<ITypeIncomeService, TypeIncomeService>();
            services.AddScoped<ITypeOfExpenseService, TypeOfExpenseService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddLogging(config =>
            {
                config.AddDebug();
                config.AddConsole();
            });
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new FlowMoneyProfile());
            });
            _mapper = mappingConfig.CreateMapper();
            services.AddMemoryCache();
            _memoryCacheMock = new MemoryCache(new MemoryCacheOptions());
            _repositoryMock = new();
            _repositoryTypeExpenseMock = new();
            _currentUserServiceMock = new();
        }

        [TestMethod]
        public async Task CreateTypeOfExpense()
        {
            AppUser user = new AppUser() { UserName = "test", Id = Guid.NewGuid() };
            _repositoryMock.Setup(x => x.AddAsync(It.IsAny<WalletApp.Data.Entities.FlowMoney>()))
                 .ReturnsAsync(new WalletApp.Data.Entities.FlowMoney()
                 {
                     Amount = 2000,
                     AppUser = user,
                     AppUserId = user.Id,
                     Date = DateTime.Now,
                     Id = Guid.NewGuid(),
                     Comment = "qqqqq",
                     TypeOfExpense = new WalletApp.Data.Entities.TypeOfExpense() { AppUser = user, Id = Guid.NewGuid(), Name = "Test" }
                 });
            var UserStoreMock = Mock.Of<IUserStore<AppUser>>();
            var userMgr = new Mock<UserManager<AppUser>>(UserStoreMock, null, null, null, null, null, null, null, null);
            var tcs = new TaskCompletionSource<AppUser>();
            tcs.SetResult(user);
            userMgr.Setup(x => x.FindByIdAsync("test")).ReturnsAsync(user);
            _currentUserServiceMock.Setup(x=>x.UserName).Returns("test");
            _repositoryTypeExpenseMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(new WalletApp.Data.Entities.TypeOfExpense() { AppUser = user, Id = Guid.NewGuid(), Name = "Test" });
            var service = new FlowMoneyService(_mapper, _repositoryMock.Object, _repositoryTypeExpenseMock.Object, _memoryCacheMock, userMgr.Object, _currentUserServiceMock.Object);
            var result = await service.AddAsync(new Client.DTO.FlowMoney.CreateFlowMoneyDTO() { Amount = 20000, Comment = "dsfdsf", Date = DateTime.Now, TypeOfExpenseId = Guid.NewGuid() });
            Assert.AreEqual(result.Amount, 2000);
        }

        [TestMethod]
        public async Task GetTypeOfExpense()
        {
            AppUser user = new AppUser() { UserName = "test", Id = Guid.NewGuid() };
            List<WalletApp.Data.Entities.FlowMoney> costs = new List<Data.Entities.FlowMoney>()
            {
                 new WalletApp.Data.Entities.FlowMoney()
                {
                    AppUser =user,
                    Id = Guid.NewGuid(),
                    Date = DateTime.Now,
                    Amount = 2000,
                    AppUserId = user.Id,
                    Comment = "dfsdfsd",
                    TypeOfExpense = new Data.Entities.TypeOfExpense()
                    {
                         AppUser = user,
                         AppUserId = user.Id,
                         Name = "test",
                         Id = Guid.NewGuid()
                    }
                },
                new WalletApp.Data.Entities.FlowMoney()
                {
                    AppUser =user,
                    Id = Guid.NewGuid(),
                    Date = DateTime.Now,
                    Amount = 2000,
                    AppUserId = user.Id,
                    Comment = "dfsdfsd",
                    TypeOfExpense = new Data.Entities.TypeOfExpense()
                    {
                         AppUser = user,
                         AppUserId = user.Id,
                         Name = "test",
                         Id = Guid.NewGuid()
                    }
                },
                new WalletApp.Data.Entities.FlowMoney()
                {
                    AppUser =user,
                    Id = Guid.NewGuid(),
                    Date = new DateTime(2022,2,2),
                    Amount = 2000,
                    AppUserId = user.Id,
                    Comment = "dfsdfsd",
                    TypeOfExpense = new Data.Entities.TypeOfExpense()
                    {
                         AppUser = user,
                         AppUserId = user.Id,
                         Name = "test",
                         Id = Guid.NewGuid()
                    }
                }
            };
            _repositoryMock.Setup(x => x.GetAll()).ReturnsAsync(costs.AsQueryable());
            var UserStoreMock = Mock.Of<IUserStore<AppUser>>();
            var userMgr = new Mock<UserManager<AppUser>>(UserStoreMock, null, null, null, null, null, null, null, null);
            var tcs = new TaskCompletionSource<AppUser>();
            tcs.SetResult(user);
            userMgr.Setup(x => x.FindByNameAsync(It.IsAny<string>())).ReturnsAsync(user);
            _currentUserServiceMock.Setup(x => x.UserName).Returns("test");
            var service = new FlowMoneyService(_mapper, _repositoryMock.Object, _repositoryTypeExpenseMock.Object, _memoryCacheMock, userMgr.Object, _currentUserServiceMock.Object);
            var result = await service.GetListFlowMoneyPerDate(DateTime.Now);
            Assert.AreEqual(result.Sum(x=>x.Amount), 4000);
        }
    }
}
