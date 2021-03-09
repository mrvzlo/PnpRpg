using System;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IRepositories;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;

namespace Pnprpg.Domain.Services
{
    public class AlchemyService : BaseService, IAlchemyService
    {
        private readonly IAlchemySymbolRepository _alchemySymbolRepository;
        private readonly IPotionRepository _potionRepository;
        private readonly IReactionRepository _reactionRepository;

        public AlchemyService(IMapper mapper, IAlchemySymbolRepository alchemySymbolRepository, IReactionRepository reactionRepository,
            IPotionRepository potionRepository) : base(mapper)
        {
            _alchemySymbolRepository = alchemySymbolRepository;
            _reactionRepository = reactionRepository;
            _potionRepository = potionRepository;
        }

        public IQueryable<AlchemySymbolModel> GetAllReagents()
        {
            return _alchemySymbolRepository.Select()
                .Where(x => x.SymbolType == AlchemySymbolType.Reagent)
                .ProjectTo<AlchemySymbolModel>(MapperConfig);
        }

        public IQueryable<AlchemySymbolModel> GetAllProcesses()
        {
            return _alchemySymbolRepository.Select()
                .Where(x => x.SymbolType == AlchemySymbolType.Process)
                .ProjectTo<AlchemySymbolModel>(MapperConfig);
        }

        public PotionModel GetPotionByReaction(ReactionModel reaction)
        {
            var potion = _reactionRepository.Select()
                .Where(x => x.Process == reaction.Process)
                .Where(x => x.Reagent == reaction.Reagent)
                .Select(x => x.Potion).First();

            return Mapper.Map<PotionModel>(potion);
        }

        public PotionModel GetRandomPotion()
        {
            var potion = _potionRepository.GetRandom();
            return potion.ProjectTo<PotionModel>(MapperConfig).First();
        }

        public AlchemySummary GetSummary()
        {
            return new AlchemySummary
            {
                Reactions = GetAllReactions().ToList(),
                Processes = GetAllProcesses().ToList(),
                Reagents = GetAllReagents().ToList()
            };
        }

        private IQueryable<ReactionModel> GetAllReactions()
        {
            return _reactionRepository.Select().ProjectTo<ReactionModel>(MapperConfig);
        }
    }
}
