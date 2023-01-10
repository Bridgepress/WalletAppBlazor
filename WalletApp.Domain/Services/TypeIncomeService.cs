using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using WalletApp.Client.DTO.TypeIncome;
using WalletApp.Data.Entities;
using WalletApp.Domain.Cache;
using WalletApp.Domain.Interfaces;

namespace WalletApp.Domain.Services
{
    public class TypeIncomeService : ITypeIncomeService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<TypeIncome> _repository;
        private readonly UserManager<AppUser> _userManager;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMemoryCache _memoryCache;

        public TypeIncomeService(IMapper mapper, IRepository<TypeIncome> repository,
            UserManager<AppUser> userManager, ICurrentUserService currentUserService,
            IMemoryCache memoryCache)
        {
            _mapper = mapper;
            _repository = repository;
            _userManager = userManager;
            _currentUserService = currentUserService;
            _memoryCache = memoryCache;
        }

        public async Task<TypeIncomeDTO> AddAsync(TypeIncomeDTO data)
        {
            var user = await _userManager.FindByNameAsync(_currentUserService.UserName);
            TypeIncome entity = _mapper.Map<TypeIncome>(data);
            entity.AppUser = user;
            TypeIncome addEntity = await _repository.AddAsync(entity);
            return _mapper.Map<TypeIncomeDTO>(addEntity);
        }

        public async Task<TypeIncomeDTO> DeleteAsync(Guid id)
        {
            TypeIncome? entity = await _repository.GetByIdAsync(id);
            if (entity is null)
            {
                return null;
            }
            await _repository.DeleteAsync(entity);
            _memoryCache.Remove(CacheName.GetAllIncome);
            return _mapper.Map<TypeIncomeDTO>(entity);
        }

        public async Task<IEnumerable<TypeIncomeDetailsDTO>> GetAllEnumerable()
        {
            var user = await _userManager.FindByNameAsync(_currentUserService.UserName);
            var entities = await _repository.GetAll().Result
                .Where(x => x.AppUserId == user.Id)
                .ToListAsync();
            if (entities == null)
            {
                return null;
            }
            return _mapper.Map<IEnumerable<TypeIncomeDetailsDTO>>(entities);
        }
    }
}
