using System.Collections.Generic;

namespace Pnprpg.DomainService.Models
{
    public class PerkViewModel : Upgradeable
    {
        public string Description { get; set; }
        public List<RequirementCommonModel> RequirementsForPerks { get; set; }
        public BranchModel Branch { get; set; }
    }
}
