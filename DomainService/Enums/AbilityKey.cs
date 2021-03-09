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
        Intelligence = 4
    }
}