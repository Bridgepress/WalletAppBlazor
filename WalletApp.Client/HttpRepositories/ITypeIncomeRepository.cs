using WalletApp.Client.DTO.Income;
using WalletApp.Client.DTO.TypeIncome;

namespace WalletApp.Client.HttpRepositories
{
    public interface ITypeIncomeRepository
    {
        public Task<TypeIncomeDTO> CreateTypeIncome(TypeIncomeDTO typeIncomeDTO);

        public Task<TypeIncomeDTO> DeleteTypeIncome(Guid id);

        public Task<List<TypeIncomeDetailsDTO>> GetAllTypeIncome();
    }
}
