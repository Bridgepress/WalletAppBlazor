using AutoMapper;
using WalletApp.Client.DTO.FlowMoney;
using WalletApp.Data.Entities;

namespace WalletApp.Domain.AutoMapperProfiles
{
    public class FlowMoneyProfile : Profile
    {
        public FlowMoneyProfile()
        {
            CreateMap<FlowMoney, FlowMoneyDTO>().ReverseMap();
            CreateMap<FlowMoney, CreateFlowMoneyDTO>().ReverseMap();
            CreateMap<FlowMoney, FlowMoneyDetailsDTO>()
                .ForMember(c => c.TypeOfExpense,
                options => options.MapFrom(
                    source => source.TypeOfExpense.Name))
                .ReverseMap();
        }
    }
}
