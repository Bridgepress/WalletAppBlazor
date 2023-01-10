using AutoMapper;
using WalletApp.Client.DTO.TypeOfExpense;
using WalletApp.Data.Entities;
using WalletApp.Domain.DTO.TypeOfExpense;

namespace WalletApp.Domain.AutoMapperProfiles
{
    public class TypeOfExpenseProfiles : Profile
    {
        public TypeOfExpenseProfiles()
        {
            CreateMap<TypeOfExpense, TypeOfExpenseDTO>().ReverseMap();
            CreateMap<TypeOfExpense, DeleteTypeOfExpenseDTO>().ReverseMap();
            CreateMap<TypeOfExpense, TypeOfExpenseDetatilsDTO>().ReverseMap();
        }
    }
}
