using System.Linq;
using AutoMapper;
using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.Enums;
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
            CreateMap<Perk, PerkViewModel>()
                .ForMember(dest => dest.Description, opts => { opts.MapFrom(from => from.Description); })
                .ForMember(dest => dest.Branch, opts => { opts.MapFrom(from => from.Branch); })
                .ForMember(dest => dest.RequirementsForPerks, opts => { opts.MapFrom(from => from.RequirementsForPerks
                    .Where(y => y.Type != RequirementType.Level)); })
                .ForMember(dest => dest.Level, opts => { opts.MapFrom(from => from.RequirementsForPerks
                    .FirstOrDefault(y => y.Type == RequirementType.Level).Value); });

            CreateMap<Perk, PerkEditModel>()
                .ForMember(dest => dest.RequirementsForPerks, opts => {
                    opts.MapFrom(from => from.RequirementsForPerks
                        .Where(y => y.Type != RequirementType.Level));
                })
                .ForMember(dest => dest.Level, opts => {
                    opts.MapFrom(from => from.RequirementsForPerks
                        .FirstOrDefault(y => y.Type == RequirementType.Level).Value);
                });

            CreateMap<PerkBranch, PerkBranchModel>();

            CreateMap<Race, RaceModel>();

            CreateMap<Ability, AbilityModel>();
            CreateMap<Ability, AbilityDescriptionModel>();

            CreateMap<SkillInfo, SkillModel>()
                .ForMember(dest => dest.GroupName, opts => { opts.MapFrom(from => from.Group.Name); });
            CreateMap<SkillGroup, SkillGroupModel>();

            CreateMap<Trait, TraitModel>();

            CreateMap<Effect, EffectDescModel> ();
        }
    }
}
