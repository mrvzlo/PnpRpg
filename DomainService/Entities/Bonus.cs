using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Pnprpg.DomainService.Enums;

namespace Pnprpg.DomainService.Entities
{
    [Table("Bonuses")]
    public class Bonus : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public BonusType Type { get; set; }

        public virtual ICollection<RaceBonus> Races { get; set; }
        public virtual ICollection<BranchBonus> Branches { get; set; }
        public virtual ICollection<WeaponBonus> Weapons { get; set; }
    }
}
