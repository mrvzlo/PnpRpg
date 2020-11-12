using System.Collections.Generic;

namespace Pnprpg.DomainService.Entities
{
    public class Branch : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }

        public virtual ICollection<BranchBonus> Bonuses { get; set; }
        public virtual ICollection<Skill> Skills { get; set; }
        public virtual ICollection<Perk> Perks{ get; set; }
    }
}
