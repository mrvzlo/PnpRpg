namespace Pnprpg.DomainService.Entities
{
    public class Ability : BaseEntity<int>
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public string Influence { get; set; }
    }
}