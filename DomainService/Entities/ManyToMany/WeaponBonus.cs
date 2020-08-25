using System.ComponentModel.DataAnnotations.Schema;

namespace Pnprpg.DomainService.Entities
{
    [Table("WeaponsBonuses")]
    public class WeaponBonus : BaseBonusJoin
    {
        public int WeaponId { get; set; }
        public virtual Weapon Weapon { get; set; }
    }
}
