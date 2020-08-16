using System.Linq;
using AutoMapper;
using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.Models;

namespace Pnprpg.Domain.Profiles
{
    public class PerkProfile : Profile
    {
        public PerkProfile()
        {
            CreateMap<Perk, PerkViewModel>()
                .ForMember(dest => dest.RequirementsForPerks, opts => {
                    opts.MapFrom(from => from.RequirementsForPerks
                        .Where(y => y.Type != RequirementType.Level));
                })
                .ForMember(dest => dest.Level, opts => {
                    opts.MapFrom(from => from.RequirementsForPerks
                        .FirstOrDefault(y => y.Type == RequirementType.Level).Value);
                });

            CreateMap<Perk, PerkEditModel>()
                .ForMember(dest => dest.RequirementsForPerks, opts => {
                    opts.MapFrom(from => from.RequirementsForPerks
                        .Where(y => y.Type != RequirementType.Level));
                })
                .ForMember(dest => dest.Level, opts => {
                    opts.MapFrom(from => from.RequirementsForPerks
                        .FirstOrDefault(y => y.Type == RequirementType.Level).Value);
                });

        }
    }
}
