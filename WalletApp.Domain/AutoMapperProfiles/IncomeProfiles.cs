using AutoMapper;
using WalletApp.Client.DTO.Income;
using WalletApp.Data.Entities;

namespace WalletApp.Domain.AutoMapperProfiles
{
    public class IncomeProfiles : Profile
    {
        public IncomeProfiles()
        {
            CreateMap<Income, IncomeDTO>().ReverseMap();
            CreateMap<Income, CreateIncomeDTO>().ReverseMap();
            CreateMap<Income, IncomeDetailsDTO>()
                .ForMember(c => c.TypeIncome,
                    options => options.MapFrom(
                    source => source.TypeIncome.Name))
                .ReverseMap();
        }
    }
}
