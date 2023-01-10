using WalletApp.Client.DTO.TypeOfExpense;
using WalletApp.Domain.DTO.TypeOfExpense;

namespace WalletApp.Domain.Interfaces
{
    public interface ITypeOfExpenseService
    {
        Task<TypeOfExpenseDTO> AddAsync(TypeOfExpenseDTO user);

        Task<TypeOfExpenseDTO> DeleteAsync(Guid id);

        Task<IEnumerable<TypeOfExpenseDetatilsDTO>> GetAllEnumerable();
    }
}
