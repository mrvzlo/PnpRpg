using AutoMapper;
using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.Models.Alchemy;

namespace Pnprpg.Domain.Profiles
{
    public class AlchemyProfile : Profile
    {
        public AlchemyProfile()
        {
            CreateMap<AlchemySymbol, AlchemySymbolModel>();
            CreateMap<Reaction, ReactionModel>();
            CreateMap<Potion, PotionModel>();
        }
    }
}
