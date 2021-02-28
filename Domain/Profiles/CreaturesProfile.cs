using AutoMapper;
using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.Models;

namespace Pnprpg.Domain.Profiles
{
    public class CreaturesProfile : Profile
    {
        public CreaturesProfile()
        {
            CreateMap<Creature, CreatureViewModel>();
            CreateMap<Creature, CreatureEditModel>();
        }
    }
}
