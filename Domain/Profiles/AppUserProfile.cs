using AutoMapper;
using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.Models.Users;

namespace Pnprpg.Domain.Profiles
{
    public class AppUserProfile : Profile
    {
        public AppUserProfile()
        {
            CreateMap<AppUser, UserModel>();
            CreateMap<AppUser, UserEditModel>();
        }
    }
}
