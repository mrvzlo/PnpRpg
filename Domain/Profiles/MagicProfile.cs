using AutoMapper;
using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.Models;

namespace Pnprpg.Domain.Profiles
{
    public class MagicProfile : Profile
    {
        public MagicProfile()
        {
            CreateMap<Spell, SpellModel>()
                .ForMember(dest => dest.Color, opts =>
                    { opts.MapFrom(from => from.MagicSchool.Color); });
            CreateMap<MagicSchool, MagicSchoolModel>();
        }
    }
}
