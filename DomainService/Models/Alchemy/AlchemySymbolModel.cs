namespace Pnprpg.DomainService.Models
{
    public class AlchemySymbolModel
    {
        public string Symbol;
        public string Name;
        public int Value;
        public int Id;

        public override string ToString() => $"{Symbol} {Name}";
    }
}