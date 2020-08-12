using AutoMapper;
using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.Models.Abilities;
using Pnprpg.DomainService.Models.Common;
using Pnprpg.DomainService.Models.Perks;
using Pnprpg.DomainService.Models.Races;
using Pnprpg.DomainService.Models.Skills;
using Pnprpg.DomainService.Models.Traits;

namespace Pnprpg.Domain.Profiles
{
    public class HeroProfile : Profile
    {
        public HeroProfile()
        {
            CreateMap<Perk, PerkViewModel>();
            CreateMap<Race, RaceModel>();

            CreateMap<Ability, AbilityModel>();
            CreateMap<Ability, AbilityDescriptionModel>();
            CreateMap<SkillInfo, SkillModel>()
                .ForMember(dest => dest.GroupName, opts =>
                    { opts.MapFrom(from => from.Group.Name); });

            CreateMap<SkillGroup, SkillGroupModel>();
            CreateMap<Trait, TraitModel>();

            CreateMap<Effect, EffectDescModel > ();
        }
    }
}
