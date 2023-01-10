using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using WalletApp.Client.DTO.TypeOfExpense;
using WalletApp.Data.Entities;
using WalletApp.Domain.Cache;
using WalletApp.Domain.DTO.TypeOfExpense;
using WalletApp.Domain.Interfaces;

namespace WalletApp.Domain.Services
{
    public class TypeOfExpenseService : ITypeOfExpenseService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<TypeOfExpense> _repository;
        private readonly UserManager<AppUser> _userManager;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMemoryCache _memoryCache;

        public TypeOfExpenseService(IMapper mapper, IRepository<TypeOfExpense> repository,
            UserManager<AppUser> userManager, ICurrentUserService currentUserService,
            IMemoryCache memoryCache)
        {
            _mapper = mapper;
            _repository = repository;
            _userManager = userManager;
            _currentUserService = currentUserService;
            _memoryCache = memoryCache;
        }

        public async Task<TypeOfExpenseDTO> AddAsync(TypeOfExpenseDTO data)
        {
            var user = await _userManager.FindByNameAsync(_currentUserService.UserName);
            TypeOfExpense entity = _mapper.Map<TypeOfExpense>(data);
            entity.AppUser = user;
            TypeOfExpense addEntity = await _repository.AddAsync(entity);
            return _mapper.Map<TypeOfExpenseDTO>(addEntity);
        }

        public async Task<TypeOfExpenseDTO> DeleteAsync(Guid id)
        {
            TypeOfExpense? entity = await _repository.GetByIdAsync(id);
            if (entity is null)
            {
                return null;
            }
            await _repository.DeleteAsync(entity);
            _memoryCache.Remove(CacheName.GetAllFlowMoney);
            return _mapper.Map<TypeOfExpenseDTO>(entity);
        }

        public async Task<IEnumerable<TypeOfExpenseDetatilsDTO>> GetAllEnumerable()
        {
            var user = await _userManager.FindByNameAsync(_currentUserService.UserName);
            var entities = await _repository.GetAll().Result
                .Where(x => x.AppUserId == user.Id)
                .ToListAsync();
            if (entities == null)
            {
                return null;
            }
            return _mapper.Map<IEnumerable<TypeOfExpenseDetatilsDTO>>(entities);
        }
    }
}
