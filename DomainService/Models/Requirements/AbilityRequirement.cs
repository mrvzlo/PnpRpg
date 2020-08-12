namespace Pnprpg.DomainService.Models.Requirements
{
    public class AbilityRequirement : RequirementCommonModel
    {
        public AbilityRequirement(RequirementCommonModel parent) : base(parent) { }

        public override string ToString() => $"{Ability.Symbol} {Value}";
    }
}
