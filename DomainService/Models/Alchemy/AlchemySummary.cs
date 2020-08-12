using System.Collections.Generic;

namespace Pnprpg.DomainService.Models.Alchemy
{
    public class AlchemySummary
    {
        public List<AlchemySymbolModel> Reagents, Processes;
        public List<ReactionModel> Reactions;
    }
}