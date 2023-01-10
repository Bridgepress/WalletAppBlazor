using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using WalletApp.Client.DTO.FlowMoney;
using WalletApp.Data.Entities;
using WalletApp.Domain.Cache;
using WalletApp.Domain.Errors;
using WalletApp.Domain.Interfaces;

namespace WalletApp.Domain.Services
{
    public class FlowMoneyService : IFlowMoneyService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly IRepository<FlowMoney> _repository;
        private readonly IRepository<TypeOfExpense> _repositoryTypeExpense;
        private readonly IMemoryCache _memoryCache;
        private readonly ICurrentUserService _currentUserService;

        public FlowMoneyService(IMapper mapper, IRepository<FlowMoney> repository,
            IRepository<TypeOfExpense> repositoryTypeExpense, IMemoryCache memoryCache,
            UserManager<AppUser> userManager, ICurrentUserService currentUserService)
        {
            _mapper = mapper;
            _repository = repository;
            _repositoryTypeExpense = repositoryTypeExpense;
            _memoryCache = memoryCache;
            _userManager = userManager;
            _currentUserService = currentUserService;
        }

        public async Task<CreateFlowMoneyDTO> AddAsync(CreateFlowMoneyDTO data)
        {
            FlowMoney entity = _mapper.Map<FlowMoney>(data);
            var user = await _userManager.FindByNameAsync(_currentUserService.UserName);
            entity.AppUser = user;
            TypeOfExpense typeOfExpense = await _repositoryTypeExpense.GetByIdAsync(data.TypeOfExpenseId);
            if (typeOfExpense is null)
            {
                throw new ServiceException(ExceptionMessages.NotFound(nameof(typeOfExpense)));
            }
            entity.TypeOfExpense = typeOfExpense;
            FlowMoney addEntity = await _repository.AddAsync(entity);
            _memoryCache.Remove(CacheName.GetAllFlowMoney);
            return _mapper.Map<CreateFlowMoneyDTO>(addEntity);
        }

        public async Task<Client.DTO.FlowMoney.FlowMoneyDTO> DeleteAsync(Guid id)
        {
            FlowMoney? entity = await _repository.GetByIdAsync(id);
            if (entity is null)
            {

                return null;
            }
            await _repository.DeleteAsync(entity);
            _memoryCache.Remove(CacheName.GetAllFlowMoney);
            return _mapper.Map<FlowMoneyDTO>(entity);
        }

        public async Task<FlowMoneyDTO> GetByIdAsync(Guid id)
        {
            FlowMoney entity = await _repository.GetByIdAsync(id);
            if (entity is null)
            {
                return null;
            }
            return _mapper.Map<FlowMoneyDTO>(entity);
        }

        public async Task<decimal> GetDecimalFlowMoneyPerDate(DateTime date)
        {
            List<FlowMoney> entities = _memoryCache.Get<List<FlowMoney>>(CacheName.GetAllFlowMoney);
            if (entities == null)
            {
                var user = await _userManager.FindByNameAsync(_currentUserService.UserName);
                entities = await _repository.GetAll().Result
                .Where(x => x.AppUserId == user.Id)
                .Include(x => x.TypeOfExpense)
                .ToListAsync();
                _memoryCache.Set(CacheName.GetAllFlowMoney, entities, TimeSpan.FromMinutes(10));
            }
            if (entities == null)
            {
                return 0;
            }
            return entities.Where(x => x.Date.Date == date.Date).Sum(x => x.Amount);
        }

        public async Task<decimal> GetDecimalFlowMoneyPerDateBaginDateEnd(DateTime dateBegin, DateTime dateEnd)
        {
            List<FlowMoney> entities = _memoryCache.Get<List<FlowMoney>>(CacheName.GetAllFlowMoney);
            if (entities == null)
            {
                var user = await _userManager.FindByNameAsync(_currentUserService.UserName);
                entities = await _repository.GetAll().Result
                .Where(x => x.AppUserId == user.Id)
                .Include(x => x.TypeOfExpense)
                .ToListAsync();
                _memoryCache.Set(CacheName.GetAllFlowMoney, entities, TimeSpan.FromMinutes(10));
            }
            if (entities == null)
            {
                return 0;
            }
            return entities.Where(x => x.Date.Date >= dateBegin.Date && x.Date.Date <= dateEnd.Date).Sum(x => x.Amount);
        }

        public async Task<IEnumerable<FlowMoneyDetailsDTO>> GetListFlowMoneyPerDate(DateTime date)
        {
            List<FlowMoney> entities = _memoryCache.Get<List<FlowMoney>>(CacheName.GetAllFlowMoney);
            var user = await _userManager.FindByNameAsync(_currentUserService.UserName);
            if (entities == null)
            {
                entities = _repository.GetAll().Result
                .Where(x => x.AppUserId == user.Id)
                .Include(x => x.TypeOfExpense)
                .ToList();
                _memoryCache.Set(CacheName.GetAllFlowMoney, entities, TimeSpan.FromMinutes(10));
            }
            if (entities == null)
            {
                return null;
            }
            var flowMoneyToDate = entities.Where(x => x.Date.Date == date.Date);
            return _mapper.Map<IEnumerable<FlowMoneyDetailsDTO>>(flowMoneyToDate);
        }

        public async Task<IEnumerable<FlowMoneyDetailsDTO>> GetListFlowMoneyPerDateBaginDateEnd(DateTime dateBegin, DateTime dateEnd)
        {
            List<FlowMoney> entities = _memoryCache.Get<List<FlowMoney>>(CacheName.GetAllFlowMoney);
            if (entities == null)
            {
                var user = await _userManager.FindByNameAsync(_currentUserService.UserName);
                entities = await _repository.GetAll().Result
                .Where(x => x.AppUserId == user.Id)
                .Include(x => x.TypeOfExpense)
                .ToListAsync();
                _memoryCache.Set(CacheName.GetAllFlowMoney, entities, TimeSpan.FromMinutes(10));
            }
            if (entities == null)
            {
                return null;
            }
            return _mapper.Map<IEnumerable<FlowMoneyDetailsDTO>>(entities.Where(x => x.Date.Date >= dateBegin.Date && x.Date.Date <= dateEnd.Date));
        }
    }
}
