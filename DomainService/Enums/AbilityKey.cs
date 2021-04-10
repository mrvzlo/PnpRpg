using System.ComponentModel;

namespace Pnprpg.DomainService.Enums
{
    public enum AbilityType
    {
        [Description("S")]
        Strength = 1,
        [Description("E")]
        Endurance = 2,
        [Description("A")]
        Agility = 3,
        [Description("I")]
        Intelligence = 4,
        [Description("С")]
        Charisma = 5,
        [Description("W")]
        Wisdom = 6,
        [Description("P")]
        Perception = 7,
        [Description("L")]
        Luck = 8,
        [Description("R")]
        Reason = 9,
        [Description("T")]
        Technics = 10,
    }
}