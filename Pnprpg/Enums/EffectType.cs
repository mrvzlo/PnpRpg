using System.ComponentModel;
using Boot.Enums.Attributes;

namespace Boot.Enums
{
    public enum EffectType
    {
        [Description("Усиление")]
        Boost = 0,
        [Description("Ослабление")]
        Weaken = 1,
        [Description("Оглушение")]
        [Translation("🤕")]
        Stun = 2,
        [Description("Разоружение")]
        [Translation("🖐")]
        Disarm = 3,
        [Description("Пробитие")]
        [Translation("🛡")]
        Crush = 4,
        [Description("Копание")]
        [Translation("⛏️")]
        Mine = 5,
    }
}