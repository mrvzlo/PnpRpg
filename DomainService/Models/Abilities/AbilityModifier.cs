namespace Pnprpg.DomainService.Models
{
    public class AbilityModifier
    {
        public AbilityModel Ability { get; set; }
        public int Modifier { get; set; }

        public void Revert() => Modifier *= -1;
    }
}
