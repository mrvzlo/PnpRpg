using AutoMapper;
using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.Models.Magic;

namespace Pnprpg.Domain.Profiles
{
    public class MagicProfile : Profile
    {
        public MagicProfile()
        {
            CreateMap<Spell, SpellModel>()
                .ForMember(dest => dest.Color, opts =>
                    { opts.MapFrom(from => from.MagicSchool.Group.Color); });
            CreateMap<MagicSchool, MagicSchoolInfoModel>();
            CreateMap<MagicSchoolGroup, MagicSchoolGroupModel>();
        }
    }
}
