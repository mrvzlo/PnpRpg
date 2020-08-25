using System.Linq;
using AutoMapper;
using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.Models;

namespace Pnprpg.Domain.Profiles
{
    public class PerkProfile : Profile
    {
        public PerkProfile()
        {
            CreateMap<Perk, PerkViewModel>();
            CreateMap<Perk, PerkEditModel>();
        }
    }
}
