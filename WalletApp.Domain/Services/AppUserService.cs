using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using WalletApp.Client.DTO.AppUser;
using WalletApp.Data.Entities;
using WalletApp.Domain.Authorization;
using WalletApp.Domain.Cache;
using WalletApp.Domain.Errors;
using WalletApp.Domain.Interfaces;

namespace WalletApp.Domain.Services
{
    public class AppUserService : IAppUserService
    {
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IInitializerUser initializerUser;
        private readonly IMemoryCache _memoryCache;

        public AppUserService(IMapper mapper, ITokenService tokenService,
            SignInManager<AppUser> signInManager, UserManager<AppUser> userManager,
            IInitializerUser initializerUser, IMemoryCache memoryCache)
        {
            _mapper = mapper;
            _tokenService = tokenService;
            _signInManager = signInManager;
            _userManager = userManager;
            this.initializerUser = initializerUser;
            _memoryCache = memoryCache;
        }

        public async Task<UserDTO> AddAsync(RegisterDTO user)
        {
            if (await UserExists(user.Name))
            {
                throw new ServiceException(ExceptionMessages.UserIsExist());
            }
            AppUser entity = _mapper.Map<AppUser>(user);
            entity.UserName = user.Name.ToLower();
            var result = await _userManager.CreateAsync(entity, user.Password);
            if (!result.Succeeded)
            {
                return null;
            }
            await _userManager.AddClaimAsync(entity, new System.Security.Claims.Claim(MyClaims.Member, MyClaims.Member));
            await initializerUser.Initialize(entity);
            return new UserDTO
            {
                Name = entity.UserName,
                Token = await _tokenService.CreateToken(entity)
            };
        }

        public async Task<UserDTO> LoginAsync(LoginDTO loginDTO)
        {
            var user = await _userManager.Users
                .SingleOrDefaultAsync(x => x.UserName == loginDTO.Name);
            if (user == null)
            {
                throw new ServiceException(ExceptionMessages.UserNotFound());
            }
            var result = await _userManager.CheckPasswordAsync(user, loginDTO.Password);
            if (!result)
            {
                throw new ServiceException(ExceptionMessages.PasswordNoExist());
            }
            return new UserDTO
            {
                Name = user.UserName,
                Token = await _tokenService.CreateToken(user)
            };
        }

        public async Task Logout()
        {
            _memoryCache.Remove(CacheName.GetAllFlowMoney);
            _memoryCache.Remove(CacheName.GetAllIncome);
        }

        public async Task<bool> UserExists(string name)
        {
            return await _userManager.Users.AnyAsync(x => x.UserName == name.ToLower());
        }
    }
}
