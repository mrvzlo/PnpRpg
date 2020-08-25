using System.ComponentModel.DataAnnotations.Schema;

namespace Pnprpg.DomainService.Entities
{
    [Table("BranchBonuses")]
    public class BranchBonus : BaseBonusJoin
    {
        public int BranchId { get; set; }
        public virtual Branch Branch { get; set; }
    }
}
