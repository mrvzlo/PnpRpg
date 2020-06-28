using Boot.Models.JsonModels;
using System.Collections.Generic;

namespace Boot.Models
{
    public class AlchemySummary
    {
        public List<SymbolInfo> Reagents, Processes;
        public List<Reaction> Reactions;
    }
}