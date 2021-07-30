using AutoMapper;
using FootMark.Application.ViewModels;
using FootMark.Domain.Models.Users;

namespace FootMark.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<AppUser, UserViewModel>();
        }

    }
}
