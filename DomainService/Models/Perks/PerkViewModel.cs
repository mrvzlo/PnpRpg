using System.Collections.Generic;
using Pnprpg.DomainService.Models.Common;
using Pnprpg.DomainService.Models.Requirements;

namespace Pnprpg.DomainService.Models.Perks
{
    public class PerkViewModel : Upgradeable
    {
        public string Description { get; set; }
        public List<RequirementCommonModel> Requirements { get; set; }
    }
}
