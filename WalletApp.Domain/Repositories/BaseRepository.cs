using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WalletApp.Data.Entities;
using WalletApp.Domain.Data;
using WalletApp.Domain.Errors;
using WalletApp.Domain.Interfaces;

namespace WalletApp.Domain.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity, new()
    {
        protected WalletAppDbContext _context;
        protected DbSet<T> _dbSet = default!;
        protected ILogger _logger;

        private DbSet<T> _entities
        {
            get
            {
                if (_dbSet == null)
                {
                    _dbSet = _context.Set<T>() ?? throw new ArgumentNullException("Undefined Db set");
                }
                return _dbSet;
            }
        }

        public BaseRepository(WalletAppDbContext context, ILoggerFactory logger)
        {
            _context = context;
            _logger = logger.CreateLogger<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException($"Entity is null{(nameof(entity))}");
                }
                await _context.AddAsync(entity);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ExceptionMessages.ItemCantAddReason($"{ex.Message} - {ex.InnerException?.Message}"));
                throw new RepositoryException(ExceptionMessages.ItemCantAdd(), ex.InnerException);
            }
            await SaveAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException($"Entity is null{(nameof(entity))}");
                }
                _entities.Remove(entity);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ExceptionMessages.ItemCantAddReason($"{ex.Message} - {ex.InnerException?.Message}"));
                throw new RepositoryException(ExceptionMessages.ItemCantAdd(), ex.InnerException);
            }
            await SaveAsync();
        }

        public async Task<IQueryable<T>> GetAll()
        {
            return this._entities.AsNoTracking();
        }

        public IEnumerable<T> GetAllEnumerable()
        {
            return this._entities.AsEnumerable();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            try
            {
                return await _entities.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ExceptionMessages.ItemCantAddReason($"{ex.Message} - {ex.InnerException?.Message}"));
                throw new RepositoryException(ExceptionMessages.ItemCantAdd(), ex.InnerException);
            }
        }

        public async Task SaveAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ExceptionMessages.ItemCantSaveReason($"{ex.Message} - {ex.InnerException?.Message}"));
                throw new RepositoryException(ExceptionMessages.ItemCantSave(), ex.InnerException);
            }
        }

        public async Task<T> Update(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException($"Entity is null{(nameof(entity))}");
                }
                _entities.Update(entity);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ExceptionMessages.ItemCantAddReason($"{ex.Message} - {ex.InnerException?.Message}"));
                throw new RepositoryException(ExceptionMessages.ItemCantAdd(), ex.InnerException);
            }
            await SaveAsync();
            return entity;
        }
    }
}
