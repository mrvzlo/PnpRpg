namespace Pnprpg.DomainService.Entities
{
    public class Reaction : BaseEntity
    {
        public int Reagent { get; set; }
        public int Process { get; set; }
        public int PotionId { get; set; }

        public virtual Potion Potion { get; set; }
    }
}