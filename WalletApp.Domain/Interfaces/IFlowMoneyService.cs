using WalletApp.Client.DTO.FlowMoney;

namespace WalletApp.Domain.Interfaces
{
    public interface IFlowMoneyService
    {
        Task<CreateFlowMoneyDTO> AddAsync(CreateFlowMoneyDTO data);

        Task<FlowMoneyDTO> DeleteAsync(Guid id);

        Task<decimal> GetDecimalFlowMoneyPerDate(DateTime date);

        Task<decimal> GetDecimalFlowMoneyPerDateBaginDateEnd(DateTime dateBegin, DateTime dateEnd);

        Task<IEnumerable<FlowMoneyDetailsDTO>> GetListFlowMoneyPerDate(DateTime date);

        Task<IEnumerable<FlowMoneyDetailsDTO>> GetListFlowMoneyPerDateBaginDateEnd(DateTime dateBegin, DateTime dateEnd);

        Task<FlowMoneyDTO> GetByIdAsync(Guid id);
    }
}
