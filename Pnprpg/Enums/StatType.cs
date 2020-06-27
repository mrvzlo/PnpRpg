using System.ComponentModel;
using Boot.Enums.Attributes;

namespace Boot.Enums
{
    public enum StatType
    {
        [Description("Strength")]
        [Translation("Сила")]
        [Color("danger")]
        S,
        [Description("Endurance")]
        [Translation("Выносливость")]
        [Color("warning")]
        E,
        [Description("Agility")]
        [Translation("Ловкость")]
        [Color("success")]
        A,
        [Description("Intelligence")]
        [Translation("Интеллект")]
        [Color("info")]
        I
    }
}