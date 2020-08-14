using System.Collections.Generic;
using System.Linq;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.Models.Common;
using Pnprpg.DomainService.Models.Requirements;

namespace Pnprpg.DomainService.Models.Perks
{
    public class PerkViewModel : Upgradeable
    {
        public string Description { get; set; }
        public List<RequirementCommonModel> RequirementsForPerks { get; set; }
        public PerkBranchModel Branch { get; set; }
    }
}
