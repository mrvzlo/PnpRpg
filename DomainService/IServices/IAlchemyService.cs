using System.Linq;
using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.Models.Alchemy;

namespace Pnprpg.DomainService.IServices
{
    public interface IAlchemyService
    {
        IQueryable<AlchemySymbolModel> GetAllReagents();
        IQueryable<AlchemySymbolModel> GetAllProcesses();
        PotionModel GetPotionByReaction(ReactionModel reaction);
        PotionModel GetRandomPotion();
        AlchemySummary GetSummary();
    }
}
