namespace Pnprpg.DomainService.Entities
{
    public class BaseBonusJoin : BaseEntity<int>
    {
        public int BonusId { get; set; }
        public virtual Bonus Bonus { get; set; }
    }
}
