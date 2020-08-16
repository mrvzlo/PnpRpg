using AutoMapper;
using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.Models;

namespace Pnprpg.Domain.Profiles
{
    public class RequirementProfile : Profile
    {
        public RequirementProfile()
        {
            CreateMap<RequirementForPerk, RequirementCommonModel>();

            CreateMap<Ability, Selectable>()
                .ForMember(dest => dest.Value, opts => 
                    { opts.MapFrom(from => from.Id); })
                .ForMember(dest => dest.Text, opts => 
                    { opts.MapFrom(from => from.Name); });

            CreateMap<Perk, Selectable>()
                .ForMember(dest => dest.Value, opts => 
                    { opts.MapFrom(from => from.Id); })
                .ForMember(dest => dest.Text, opts => 
                    { opts.MapFrom(from => from.Name); });

            CreateMap<Race, Selectable>()
                .ForMember(dest => dest.Value, opts => 
                    { opts.MapFrom(from => from.Id); })
                .ForMember(dest => dest.Text, opts => 
                    { opts.MapFrom(from => from.Name); });
        }
    }
}
