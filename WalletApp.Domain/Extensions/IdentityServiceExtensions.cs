using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WalletApp.Data.Entities;
using WalletApp.Domain.Authorization;
using WalletApp.Domain.Data;

namespace WalletApp.Domain.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddIdentityCore<AppUser>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
            })
                .AddRoles<AppRole>()
                .AddRoleManager<RoleManager<AppRole>>()
                .AddSignInManager<SignInManager<AppUser>>()
                .AddRoleValidator<RoleValidator<AppRole>>()
                .AddEntityFrameworkStores<WalletAppDbContext>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"])),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    };

                });
            services.AddAuthorization(options =>
            {
                options.AddPolicy(
                    MyPolicies.UserShowAndAboveAccess,
                    policy => policy.RequireAssertion(context =>
                    {
                        return context.User.HasClaim(
                            claim => claim.Type == MyClaims.Member ||
                                      claim.Type == MyClaims.Admin
                        );

                    }));

                options.AddPolicy(
                MyPolicies.AdminAccessOnly,
                policy => policy.RequireAssertion(context =>
                {
                    return context.User.HasClaim(
                        claim => claim.Type == MyClaims.Admin
                        );
                }));
            });
            services.AddSession(options =>
            {
                options.Cookie.IsEssential = true;
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
            });
            services.AddControllersWithViews();
            return services;
        }
    }
}
