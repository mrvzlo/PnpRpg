using System.Linq;
using AutoMapper;
using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.Models;

namespace Pnprpg.Domain.Profiles
{
    public class HeroProfile : Profile
    {
        public HeroProfile()
        {
            CreateMap<Branch, BranchShortModel>();
            CreateMap<Branch, BranchViewModel>()
                .ForMember(dest => dest.Bonuses, o => o.MapFrom(from => from.Bonuses.Select(x => x.Bonus)));
            CreateMap<Branch, BranchEditModel>()
                .ForMember(dest => dest.Bonuses, o => o.MapFrom(from => from.Bonuses.Select(x => x.Bonus.Id)));

            CreateMap<Race, RaceViewModel>()
                .ForMember(dest => dest.Bonuses, o => o.MapFrom(from => from.Bonuses.Select(x => x.Bonus)))
                .ForMember(dest => dest.Modifiers, o => o.MapFrom(from => from.Abilities));
            CreateMap<Race, RaceEditModel>()
                .ForMember(dest => dest.Bonuses, o => o.MapFrom(from => from.Bonuses.Select(x => x.Bonus.Id)));

            CreateMap<Bonus, BonusViewModel>()
                .ForMember(dest => dest.Usages, o => 
                    o.MapFrom(from => from.Races.Count + from.Branches.Count + from.Weapons.Count));
            CreateMap<Bonus, BonusEditModel>();

            CreateMap<Ability, AbilityModel>();
            CreateMap<Ability, AbilityDescriptionModel>();
            CreateMap<Ability, AbilityAssignModel>();

            CreateMap<RaceAbility, AbilityAssignModel>()
                .ForMember(dest => dest.Id, o => o.MapFrom(from => from.AbilityId));
            CreateMap<RaceAbility, AbilityModifier>()
                .ForMember(dest => dest.Modifier, o => o.MapFrom(from => from.Value));

            CreateMap<Trait, TraitModel>();

            CreateMap<TraitEffect, TraitEffectDescModel> ();
        }
    }
}
