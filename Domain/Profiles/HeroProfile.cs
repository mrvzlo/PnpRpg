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
            CreateMap<Branch, BranchModel>();

            CreateMap<Race, RaceViewModel>();
            CreateMap<Race, RaceEditModel>();

            CreateMap<Ability, AbilityModel>();
            CreateMap<Ability, AbilityDescriptionModel>();

            CreateMap<Trait, TraitModel>();

            CreateMap<Effect, EffectDescModel> ();
        }
    }
}
