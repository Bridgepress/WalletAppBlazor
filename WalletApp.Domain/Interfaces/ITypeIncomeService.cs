using WalletApp.Client.DTO.TypeIncome;

namespace WalletApp.Domain.Interfaces
{
    public interface ITypeIncomeService
    {
        Task<TypeIncomeDTO> AddAsync(TypeIncomeDTO data);

        Task<TypeIncomeDTO> DeleteAsync(Guid id);

        Task<IEnumerable<TypeIncomeDetailsDTO>> GetAllEnumerable();
    }
}
