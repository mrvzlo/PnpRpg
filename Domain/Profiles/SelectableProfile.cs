using AutoMapper;
using Pnprpg.DomainService.Models;

namespace Pnprpg.Domain.Profiles
{
    public class SelectableProfile : Profile
    {
        public SelectableProfile()
        {
            CreateMap<IBaseViewModel, Selectable>()
                .ForMember(dest => dest.Value, opts => { opts.MapFrom(from => from.Id); })
                .ForMember(dest => dest.Text, opts => { opts.MapFrom(from => from.Name); });
        }
    }
}
