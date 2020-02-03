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
        [Description("Мин. сила")]
        StatS = 10,
        [Description("Мин. восприятие")]
        StatP = 11,
        [Description("Мин. ловкость")]
        StatA = 12,
        [Description("Мин. интеллект")]
        StatI = 13
    }
}