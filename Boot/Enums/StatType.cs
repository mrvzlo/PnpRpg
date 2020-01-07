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
        [Description("Perception")]
        [Translation("Восприятие")]
        [Color("warning")]
        P,
        [Description("Agility")]
        [Translation("Ловкость")]
        [Color("success")]
        A,
        [Description("Intelligence")]
        [Translation("Интеллект")]
        [Color("primary")]
        I
    }
}