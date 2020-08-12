using System.ComponentModel.DataAnnotations.Schema;

namespace Pnprpg.DomainService.Entities
{
    [Table("WeaponsBonuses")]
    public class WeaponBonus : BaseEntity<int>
    {
        public int WeaponId { get; set; }
        public int BonusId { get; set; }
        
        public virtual Weapon Weapon { get; set; }
        public virtual Bonus Bonus { get; set; }
    }
}
