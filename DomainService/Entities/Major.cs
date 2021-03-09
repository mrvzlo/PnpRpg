namespace Pnprpg.DomainService.Entities
{
    public class Major : BaseEntity
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public string Color { get; set; }
        public bool Enabled { get; set; }
        public int MinAbility { get; set; }
        public int MaxAbility { get; set; }
    }
}
