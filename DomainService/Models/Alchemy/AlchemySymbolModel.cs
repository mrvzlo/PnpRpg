namespace Pnprpg.DomainService.Models.Alchemy
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