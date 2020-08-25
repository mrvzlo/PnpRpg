namespace Pnprpg.DomainService.Entities
{
    public class Perk : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int BranchId { get; set; }
        public int Max { get; set; }
        public int Level { get; set; }

        public Branch Branch { get; set; }
    }
}