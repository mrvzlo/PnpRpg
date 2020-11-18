using System.Linq;
using AutoMapper;
using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.Models;

namespace Pnprpg.Domain.Profiles
{
    public class WeaponProfile : Profile
    {
        public WeaponProfile()
        {
            CreateMap<Weapon, WeaponViewModel>()
                .ForMember(dest => dest.Bonuses, opts => { opts.MapFrom(from => from.Bonuses.Select(x => x.Bonus)); });
            CreateMap<Weapon, WeaponEditModel>()
                .ForMember(dest => dest.Bonuses, opts => { opts.MapFrom(from => from.Bonuses.Select(x => x.BonusId)); });
        }
    }
}
