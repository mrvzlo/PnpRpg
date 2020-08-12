using System.ComponentModel;

namespace Pnprpg.DomainService.Enums
{
    public enum RequirementType
    {
        Level = 0,
        [Description("Способность")]
        Perk = 1,
        [Description("Раса")]
        Race = 2,
        [Description("Атрибут")]
        Ability = 3,
    }
}