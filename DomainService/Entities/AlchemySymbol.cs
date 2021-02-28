using Pnprpg.DomainService.Enums;

namespace Pnprpg.DomainService.Entities
{
    public class AlchemySymbol : BaseEntity
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public AlchemySymbolType SymbolType { get; set; }
    }
}