using Pnprpg.DomainService.Enums;

namespace Pnprpg.DomainService.Models
{
    public class RequirementCommonModel
    {
        public RequirementType Type { get; set; }
        public int Value { get; set; }
        public int? AbilityId { get; set; }
        public int TargetId { get; set; }
        public AbilityModel Ability { get; set; }

        public RequirementCommonModel() { }

        public RequirementCommonModel(RequirementCommonModel parent)
        {
            foreach (var prop in parent.GetType().GetProperties())
                GetType().GetProperty(prop.Name)?.SetValue(this, prop.GetValue(parent, null), null);
        }

        public dynamic Specify()
        {
            switch (Type)
            {
                case RequirementType.Level:
                    return new LevelRequirement(this);
                case RequirementType.Perk:
                    return new PerkRequirement(this);
                case RequirementType.Race:
                    return new RaceRequirement(this);
                case RequirementType.Ability:
                    return new AbilityRequirement(this);
                default:
                    return this;
            }
        }

        public static dynamic New(RequirementType type) =>
            new RequirementCommonModel { Type = type }.Specify();
    }
}
