using WalletApp.Client.DTO.Income;

namespace WalletApp.Client.HttpRepositories
{
    public interface IIncomeRepository
    {
        public Task<CreateIncomeDTO> AddIncome(CreateIncomeDTO flowMoney);

        public Task<IncomeDTO> DeleteIncome(Guid id);

        public Task<decimal> GetAllDecimaltoDate(DateTime date);


        public Task<decimal> GetAllDecimalToBeginDateEndDate(DateTime beginDate, DateTime endDate);

        public Task<IEnumerable<IncomeDetailsDTO>> GetListToDate(DateTime date);

        public Task<IEnumerable<IncomeDetailsDTO>> GetAllListToBeginDateEndDate(DateTime beginDate, DateTime endDate);
    }
}
