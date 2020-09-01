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
                    { opts.MapFrom(from => from.Bonuses.Select(x => x.Bonus)); });
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

            CreateMap<Trait, TraitModel>();

            CreateMap<TraitEffect, EffectDescModel> ();
        }
    }
}
