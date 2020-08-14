using System.Collections.Generic;

namespace Pnprpg.DomainService.Entities
{
    public class Perk : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int BranchId { get; set; }
        public int Max { get; set; }

        public ICollection<RequirementForPerk> RequirementsForPerks { get; set; }
        public PerkBranch Branch { get; set; }
    }
}