namespace Pnprpg.DomainService.Entities
{
    public class RaceAbility : BaseEntity<int>
    {
        public int RaceId { get; set; }
        public int AbilityId { get; set; }
        public int Value { get; set; }

        public virtual Race Race { get; set; }
        public virtual Ability Ability { get; set; }
    }
}
