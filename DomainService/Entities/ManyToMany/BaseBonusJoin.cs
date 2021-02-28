namespace Pnprpg.DomainService.Entities
{
    public class BaseBonusJoin : BaseEntity
    {
        public int BonusId { get; set; }
        public virtual Bonus Bonus { get; set; }
    }
}
