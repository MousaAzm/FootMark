using AutoMapper;
using FootMark.Application.ViewModels;
using FootMark.Domain.Commands;

namespace FootMark.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<UserViewModel, RegisterNewUserCommand>()
                .ConstructUsing(c => new RegisterNewUserCommand(c.Name, c.Email, c.CreateDate.Date));
            CreateMap<UserViewModel, UpdateUserCommand>()
                .ConstructUsing(c => new UpdateUserCommand(c.Id, c.Name, c.Email, c.CreateDate.Date));
        }
    }
}
