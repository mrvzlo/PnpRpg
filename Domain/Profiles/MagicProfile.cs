using AutoMapper;
using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.Models;

namespace Pnprpg.Domain.Profiles
{
    public class MagicProfile : Profile
    {
        public MagicProfile()
        {
            CreateMap<Spell, SpellEditModel>();
            CreateMap<Spell, SpellViewModel>()
                .ForMember(dest => dest.Color, opts => { opts.MapFrom(from => from.MagicSchool.Color); })
                .ForMember(dest => dest.MagicSchoolName, opts => { opts.MapFrom(from => from.MagicSchool.Name); });
            CreateMap<MagicSchool, MagicSchoolModel>();
        }
    }
}
