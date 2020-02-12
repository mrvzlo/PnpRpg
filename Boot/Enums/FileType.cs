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
        [Description("Perks.json")]
        Perks,
        [Description("Traits.json")]
        Traits,
        [Description("Races.json")]
        Races,
        [Description("Users.json")]
        Users,
        [Description("Rooms.json")]
        Rooms
    }
}