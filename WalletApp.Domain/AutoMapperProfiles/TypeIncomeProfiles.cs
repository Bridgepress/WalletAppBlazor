using AutoMapper;
using WalletApp.Client.DTO.TypeIncome;
using WalletApp.Data.Entities;

namespace WalletApp.Domain.AutoMapperProfiles
{
    public class TypeIncomeProfiles : Profile
    {
        public TypeIncomeProfiles()
        {
            CreateMap<TypeIncome, TypeIncomeDTO>().ReverseMap();
            CreateMap<TypeIncome, DeleteTypeIncomeDTO>().ReverseMap();
            CreateMap<TypeIncome, TypeIncomeDetailsDTO>().ReverseMap();
        }
    }
}
