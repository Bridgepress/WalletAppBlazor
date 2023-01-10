using WalletApp.Client.DTO.Income;

namespace WalletApp.Domain.Interfaces
{
    public interface IIncomeService
    {
        Task<CreateIncomeDTO> AddAsync(CreateIncomeDTO data);

        Task<IncomeDTO> DeleteAsync(Guid id);

        Task<decimal> GetDecimalIncomePerDate(DateTime date);

        Task<decimal> GetDecimalIncomeDateBaginDateEnd(DateTime dateBegin, DateTime dateEnd);

        Task<IEnumerable<IncomeDetailsDTO>> GetListIncomePerDate(DateTime date);

        Task<IEnumerable<IncomeDetailsDTO>> GetListIncomePerDateBaginDateEnd(DateTime dateBegin, DateTime dateEnd);

        Task<IncomeDTO> GetByIdAsync(Guid id);
    }
}
