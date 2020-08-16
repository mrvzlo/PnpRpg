using AutoMapper;
using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.Models;

namespace Pnprpg.Domain.Profiles
{
    public class SkillProfile : Profile
    {
        public SkillProfile()
        {
            CreateMap<SkillInfo, SkillViewModel>()
                .ForMember(dest => dest.BranchName, opts => { opts.MapFrom(from => from.Branch.Name); });
            CreateMap<SkillInfo, SkillEditModel>();

        }
    }
}
