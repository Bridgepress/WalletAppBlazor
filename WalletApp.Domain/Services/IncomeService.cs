using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using WalletApp.Client.DTO.Income;
using WalletApp.Data.Entities;
using WalletApp.Domain.Cache;
using WalletApp.Domain.Errors;
using WalletApp.Domain.Interfaces;

namespace WalletApp.Domain.Services
{
    public class IncomeService : IIncomeService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Income> _repository;
        private readonly IRepository<TypeIncome> _repositoryTypeIncome;
        private readonly IMemoryCache _memoryCache;
        private readonly UserManager<AppUser> _userManager;
        private readonly ICurrentUserService _currentUserService;

        public IncomeService(IMapper mapper, IRepository<Income> repository,
            IRepository<TypeIncome> repositoryTypeIncome, IMemoryCache memoryCache,
            UserManager<AppUser> userManager, ICurrentUserService currentUserService)
        {
            _mapper = mapper;
            _repository = repository;
            _repositoryTypeIncome = repositoryTypeIncome;
            _memoryCache = memoryCache;
            _userManager = userManager;
            _currentUserService = currentUserService;
        }

        public async Task<CreateIncomeDTO> AddAsync(CreateIncomeDTO data)
        {
            Income entity = _mapper.Map<Income>(data);
            var user = await _userManager.FindByNameAsync(_currentUserService.UserName);
            entity.AppUser = user;
            TypeIncome typeIncome = await _repositoryTypeIncome.GetByIdAsync(data.TypeIncomeId);
            if (typeIncome is null)
            {
                throw new ServiceException(ExceptionMessages.NotFound(nameof(typeIncome)));
            }
            entity.TypeIncome = typeIncome;
            Income addEntity = await _repository.AddAsync(entity);
            _memoryCache.Remove(CacheName.GetAllIncome);
            return _mapper.Map<CreateIncomeDTO>(addEntity);
        }

        public async Task<IncomeDTO> DeleteAsync(Guid id)
        {
            Income? entity = await _repository.GetByIdAsync(id);
            if (entity is null)
            {
                return null;
            }
            await _repository.DeleteAsync(entity);
            _memoryCache.Remove(CacheName.GetAllIncome);
            return _mapper.Map<IncomeDTO>(entity);
        }

        public async Task<IncomeDTO> GetByIdAsync(Guid id)
        {
            Income entity = await _repository.GetByIdAsync(id);
            if (entity is null)
            {
                return null;
            }
            return _mapper.Map<IncomeDTO>(entity);
        }

        public async Task<decimal> GetDecimalIncomeDateBaginDateEnd(DateTime dateBegin, DateTime dateEnd)
        {
            List<Income> entities = _memoryCache.Get<List<Income>>(CacheName.GetAllIncome);
            if (entities == null)
            {
                var user = await _userManager.FindByNameAsync(_currentUserService.UserName);
                entities = await _repository.GetAll().Result
                .Where(x => x.AppUserId == user.Id)
                .Include(x => x.TypeIncome)
                .ToListAsync();
                _memoryCache.Set(CacheName.GetAllIncome, entities, TimeSpan.FromMinutes(10));
            }
            if (entities == null)
            {
                return 0;
            }
            return entities.Where(x => x.Date.Date >= dateBegin.Date && x.Date.Date <= dateEnd.Date).Sum(x => x.Amount);
        }

        public async Task<decimal> GetDecimalIncomePerDate(DateTime date)
        {
            List<Income> entities = _memoryCache.Get<List<Income>>(CacheName.GetAllIncome);
            if (entities == null)
            {
                var user = await _userManager.FindByNameAsync(_currentUserService.UserName);
                entities = await _repository.GetAll().Result
                .Where(x => x.AppUserId == user.Id)
                .Include(x => x.TypeIncome)
                .ToListAsync();
                _memoryCache.Set(CacheName.GetAllIncome, entities, TimeSpan.FromMinutes(10));
            }
            if (entities == null)
            {
                return 0;
            }
            return entities.Where(x => x.Date.Date == date.Date).Sum(x => x.Amount);
        }

        public async Task<IEnumerable<IncomeDetailsDTO>> GetListIncomePerDate(DateTime date)
        {
            List<Income> entities = _memoryCache.Get<List<Income>>(CacheName.GetAllIncome);
            if (entities == null)
            {
                var user = await _userManager.FindByNameAsync(_currentUserService.UserName);
                entities = await _repository.GetAll().Result
                .Where(x => x.AppUserId == user.Id)
                .Include(x => x.TypeIncome)
                .ToListAsync();
                _memoryCache.Set(CacheName.GetAllIncome, entities, TimeSpan.FromMinutes(10));
            }
            if (entities == null)
            {
                return null;
            }
            return _mapper.Map<IEnumerable<IncomeDetailsDTO>>(entities.Where(x => x.Date.Date == date.Date));
        }

        public async Task<IEnumerable<IncomeDetailsDTO>> GetListIncomePerDateBaginDateEnd(DateTime dateBegin, DateTime dateEnd)
        {
            List<Income> entities = _memoryCache.Get<List<Income>>(CacheName.GetAllIncome);
            if (entities == null)
            {
                var user = await _userManager.FindByNameAsync(_currentUserService.UserName);
                entities = await _repository.GetAll().Result
                .Where(x => x.AppUserId == user.Id)
                .Include(x => x.TypeIncome)
                .ToListAsync();
                _memoryCache.Set(CacheName.GetAllIncome, entities, TimeSpan.FromMinutes(10));
            }
            if (entities == null)
            {
                return null;
            }
            return _mapper.Map<IEnumerable<IncomeDetailsDTO>>(entities.Where(x => x.Date.Date >= dateBegin.Date && x.Date.Date <= dateEnd.Date));
        }
    }
}
