using AutoMapper;
using WalletApp.Client.DTO.AppUser;
using WalletApp.Data.Entities;

namespace WalletApp.Domain.AutoMapperProfiles
{
    public class AppUserProfile : Profile
    {
        public AppUserProfile()
        {
            CreateMap<AppUser, CreateAppUserDTO>().ReverseMap();
            CreateMap<AppUser, RegisterDTO>().ReverseMap();
            CreateMap<AppUser, GetAppUserDTO>().ReverseMap();
            CreateMap<AppUser, LoginDTO>().ReverseMap();
        }
    }
}
