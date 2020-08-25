using System.ComponentModel.DataAnnotations.Schema;

namespace Pnprpg.DomainService.Entities
{
    [Table("RaceBonuses")]
    public class RaceBonus : BaseBonusJoin
    {
        public int RaceId { get; set; }
        public virtual Race Race { get; set; }
    }
}
