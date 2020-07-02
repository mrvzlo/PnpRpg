using System.ComponentModel;

namespace Boot.Enums
{
    public enum RequirementType
    {
        Level = 0,
        [Description("Способность")]
        Perk = 1,
        [Description("Раса")]
        Race = 2,
        [Description("Атрибут")]
        Stat = 3,
    }
}