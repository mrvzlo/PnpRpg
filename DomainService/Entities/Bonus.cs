using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pnprpg.DomainService.Entities
{
    [Table("Bonuses")]
    public class Bonus : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Icon { get; set; }

        public virtual ICollection<WeaponBonus> Weapons { get; set; }
    }
}
