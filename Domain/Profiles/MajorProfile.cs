using AutoMapper;
using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.Models;

namespace Pnprpg.Domain.Profiles
{
    public class MajorProfile : Profile
    {
        public MajorProfile()
        {
            CreateMap<Major, MajorShortModel>();
            CreateMap<Major, MajorFullModel>();
            CreateMap<Major, MajorSettings>();
        }
    }
}
