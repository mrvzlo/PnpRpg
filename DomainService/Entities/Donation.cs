namespace Pnprpg.DomainService.Entities
{
    public class Donation : BaseEntity
    {
        public string Name { get; set; }
        public decimal Total { get; set; }
        public decimal Current { get; set; }
    }
}
