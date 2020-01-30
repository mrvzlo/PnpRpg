using System.ComponentModel;

namespace Boot.Enums
{
    public enum FileType
    {
        [Description("MagicSchools.json")]
        MagicSchools,
        [Description("Skills.json")]
        Skills,
        [Description("Reagents.json")]
        Reagents,
        [Description("Processes.json")]
        Processes,
        [Description("Reactions.json")]
        Reactions,
        [Description("Potions.json")]
        Potions,
    }
}