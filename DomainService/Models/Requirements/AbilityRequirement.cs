namespace Pnprpg.DomainService.Models
{
    public class AbilityRequirement : RequirementCommonModel
    {
        public AbilityRequirement(RequirementCommonModel parent) : base(parent) { }

        public override string ToString() => $"{Ability.Symbol} {Value}";
    }
}
