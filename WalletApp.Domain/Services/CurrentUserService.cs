using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using WalletApp.Domain.Interfaces;

namespace WalletApp.Domain.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string UserName { get { return _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Name); } }
    }
}
