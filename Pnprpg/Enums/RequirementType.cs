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
        //attributes
        [Description("Мин. {0}")]
        StatS = 10,
        [Description("Мин. {0}")]
        StatP = 11,
        [Description("Мин. {0}")]
        StatA = 12,
        [Description("Мин. {0}")]
        StatI = 13
    }
}