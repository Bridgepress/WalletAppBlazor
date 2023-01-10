using WalletApp.Client.DTO.FlowMoney;

namespace WalletApp.Client.HttpRepositories
{
    public interface IFlowMoneyReposytory
    {
        public Task<CreateFlowMoneyDTO> AddFlowMoney(CreateFlowMoneyDTO flowMoney);

        public Task<FlowMoneyDTO> DeleteFlowMoney(Guid id);

        public Task<decimal> GetAllDecimaltoDate(DateTime date);

        public Task<decimal> GetAllDecimalToBeginDateEndDate(DateTime beginDate, DateTime endDate);

        public Task<IEnumerable<FlowMoneyDetailsDTO>> GetListToDate(DateTime date);

        public Task<IEnumerable<FlowMoneyDetailsDTO>> GetAllListToBeginDateEndDate(DateTime beginDate, DateTime endDate);
    }
}
