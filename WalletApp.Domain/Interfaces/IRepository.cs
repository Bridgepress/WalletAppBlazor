namespace WalletApp.Domain.Interfaces
{
    public interface IRepository<T>
    {
        Task<IQueryable<T>> GetAll();

        IEnumerable<T> GetAllEnumerable();

        Task<T> AddAsync(T entity);

        Task SaveAsync();

        Task DeleteAsync(T entity);

        Task<T> GetByIdAsync(Guid id);

        Task<T> Update(T entity);
    }
}
