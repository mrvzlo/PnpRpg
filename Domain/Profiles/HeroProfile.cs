using System.Linq;
using AutoMapper;
using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.Models;

namespace Pnprpg.Domain.Profiles
{
    public class HeroProfile : Profile
    {
        public HeroProfile()
        {
            CreateMap<Branch, BranchShortModel>();
            CreateMap<Branch, BranchViewModel>()
                .ForMember(dest => dest.Bonuses, opts =>
                    { opts.MapFrom(from => from.Bonuses.Select(x => x.Bonus)); });
            CreateMap<Branch, BranchEditModel>()
                .ForMember(dest => dest.Bonuses, opts =>
                    { opts.MapFrom(from => from.Bonuses.Select(x => x.Bonus.Id)); });

            CreateMap<Race, RaceViewModel>()
                .ForMember(dest => dest.Bonuses, opts =>
                    { opts.MapFrom(from => from.Bonuses.Select(x => x.Bonus)); })
                .ForMember(dest => dest.Modifiers, opts => { opts.MapFrom(from => from.Abilities); });
            CreateMap<Race, RaceEditModel>()
                .ForMember(dest => dest.Bonuses, opts =>
                    { opts.MapFrom(from => from.Bonuses.Select(x => x.Bonus.Id)); });

            CreateMap<Bonus, BonusViewModel>();
            CreateMap<Bonus, BonusEditModel>();

            CreateMap<Ability, AbilityModel>();
            CreateMap<Ability, AbilityDescriptionModel>();
            CreateMap<Ability, AbilityAssignModel>();

            CreateMap<RaceAbility, AbilityAssignModel>()
                .ForMember(dest => dest.Id, opts => { opts.MapFrom(from => from.AbilityId);});
            CreateMap<RaceAbility, AbilityModifier>()
                .ForMember(dest => dest.Modifier, opts => { opts.MapFrom(from => from.Value);});

            CreateMap<Trait, TraitModel>();

            CreateMap<TraitEffect, TraitEffectDescModel> ();
        }
    }
}
