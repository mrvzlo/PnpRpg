namespace Pnprpg.DomainService.Entities
{
    public class Perk : BaseSettingPart
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Max { get; set; }
        public int Level { get; set; }

        public int BranchId { get; set; }
        public virtual Branch Branch { get; set; }
    }
}