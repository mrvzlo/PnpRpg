using System.Collections.Generic;

namespace Pnprpg.DomainService.Entities
{
    public class Perk : BaseEntity<int>
    {
        public int Level { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<RequirementForPerk> Requirements { get; set; }
    }
}