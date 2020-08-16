namespace Pnprpg.DomainService.Models
{
    public class ReactionModel
    {
        public int Reagent { get; set; }
        public int Process { get; set; }
        public int PotionId { get; set; }

        public PotionModel Potion;
    }
}