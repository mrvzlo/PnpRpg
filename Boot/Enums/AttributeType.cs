using System.ComponentModel;

namespace Boot.Enums
{
    public enum AttributeType
    {
        [Description("Сила")]
        Strength,
        [Description("Восприятие")]
        Perception,
        [Description("Ловкость")]
        Agility,
        [Description("Интеллект")]
        Intelligence
    }
}