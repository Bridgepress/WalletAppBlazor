using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WalletApp.Domain.AutoMapperProfiles;
using WalletApp.Domain.Data;
using WalletApp.Domain.Interfaces;
using WalletApp.Domain.Repositories;
using WalletApp.Domain.Services;
using WalletApp.Shared.Services;

namespace WalletApp.Domain.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {

            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IAppUserService, AppUserService>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<IFlowMoneyService, FlowMoneyService>();
            services.AddScoped<IIncomeService, IncomeService>();
            services.AddScoped<ITypeIncomeService, TypeIncomeService>();
            services.AddScoped<ITypeOfExpenseService, TypeOfExpenseService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IInitializerUser, InitializerUser>();
            services.AddAutoMapper(
                typeof(AppUserProfile));
            var assembly = typeof(ApplicationServiceExtensions).Assembly;
            services.AddMediatR(assembly);
            services.AddMemoryCache();
            services.AddDbContext<WalletAppDbContext>(options =>
             {
                 options.UseSqlServer(
                     config.GetConnectionString("DefaultConnection"));
             });
        }
    }
}
